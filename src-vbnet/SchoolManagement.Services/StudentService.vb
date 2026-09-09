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
            ' قواعد التحقق وفق النظام العراقي المعتمد
            If String.IsNullOrWhiteSpace(student.FirstName) OrElse String.IsNullOrWhiteSpace(student.FatherName) OrElse String.IsNullOrWhiteSpace(student.GrandFatherName) Then
                Throw New ArgumentException("الاسم الثلاثي للطالب (الاسم، الأب، الجد) إلزامي في جمهورية العراق.")
            End If

            ' التحقق من وثيقة الهوية الرسمية (البطاقة الوطنية 12 رقماً / هوية الأحوال / جواز السفر)
            Dim idValidation = IraqiValidationService.ValidateIdentityDocument(student.NationalId, student.IdentityDocumentType)
            If Not idValidation.IsValid Then
                Throw New ArgumentException(idValidation.ErrorMessage)
            End If

            ' التحقق من هاتف الطالب أو ولي الأمر إذا تم إدخاله
            If Not String.IsNullOrWhiteSpace(student.Phone) Then
                Dim phoneValidation = IraqiValidationService.ValidatePhone(student.Phone)
                If Not phoneValidation.IsValid Then
                    Throw New ArgumentException(phoneValidation.ErrorMessage)
                End If
                student.Phone = phoneValidation.CleanPhone
            End If

            ' فحص عدم التكرار
            Dim existing = Await _studentRepo.GetByNationalIdAsync(student.NationalId)
            If existing IsNot Nothing Then
                Throw New InvalidOperationException($"الطالب مسجل مسبقاً بنفس رقم الهوية ({student.NationalId}).")
            End If

            ' إنشاء الرقم الأكاديمي والباركود تلقائياً
            If String.IsNullOrWhiteSpace(student.StudentNumber) Then
                student.StudentNumber = $"STD-{DateTime.Now.Year}-{New Random().Next(1000, 9999)}"
            End If
            If String.IsNullOrWhiteSpace(student.Barcode) Then
                student.Barcode = $"62810010{New Random().Next(1000, 9999)}"
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
