Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Public Class TeacherService
    Private ReadOnly _teacherRepo As ITeacherRepository

    Public Sub New(teacherRepo As ITeacherRepository)
        _teacherRepo = teacherRepo
    End Sub

    Public Async Function AddTeacherAsync(teacher As Teacher) As Task(Of Integer)
        If String.IsNullOrWhiteSpace(teacher.FullName) Then
            Throw New ArgumentException("اسم المعلم مطلوب.")
        End If

        If String.IsNullOrWhiteSpace(teacher.Specialization) Then
            Throw New ArgumentException("تخصص المعلم مطلوب.")
        End If

        If String.IsNullOrWhiteSpace(teacher.EmployeeNumber) Then
            teacher.EmployeeNumber = $"EMP-{New Random().Next(1000, 9999)}"
        End If

        teacher.Status = "Active"
        teacher.CreatedAt = DateTime.Now
        teacher.IsDeleted = False

        Return Await _teacherRepo.AddAsync(teacher)
    End Function

    Public Async Function GetAllTeachersAsync() As Task(Of IEnumerable(Of Teacher))
        Return Await _teacherRepo.GetAllAsync()
    End Function

    Public Async Function UpdateTeacherAsync(teacher As Teacher) As Task(Of Boolean)
        Return Await _teacherRepo.UpdateAsync(teacher)
    End Function

    Public Async Function DeleteTeacherAsync(id As Integer) As Task(Of Boolean)
        Return Await _teacherRepo.DeleteAsync(id)
    End Function
End Class

Namespace Services
    Public Class TeacherService
        Inherits Global.SchoolManagement.Services.TeacherService

        Public Sub New(teacherRepo As ITeacherRepository)
            MyBase.New(teacherRepo)
        End Sub
    End Class
End Namespace

