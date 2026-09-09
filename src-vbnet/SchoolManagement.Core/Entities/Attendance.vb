Imports System

Namespace Entities

    ''' <summary>
    ''' Represents an individual student daily attendance status record.
    ''' </summary>
    Public Class AttendanceRecord
        Public Property Id As Integer

        Public Property AttendanceId As Long
            Get
                Return Id
            End Get
            Set(value As Long)
                Id = CInt(value)
            End Set
        End Property

        Public Property StudentId As Integer
        Public Property StudentName As String = String.Empty
        Public Property StudentNumber As String = String.Empty
        Public Property SectionId As Integer
        Public Property SectionName As String = String.Empty
        Public Property AttendanceDate As DateTime = DateTime.Today
        Public Property Status As String = "Present"         ' Present, Absent, Late, Excused
        Public Property LateMinutes As Integer?
        Public Property ExcuseReason As String = String.Empty
        Public Property Notes As String = String.Empty
        Public Property RecordedBy As String = String.Empty
        Public Property CreatedAt As DateTime = DateTime.UtcNow
    End Class

End Namespace
