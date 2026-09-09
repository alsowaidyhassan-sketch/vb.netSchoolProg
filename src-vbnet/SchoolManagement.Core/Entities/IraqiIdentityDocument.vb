Imports System

Namespace Entities
    ''' <summary>
    ''' كيان الوثائق الثبوتية الرسمية في جمهورية العراق
    ''' يدعم: البطاقة الوطنية الموحدة (12 رقماً)، هوية الأحوال المدنية، شهادة الجنسية العراقية، وجواز السفر
    ''' </summary>
    Public Class IraqiIdentityDocument
        Public Property DocumentId As Integer
        Public Property OwnerType As String = "Student" ' Student / Parent / Staff
        Public Property OwnerId As Integer
        Public Property DocumentType As String = "البطاقة الوطنية الموحدة"
        Public Property DocumentNumber As String = String.Empty
        Public Property IssuingAuthority As String = String.Empty ' مثال: دائرة أحوال الكرخ / الكاظمية
        Public Property IssuingProvince As String = "بغداد"
        Public Property IssueDate As DateTime?
        Public Property ExpiryDate As DateTime?
        Public Property PageNumber As String = String.Empty ' الصحيفة
        Public Property RecordNumber As String = String.Empty ' السجل
        Public Property FamilyRecordNumber As String = String.Empty ' الرقم العائلي
        Public Property DocumentScanPath As String = String.Empty
        Public Property CreatedAt As DateTime = DateTime.UtcNow
        Public Property CreatedBy As String = "System"
    End Class
End Namespace
