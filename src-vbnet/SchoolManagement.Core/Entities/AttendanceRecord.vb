Imports System

Namespace Entities

    ''' <summary>
    ''' Represents the authoritative student daily attendance record.
    ''' Consolidates all properties across previous duplicate versions.
    ''' </summary>
    Public Class AttendanceRecord
        Public Property Id As Integer = 0

        Public Property AttendanceId As Long
            Get
                Return Id
            End Get
            Set(value As Long)
                Id = CInt(value)
            End Set
        End Property

        Public Property StudentId As Integer = 0
        Public Property StudentName As String = String.Empty
        Public Property StudentNumber As String = String.Empty

        Public Property SectionId As Integer = 0
        Public Property SectionName As String = String.Empty
        Public Property ClassId As Integer?
        Public Property ClassName As String = String.Empty
        Public Property GradeName As String = String.Empty

        Private _attendanceDate As DateTime = DateTime.Today
        Public Property AttendanceDate As DateTime
            Get
                Return _attendanceDate
            End Get
            Set(value As DateTime)
                _attendanceDate = value
            End Set
        End Property

        ''' <summary>
        ''' Cross-version alias for AttendanceDate
        ''' </summary>
        Public Property [Date] As DateTime
            Get
                Return _attendanceDate
            End Get
            Set(value As DateTime)
                _attendanceDate = value
            End Set
        End Property

        Public Property Status As String = "Present"         ' Present, Absent, Late, Excused / حاضر, غائب, متأخر, مجاز
        Public Property LateMinutes As Integer?
        Public Property ExcuseReason As String = String.Empty
        Public Property Notes As String = String.Empty
        Public Property ParentPhone As String = String.Empty
        Public Property AcademicYear As String = String.Empty

        Public ReadOnly Property IsPresent As Boolean
            Get
                Return Status = "Present" OrElse Status = "حاضر"
            End Get
        End Property

        Public ReadOnly Property IsAbsent As Boolean
            Get
                Return Status = "Absent" OrElse Status = "غائب"
            End Get
        End Property

        Public ReadOnly Property IsLate As Boolean
            Get
                Return Status = "Late" OrElse Status = "متأخر"
            End Get
        End Property

        Public ReadOnly Property IsExcused As Boolean
            Get
                Return Status = "Excused" OrElse Status = "مجاز"
            End Get
        End Property

        Public Property RecordedBy As String = String.Empty
        Public Property CreatedBy As String
            Get
                Return RecordedBy
            End Get
            Set(value As String)
                RecordedBy = value
            End Set
        End Property

        Public Property CreatedAt As DateTime = DateTime.UtcNow
        Public Property UpdatedAt As DateTime?
    End Class

    ''' <summary>
    ''' Alias for backwards compatibility if referenced as Attendance
    ''' </summary>
    Public Class Attendance
        Inherits AttendanceRecord
    End Class

End Namespace
