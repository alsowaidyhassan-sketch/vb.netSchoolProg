Imports System.Collections.Generic
Imports System.Data
Imports System.Threading.Tasks
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces
Imports SchoolManagement.Data.Infrastructure

Namespace Repositories
    Public Class StudentRepository
        Implements IStudentRepository

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Student) Implements IRepository(Of Student).GetByIdAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT [StudentId], [SchoolId], [StudentNumber], [Barcode], [IdentityDocumentType], [NationalId], [FirstName], [FatherName], [GrandFatherName], [GreatGrandFatherName], [FamilyName], [MotherName], [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Province], [District], [SubDistrict], [Area], [Mahalla], [Zuqaq], [HouseNumber], [NearestLandmark], [Address], [PhotoPath], [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType], [HasSpecialNeeds], [MedicalNotes], [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive] FROM [dbo].[Students] WHERE [StudentId] = @Id AND [IsActive] = 1;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Student)(sql, New With {.Id = id})
            End Using
        End Function

        Public Async Function GetAllAsync() As Task(Of IEnumerable(Of Student)) Implements IRepository(Of Student).GetAllAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT TOP 1000 [StudentId], [SchoolId], [StudentNumber], [Barcode], [IdentityDocumentType], [NationalId], [FirstName], [FatherName], [GrandFatherName], [GreatGrandFatherName], [FamilyName], [MotherName], [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Province], [District], [SubDistrict], [Area], [Mahalla], [Zuqaq], [HouseNumber], [NearestLandmark], [Address], [PhotoPath], [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType], [HasSpecialNeeds], [MedicalNotes], [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive] FROM [dbo].[Students] WHERE [IsActive] = 1 ORDER BY [StudentId] DESC;"
                Return Await conn.QueryAsync(Of Student)(sql)
            End Using
        End Function

        Public Async Function AddAsync(entity As Student) As Task(Of Integer) Implements IRepository(Of Student).AddAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    INSERT INTO [dbo].[Students] (
                        [SchoolId], [StudentNumber], [Barcode], [NationalId], [FirstName], [SecondName], [ThirdName], [LastName],
                        [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Address],
                        [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType],
                        [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedBy]
                    ) VALUES (
                        @SchoolId, @StudentNumber, @Barcode, @NationalId, @FirstName, @SecondName, @ThirdName, @LastName,
                        @Gender, @DateOfBirth, @BirthPlace, @Nationality, @Phone, @Email, @Address,
                        @PrimaryParentId, @EmergencyContactName, @EmergencyContactPhone, @BloodType,
                        @CurrentClassId, @CurrentSectionId, @Status, @EnrollmentDate, @CreatedBy
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"
                Return Await conn.ExecuteScalarAsync(Of Integer)(sql, entity)
            End Using
        End Function

        Public Async Function UpdateAsync(entity As Student) As Task(Of Boolean) Implements IRepository(Of Student).UpdateAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    UPDATE [dbo].[Students] SET
                        [FirstName] = @FirstName,
                        [SecondName] = @SecondName,
                        [ThirdName] = @ThirdName,
                        [LastName] = @LastName,
                        [Phone] = @Phone,
                        [Address] = @Address,
                        [CurrentClassId] = @CurrentClassId,
                        [CurrentSectionId] = @CurrentSectionId,
                        [Status] = @Status,
                        [EmergencyContactName] = @EmergencyContactName,
                        [EmergencyContactPhone] = @EmergencyContactPhone,
                        [UpdatedAt] = SYSUTCDATETIME(),
                        [UpdatedBy] = @UpdatedBy
                    WHERE [StudentId] = @StudentId;"
                Dim affected = Await conn.ExecuteAsync(sql, entity)
                Return affected > 0
            End Using
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IRepository(Of Student).DeleteAsync
            Using conn = ConnectionManager.CreateConnection()
                ' Soft delete
                Const sql As String = "UPDATE [dbo].[Students] SET [IsActive] = 0, [UpdatedAt] = SYSUTCDATETIME() WHERE [StudentId] = @Id;"
                Dim affected = Await conn.ExecuteAsync(sql, New With {.Id = id})
                Return affected > 0
            End Using
        End Function

        Public Async Function SearchStudentsAsync(query As String, classId As Integer?, status As String) As Task(Of IEnumerable(Of Student)) Implements IStudentRepository.SearchStudentsAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = "
                    SELECT [StudentId], [SchoolId], [StudentNumber], [Barcode], [IdentityDocumentType], [NationalId], [FirstName], [FatherName], [GrandFatherName], [GreatGrandFatherName], [FamilyName], [MotherName], [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Province], [District], [SubDistrict], [Area], [Mahalla], [Zuqaq], [HouseNumber], [NearestLandmark], [Address], [PhotoPath], [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType], [HasSpecialNeeds], [MedicalNotes], [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive] FROM [dbo].[Students]
                    WHERE [IsActive] = 1
                      AND (@Query IS NULL OR [FullName] LIKE '%' + @Query + '%' OR [StudentNumber] LIKE '%' + @Query + '%' OR [NationalId] LIKE '%' + @Query + '%')
                      AND (@ClassId IS NULL OR [CurrentClassId] = @ClassId)
                      AND (@Status IS NULL OR [Status] = @Status)
                    ORDER BY [StudentId] DESC;"
                Return Await conn.QueryAsync(Of Student)(sql, New With {.Query = query, .ClassId = classId, .Status = status})
            End Using
        End Function

        Public Async Function GetByStudentNumberAsync(studentNumber As String) As Task(Of Student) Implements IStudentRepository.GetByStudentNumberAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT [StudentId], [SchoolId], [StudentNumber], [Barcode], [IdentityDocumentType], [NationalId], [FirstName], [FatherName], [GrandFatherName], [GreatGrandFatherName], [FamilyName], [MotherName], [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Province], [District], [SubDistrict], [Area], [Mahalla], [Zuqaq], [HouseNumber], [NearestLandmark], [Address], [PhotoPath], [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType], [HasSpecialNeeds], [MedicalNotes], [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive] FROM [dbo].[Students] WHERE [StudentNumber] = @Number AND [IsActive] = 1;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Student)(sql, New With {.Number = studentNumber})
            End Using
        End Function

        Public Async Function GetByNationalIdAsync(nationalId As String) As Task(Of Student) Implements IStudentRepository.GetByNationalIdAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT [StudentId], [SchoolId], [StudentNumber], [Barcode], [IdentityDocumentType], [NationalId], [FirstName], [FatherName], [GrandFatherName], [GreatGrandFatherName], [FamilyName], [MotherName], [Gender], [DateOfBirth], [BirthPlace], [Nationality], [Phone], [Email], [Province], [District], [SubDistrict], [Area], [Mahalla], [Zuqaq], [HouseNumber], [NearestLandmark], [Address], [PhotoPath], [PrimaryParentId], [EmergencyContactName], [EmergencyContactPhone], [BloodType], [HasSpecialNeeds], [MedicalNotes], [CurrentClassId], [CurrentSectionId], [Status], [EnrollmentDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive] FROM [dbo].[Students] WHERE [NationalId] = @NatId AND [IsActive] = 1;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Student)(sql, New With {.NatId = nationalId})
            End Using
        End Function
    End Class
End Namespace
