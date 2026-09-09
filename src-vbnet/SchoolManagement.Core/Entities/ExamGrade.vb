Imports System

Namespace Entities

    Public Class ExamRecord
        Public Property Id As Integer
        Public Property ExamName As String
        Public Property ExamType As String
        Public Property SubjectName As String
        Public Property ClassName As String
        Public Property ExamDate As DateTime
        Public Property MaxScore As Decimal
        Public Property PassingScore As Decimal
    End Class

    Public Class StudentGrade
        Public Property Id As Integer
        Public Property StudentId As Integer
        Public Property StudentName As String
        Public Property StudentNumber As String
        Public Property SubjectName As String
        Public Property MidtermScore As Decimal
        Public Property QuizScore As Decimal
        Public Property HomeworkScore As Decimal
        Public Property FinalScore As Decimal
        Public Property TotalScore As Decimal
        Public Property Percentage As Decimal
        Public Property GradeLetter As String
        Public Property IsPassed As Boolean
    End Class

End Namespace
