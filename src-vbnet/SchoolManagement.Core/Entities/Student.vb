Namespace Entities
    Public Class Student
        Public Property StudentId As Integer
        Public Property SchoolId As Integer
        Public Property StudentNumber As String = String.Empty
        Public Property Barcode As String = String.Empty

        ' وثيقة الهوية الرسمية في العراق
        Public Property IdentityDocumentType As String = "البطاقة الوطنية الموحدة" ' البطاقة الوطنية الموحدة / هوية الأحوال المدنية / شهادة الجنسية العراقية / جواز السفر العراقي
        Public Property NationalId As String = String.Empty

        ' الاسم الخماسي العراقي واسم الأم
        Public Property FirstName As String = String.Empty
        Public Property FatherName As String = String.Empty
        Public Property GrandFatherName As String = String.Empty
        Public Property GreatGrandFatherName As String = String.Empty
        Public Property FamilyName As String = String.Empty ' اللقب أو العشيرة
        Public Property MotherName As String = String.Empty ' اسم الأم الثلاثي

        ' للتوافق مع الحقول السابقة
        Public Property SecondName As String
            Get
                Return FatherName
            End Get
            Set(value As String)
                FatherName = value
            End Set
        End Property

        Public Property ThirdName As String
            Get
                Return GrandFatherName
            End Get
            Set(value As String)
                GrandFatherName = value
            End Set
        End Property

        Public Property LastName As String
            Get
                Return If(Not String.IsNullOrWhiteSpace(FamilyName), FamilyName, GrandFatherName)
            End Get
            Set(value As String)
                FamilyName = value
            End Set
        End Property

        Public Property FullName As String
            Get
                Dim parts = New List(Of String) From {FirstName, FatherName, GrandFatherName, GreatGrandFatherName, FamilyName}
                Return String.Join(" ", parts.Where(Function(p) Not String.IsNullOrWhiteSpace(p))).Trim()
            End Get
            Set(value As String)
                ' can be set explicitly or computed
            End Set
        End Property

        Public Property Gender As String = "ذكر"
        Public Property DateOfBirth As DateTime
        Public Property BirthPlace As String = "بغداد"
        Public Property Nationality As String = "عراقي"

        ' أرقام الهواتف العراقية 07XXXXXXXXX
        Public Property Phone As String = String.Empty
        Public Property Email As String = String.Empty

        ' العنوان السكني العراقي الدقيق
        Public Property Province As String = "بغداد"
        Public Property District As String = String.Empty ' القضاء
        Public Property SubDistrict As String = String.Empty ' الناحية
        Public Property Area As String = String.Empty ' الحي أو المنطقة
        Public Property Mahalla As String = String.Empty ' المحلة
        Public Property Zuqaq As String = String.Empty ' الزقاق
        Public Property HouseNumber As String = String.Empty ' رقم الدار
        Public Property NearestLandmark As String = String.Empty ' أقرب نقطة دالة

        Public ReadOnly Property IraqiAddress As String
            Get
                Return $"{Province} - {District} - {Area} - محلة {Mahalla} - زقاق {Zuqaq} - دار {HouseNumber} ({NearestLandmark})".Trim()
            End Get
        End Property

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
End Namespace
