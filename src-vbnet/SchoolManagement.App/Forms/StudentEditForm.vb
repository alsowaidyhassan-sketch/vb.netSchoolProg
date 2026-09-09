Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Services

Namespace Forms
    ''' <summary>
    ''' نموذج إضافة وتعديل بيانات الطالب وفق المعايير الرسمية لجمهورية العراق
    ''' متوافق بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class StudentEditForm
        Inherits Form

        Public Property CurrentStudent As Student

        Public Sub New()
            InitializeComponent()
            CurrentStudent = New Student()

            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            LoadDefaults()
            WireEvents()
        End Sub

        Public Sub New(studentToEdit As Student)
            InitializeComponent()
            CurrentStudent = studentToEdit

            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            LoadDefaults()
            BindStudentData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnSave.Click, AddressOf BtnSave_Click
            AddHandler btnCancel.Click, Sub(s, e) Me.Close()
            AddHandler txtParentPhone.TextChanged, AddressOf OnParentPhoneChanged
        End Sub

        Private Sub LoadDefaults()
            cboProvince.Items.Clear()
            cboProvince.Items.AddRange(IraqiValidationService.IraqiProvinces.ToArray())
            cboProvince.SelectedItem = "بغداد"

            cboIssuingProvince.Items.Clear()
            cboIssuingProvince.Items.AddRange(IraqiValidationService.IraqiProvinces.ToArray())
            cboIssuingProvince.SelectedItem = "بغداد"

            cboIdentityType.SelectedItem = "البطاقة الوطنية الموحدة"
            cboClass.SelectedIndex = 0
            cboSection.SelectedIndex = 0
            cboBloodType.SelectedIndex = 0
        End Sub

        Private Sub OnParentPhoneChanged(sender As Object, e As EventArgs)
            Dim res = IraqiValidationService.ValidatePhone(txtParentPhone.Text)
            If res.IsValid Then
                lblParentCarrier.Text = $"شبكة: {res.Carrier} ✔"
                lblParentCarrier.ForeColor = Color.FromArgb(52, 211, 153)
            Else
                lblParentCarrier.Text = "تنسيق عراقي: 07XXXXXXXXX"
                lblParentCarrier.ForeColor = Color.FromArgb(148, 163, 184)
            End If
        End Sub

        Private Sub BindStudentData()
            If CurrentStudent Is Nothing Then Return
            txtFirstName.Text = CurrentStudent.FirstName
            txtFatherName.Text = CurrentStudent.FatherName
            txtGrandFatherName.Text = CurrentStudent.GrandFatherName
            txtGreatGrandFatherName.Text = CurrentStudent.GreatGrandFatherName
            txtFamilyName.Text = CurrentStudent.FamilyName
            txtMotherName.Text = CurrentStudent.MotherName
            txtNationalId.Text = CurrentStudent.NationalId
            cboIdentityType.SelectedItem = CurrentStudent.IdentityDocumentType
            cboProvince.SelectedItem = If(String.IsNullOrWhiteSpace(CurrentStudent.Province), "بغداد", CurrentStudent.Province)
            txtDistrict.Text = CurrentStudent.District
            txtSubDistrict.Text = CurrentStudent.SubDistrict
            txtArea.Text = CurrentStudent.Area
            txtMahalla.Text = CurrentStudent.Mahalla
            txtZuqaq.Text = CurrentStudent.Zuqaq
            txtHouseNumber.Text = CurrentStudent.HouseNumber
            txtLandmark.Text = CurrentStudent.NearestLandmark
            txtParentPhone.Text = CurrentStudent.EmergencyContactPhone
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs)
            ' تحقق الأسماء الإلزامية
            If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse String.IsNullOrWhiteSpace(txtFatherName.Text) OrElse String.IsNullOrWhiteSpace(txtGrandFatherName.Text) Then
                MessageBox.Show("يرجى إدخال الاسم الثلاثي للطالب (الاسم، اسم الأب، اسم الجد) كحد أدنى إلزامي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFirstName.Focus()
                Return
            End If

            ' تحقق الهوية العراقية
            Dim idRes = IraqiValidationService.ValidateIdentityDocument(txtNationalId.Text, cboIdentityType.Text)
            If Not idRes.IsValid Then
                MessageBox.Show(idRes.ErrorMessage, "خطأ في رقم الوثيقة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNationalId.Focus()
                Return
            End If

            ' تحقق هاتف ولي الأمر العراقي
            Dim phoneRes = IraqiValidationService.ValidatePhone(txtParentPhone.Text)
            If Not phoneRes.IsValid Then
                MessageBox.Show(phoneRes.ErrorMessage, "خطأ في رقم هاتف ولي الأمر", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtParentPhone.Focus()
                Return
            End If

            ' تعيين البيانات إلى الكيان
            CurrentStudent.FirstName = txtFirstName.Text.Trim()
            CurrentStudent.FatherName = txtFatherName.Text.Trim()
            CurrentStudent.GrandFatherName = txtGrandFatherName.Text.Trim()
            CurrentStudent.GreatGrandFatherName = txtGreatGrandFatherName.Text.Trim()
            CurrentStudent.FamilyName = txtFamilyName.Text.Trim()
            CurrentStudent.MotherName = txtMotherName.Text.Trim()
            CurrentStudent.IdentityDocumentType = cboIdentityType.Text
            CurrentStudent.NationalId = txtNationalId.Text.Trim()
            CurrentStudent.Nationality = "عراقي"
            CurrentStudent.Province = cboProvince.Text
            CurrentStudent.District = txtDistrict.Text.Trim()
            CurrentStudent.SubDistrict = txtSubDistrict.Text.Trim()
            CurrentStudent.Area = txtArea.Text.Trim()
            CurrentStudent.Mahalla = txtMahalla.Text.Trim()
            CurrentStudent.Zuqaq = txtZuqaq.Text.Trim()
            CurrentStudent.HouseNumber = txtHouseNumber.Text.Trim()
            CurrentStudent.NearestLandmark = txtLandmark.Text.Trim()
            CurrentStudent.EmergencyContactPhone = phoneRes.CleanPhone
            CurrentStudent.Phone = phoneRes.CleanPhone
            CurrentStudent.BloodType = cboBloodType.Text
            CurrentStudent.DateOfBirth = dtpBirthDate.Value

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub
    End Class
End Namespace
