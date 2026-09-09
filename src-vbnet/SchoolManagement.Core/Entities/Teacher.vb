Imports System
Imports System.Collections.Generic
Imports System.Linq

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

        Public Property StaffId As String = String.Empty
        Public Property EmployeeNumber As String = String.Empty

        Public Property FirstName As String = String.Empty
        Public Property FatherName As String = String.Empty
        Public Property FamilyName As String = String.Empty
        Public Property NationalId As String = String.Empty

        Private _fullName As String = String.Empty
        Public Property FullName As String
            Get
                If Not String.IsNullOrWhiteSpace(_fullName) Then
                    Return _fullName
                End If
                Dim parts = New String() {FirstName, FatherName, FamilyName}
                Dim joined = String.Join(" ", parts.Where(Function(p) Not String.IsNullOrWhiteSpace(p))).Trim()
                Return If(String.IsNullOrWhiteSpace(joined), "مدرس", joined)
            End Get
            Set(value As String)
                _fullName = value
            End Set
        End Property

        Public Property Specialization As String = String.Empty
        Public Property AcademicDegree As String = "بكالوريوس"
        Public Property Phone As String = String.Empty
        Public Property Email As String = String.Empty
        Public Property AssignedSubjects As String = String.Empty
        Public Property AssignedClasses As String = String.Empty
        Public Property YearsOfExperience As Integer = 0
        Public Property WeeklyQuotaHours As Integer = 18
        Public Property BasicSalary As Decimal = 0D
        Public Property Allowances As Decimal = 0D
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
