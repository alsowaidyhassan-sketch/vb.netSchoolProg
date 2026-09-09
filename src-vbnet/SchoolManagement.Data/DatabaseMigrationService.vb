Imports System.Data
Imports System.IO
Imports System.Threading.Tasks
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Data.Infrastructure

Namespace Migrations
    Public Class DatabaseMigrationService
        Public Shared Async Function MigrateUpAsync() As Task
            Try
                ' Create Database if it does not exist (Requires Master connection)
                Await EnsureDatabaseExistsAsync()

                ' Run Migrations
                Using conn = ConnectionManager.CreateConnection()
                    Await conn.OpenAsync()
                    
                    ' Create Schema Versions Table
                    Const createSchemaTable = "
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='__SchemaVersions' and xtype='U')
                        BEGIN
                            CREATE TABLE __SchemaVersions (
                                Version INT PRIMARY KEY,
                                AppliedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
                                Description NVARCHAR(255)
                            )
                        END"
                    Await conn.ExecuteAsync(createSchemaTable)

                    ' Apply Initial Migration
                    Await ApplyMigrationAsync(conn, 1, "InitialCreate", GetInitialMigrationScript())
                End Using
            Catch ex As Exception
                ' Log error (we will implement proper logging later)
                Console.WriteLine("Migration failed: " & ex.Message)
            End Try
        End Function

        Private Shared Async Function EnsureDatabaseExistsAsync() As Task
            Dim connStr = ConnectionManager.GetConnectionString()
            Dim builder As New SqlConnectionStringBuilder(connStr)
            Dim dbName = builder.InitialCatalog
            builder.InitialCatalog = "master"
            
            Using conn As New SqlConnection(builder.ConnectionString)
                Await conn.OpenAsync()
                Dim checkDbSql = $"SELECT database_id FROM sys.databases WHERE Name = '{dbName}'"
                Dim dbId = Await conn.ExecuteScalarAsync(Of Integer?)(checkDbSql)
                
                If Not dbId.HasValue Then
                    ' Database does not exist, create it safely
                    Dim createDbSql = $"CREATE DATABASE [{dbName}]"
                    Await conn.ExecuteAsync(createDbSql)
                End If
            End Using
        End Function

        Private Shared Async Function ApplyMigrationAsync(conn As IDbConnection, version As Integer, description As String, script As String) As Task
            Dim checkMigration = "SELECT COUNT(1) FROM __SchemaVersions WHERE Version = @Version"
            Dim isApplied = Await conn.ExecuteScalarAsync(Of Integer)(checkMigration, New With {.Version = version}) > 0

            If Not isApplied Then
                Using tx = conn.BeginTransaction()
                    Try
                        Await conn.ExecuteAsync(script, transaction:=tx)
                        Await conn.ExecuteAsync("INSERT INTO __SchemaVersions (Version, Description) VALUES (@Version, @Description)", 
                                                New With {.Version = version, .Description = description}, transaction:=tx)
                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using
            End If
        End Function

        Private Shared Function GetInitialMigrationScript() As String
            Return "
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Students' and xtype='U')
                BEGIN
                    CREATE TABLE Students (
                        StudentId INT IDENTITY(1,1) PRIMARY KEY,
                        SchoolId INT NOT NULL DEFAULT 1,
                        StudentNumber NVARCHAR(50) NOT NULL UNIQUE,
                        Barcode NVARCHAR(50),
                        IdentityDocumentType NVARCHAR(100),
                        NationalId NVARCHAR(50),
                        FirstName NVARCHAR(100) NOT NULL,
                        FatherName NVARCHAR(100),
                        GrandFatherName NVARCHAR(100),
                        GreatGrandFatherName NVARCHAR(100),
                        FamilyName NVARCHAR(100),
                        MotherName NVARCHAR(100),
                        Gender NVARCHAR(20) DEFAULT 'ذكر',
                        DateOfBirth DATE,
                        BirthPlace NVARCHAR(100),
                        Nationality NVARCHAR(50) DEFAULT 'عراقي',
                        Phone NVARCHAR(50),
                        Email NVARCHAR(100),
                        Province NVARCHAR(50) DEFAULT 'بغداد',
                        District NVARCHAR(100),
                        SubDistrict NVARCHAR(100),
                        Area NVARCHAR(100),
                        Mahalla NVARCHAR(50),
                        Zuqaq NVARCHAR(50),
                        HouseNumber NVARCHAR(50),
                        NearestLandmark NVARCHAR(200),
                        Address NVARCHAR(255),
                        PhotoPath NVARCHAR(255),
                        PrimaryParentId INT,
                        EmergencyContactName NVARCHAR(100),
                        EmergencyContactPhone NVARCHAR(50),
                        BloodType NVARCHAR(10),
                        HasSpecialNeeds BIT DEFAULT 0,
                        MedicalNotes NVARCHAR(MAX),
                        CurrentClassId INT,
                        CurrentSectionId INT,
                        Status NVARCHAR(50) DEFAULT 'Active',
                        EnrollmentDate DATE,
                        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
                        UpdatedAt DATETIME2,
                        CreatedBy NVARCHAR(100),
                        UpdatedBy NVARCHAR(100),
                        IsActive BIT DEFAULT 1
                    )
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Teachers' and xtype='U')
                BEGIN
                    CREATE TABLE Teachers (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        FullName NVARCHAR(200) NOT NULL,
                        EmployeeNumber NVARCHAR(50) NOT NULL UNIQUE,
                        Phone NVARCHAR(50),
                        Specialization NVARCHAR(100),
                        WeeklyQuotaHours INT DEFAULT 0,
                        EmploymentDate DATE,
                        Status NVARCHAR(50) DEFAULT 'Active',
                        IsDeleted BIT DEFAULT 0
                    )
                END;
                
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FeeInvoices' and xtype='U')
                BEGIN
                    CREATE TABLE FeeInvoices (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
                        StudentId INT,
                        FeeType NVARCHAR(100),
                        Amount DECIMAL(18, 2) NOT NULL CHECK (Amount > 0),
                        Paid DECIMAL(18, 2) DEFAULT 0,
                        DueDate DATE,
                        Status NVARCHAR(50),
                        IsDeleted BIT DEFAULT 0
                    )
                END;
                
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PaymentReceipts' and xtype='U')
                BEGIN
                    CREATE TABLE PaymentReceipts (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ReceiptNumber NVARCHAR(50) NOT NULL UNIQUE,
                        InvoiceId INT,
                        AmountPaid DECIMAL(18, 2) NOT NULL CHECK (AmountPaid > 0),
                        PaymentDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
                        Notes NVARCHAR(255)
                    )
                END;
            "
        End Function
    End Class
End Namespace
