Namespace Entities
    Public Class Student
        Public Property StudentId As Integer
        Public Property SchoolId As Integer
        Public Property StudentNumber As String = String.Empty
        Public Property Barcode As String = String.Empty
        Public Property NationalId As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property SecondName As String = String.Empty
        Public Property ThirdName As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property FullName As String = String.Empty
        Public Property Gender As String = "ذكر"
        Public Property DateOfBirth As DateTime
        Public Property BirthPlace As String = String.Empty
        Public Property Nationality As String = "سعودي"
        Public Property Phone As String = String.Empty
        Public Property Email As String = String.Empty
        Public Property Address As String = String.Empty
        Public Property PhotoPath As String = String.Empty
        Public Property PrimaryParentId As Integer?
        Public Property EmergencyContactName As String = String.Empty
        Public Property EmergencyContactPhone As String = String.Empty
        Public Property BloodType As String = "O+"
        Public Property HasSpecialNeeds As Boolean = False
        Public Property MedicalNotes As String = String.Empty
        Public Property CurrentClassId As Integer?
        Public Property CurrentSectionId As Integer?
        Public Property Status As String = "Active"
        Public Property EnrollmentDate As DateTime = DateTime.Today
        Public Property CreatedAt As DateTime = DateTime.UtcNow
        Public Property UpdatedAt As DateTime?
        Public Property CreatedBy As String = "Admin"
        Public Property UpdatedBy As String = String.Empty
        Public Property IsActive As Boolean = True
    End Class

    Public Class Teacher
        Public Property TeacherId As Integer
        Public Property StaffId As Integer
        Public Property FullName As String = String.Empty
        Public Property Specialization As String = String.Empty
        Public Property AcademicDegree As String = String.Empty
        Public Property Phone As String = String.Empty
        Public Property Email As String = String.Empty
        Public Property YearsOfExperience As Integer
        Public Property BasicSalary As Decimal
        Public Property IsActive As Boolean = True
    End Class

    Public Class AttendanceRecord
        Public Property AttendanceId As Long
        Public Property StudentId As Integer
        Public Property StudentName As String = String.Empty
        Public Property SectionId As Integer
        Public Property AttendanceDate As DateTime
        Public Property Status As String = "Present" ' Present / Absent / Late / Excused
        Public Property LateMinutes As Integer
        Public Property ExcuseReason As String = String.Empty
        Public Property RecordedBy As String = String.Empty
    End Class
End Namespace
