Imports System

Namespace Entities

    ''' <summary>
    ''' Represents a teacher or academic faculty member.
    ''' </summary>
    Public Class Teacher
        Public Property Id As Integer

        Public Property TeacherId As Integer
            Get
                Return Id
            End Get
            Set(value As Integer)
                Id = value
            End Set
        End Property

        Public Property StaffId As Integer
        Public Property EmployeeNumber As String
        Public Property FullName As String
        Public Property Specialization As String
        Public Property AcademicDegree As String
        Public Property Phone As String
        Public Property Email As String
        Public Property AssignedSubjects As String
        Public Property AssignedClasses As String
        Public Property YearsOfExperience As Integer
        Public Property BasicSalary As Decimal
        Public Property Allowances As Decimal
        Public Property Status As String = "Active"
        Public Property CreatedAt As DateTime = DateTime.UtcNow
        Public Property IsDeleted As Boolean = False
        Public Property IsActive As Boolean = True

        Public ReadOnly Property TotalSalary As Decimal
            Get
                Return BasicSalary + Allowances
            End Get
        End Property
    End Class

End Namespace
