Imports System.Collections.Generic
Imports System.Data
Imports System.Threading.Tasks
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces
Imports SchoolManagement.Data.Infrastructure

Namespace Repositories
    Public Class TeacherRepository
        Implements ITeacherRepository

        Private Const SelectColumns As String = "SELECT [Id], [EmployeeNumber], [FullName], [Specialization], [AcademicDegree], [Phone], [Email], [AssignedSubjects], [AssignedClasses], [YearsOfExperience], [BasicSalary], [Allowances], [Status], [CreatedAt], [IsDeleted] FROM [dbo].[Teachers]"

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Teacher) Implements IRepository(Of Teacher).GetByIdAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = $"{SelectColumns} WHERE [Id] = @Id AND [IsDeleted] = 0;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Teacher)(sql, New With {.Id = id})
            End Using
        End Function

        Public Async Function GetAllAsync() As Task(Of IEnumerable(Of Teacher)) Implements IRepository(Of Teacher).GetAllAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = $"{SelectColumns} WHERE [IsDeleted] = 0 ORDER BY [FullName] ASC;"
                Return Await conn.QueryAsync(Of Teacher)(sql)
            End Using
        End Function

        Public Async Function AddAsync(entity As Teacher) As Task(Of Integer) Implements IRepository(Of Teacher).AddAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    INSERT INTO [dbo].[Teachers] (
                        [EmployeeNumber], [FullName], [Specialization], [AcademicDegree],
                        [Phone], [Email], [AssignedSubjects], [AssignedClasses],
                        [YearsOfExperience], [BasicSalary], [Allowances], [Status], [CreatedAt], [IsDeleted]
                    ) VALUES (
                        @EmployeeNumber, @FullName, @Specialization, @AcademicDegree,
                        @Phone, @Email, @AssignedSubjects, @AssignedClasses,
                        @YearsOfExperience, @BasicSalary, @Allowances, @Status, GETDATE(), 0
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"
                Return Await conn.ExecuteScalarAsync(Of Integer)(sql, entity)
            End Using
        End Function

        Public Async Function UpdateAsync(entity As Teacher) As Task(Of Boolean) Implements IRepository(Of Teacher).UpdateAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    UPDATE [dbo].[Teachers] SET
                        [FullName] = @FullName,
                        [Specialization] = @Specialization,
                        [AcademicDegree] = @AcademicDegree,
                        [Phone] = @Phone,
                        [Email] = @Email,
                        [AssignedSubjects] = @AssignedSubjects,
                        [AssignedClasses] = @AssignedClasses,
                        [YearsOfExperience] = @YearsOfExperience,
                        [BasicSalary] = @BasicSalary,
                        [Allowances] = @Allowances,
                        [Status] = @Status
                    WHERE [Id] = @Id;"
                Dim affected = Await conn.ExecuteAsync(sql, entity)
                Return affected > 0
            End Using
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IRepository(Of Teacher).DeleteAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "UPDATE [dbo].[Teachers] SET [IsDeleted] = 1 WHERE [Id] = @Id;"
                Dim affected = Await conn.ExecuteAsync(sql, New With {.Id = id})
                Return affected > 0
            End Using
        End Function

        Public Async Function GetByEmployeeNumberAsync(employeeNumber As String) As Task(Of Teacher) Implements ITeacherRepository.GetByEmployeeNumberAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = $"{SelectColumns} WHERE [EmployeeNumber] = @EmployeeNumber AND [IsDeleted] = 0;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Teacher)(sql, New With {.EmployeeNumber = employeeNumber})
            End Using
        End Function

        Public Async Function GetBySpecializationAsync(specialization As String) As Task(Of IEnumerable(Of Teacher)) Implements ITeacherRepository.GetBySpecializationAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = $"{SelectColumns} WHERE [Specialization] LIKE @Spec AND [IsDeleted] = 0;"
                Return Await conn.QueryAsync(Of Teacher)(sql, New With {.Spec = $"%{specialization}%"})
            End Using
        End Function
    End Class
End Namespace
