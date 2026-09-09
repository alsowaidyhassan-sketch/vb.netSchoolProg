Imports System

Namespace Entities

    ''' <summary>
    ''' Represents an individual student daily attendance status record.
    ''' </summary>
    Public Class AttendanceRecord
        Public Property Id As Integer
        Public Property StudentId As Integer
        Public Property StudentName As String
        Public Property StudentNumber As String
        Public Property SectionId As Integer
        Public Property SectionName As String
        Public Property Date As DateTime
        Public Property Status As String         ' Present, Absent, Late, Excused
        Public Property LateMinutes As Integer?
        Public Property Notes As String
        Public Property CreatedAt As DateTime
    End Class

End Namespace
