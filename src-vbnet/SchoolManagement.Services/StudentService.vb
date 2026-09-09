Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Services
    Public Class StudentService
        Private ReadOnly _studentRepo As IStudentRepository

        Public Sub New(studentRepo As IStudentRepository)
            _studentRepo = studentRepo
        End Sub

        Public Async Function RegisterStudentAsync(student As Student) As Task(Of Integer)
            ' Validation rules
            If String.IsNullOrWhiteSpace(student.FirstName) OrElse String.IsNullOrWhiteSpace(student.LastName) Then
                Throw New ArgumentException("اسم الطالب الأول واسم العائلة مطلوبان.")
            End If

            If String.IsNullOrWhiteSpace(student.NationalId) OrElse student.NationalId.Length < 10 Then
                Throw New ArgumentException("رقم الهوية الوطنية غير صحيح أو أقل من 10 أرقام.")
            End If

            ' Check duplication
            Dim existing = Await _studentRepo.GetByNationalIdAsync(student.NationalId)
            If existing IsNot Nothing Then
                Throw New InvalidOperationException($"الطالب مسجل مسبقاً بنفس رقم الهوية ({student.NationalId}).")
            End If

            ' Auto generate student number if not provided
            If String.IsNullOrWhiteSpace(student.StudentNumber) Then
                student.StudentNumber = $"STD-{DateTime.Now.Year}-{New Random().Next(1000, 9999)}"
            End If

            Return Await _studentRepo.AddAsync(student)
        End Function

        Public Async Function SearchAsync(searchTerm As String, classId As Integer?, status As String) As Task(Of IEnumerable(Of Student))
            Return Await _studentRepo.SearchStudentsAsync(searchTerm, classId, status)
        End Function

        Public Async Function GetStudentDetailsAsync(id As Integer) As Task(Of Student)
            Return Await _studentRepo.GetByIdAsync(id)
        End Function
    End Class
End Namespace
