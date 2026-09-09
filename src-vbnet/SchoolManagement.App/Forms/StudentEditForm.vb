Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Services

Namespace Forms
    ''' <summary>
    ''' نموذج إضافة وتعديل بيانات الطالب وفق المعايير الرسمية لجمهورية العراق
    ''' متوافق بالكامل مع Visual Studio Designer ويدعم جميع الحقول الإلزامية
    ''' </summary>
    Public Class StudentEditForm
        Inherits Form

        ' الحقول والتحكم
        Public Property CurrentStudent As Student

        Private pnlHeader As Panel
        Private lblTitle As Label
        Private pnlActions As Panel
        Private btnSave As Button
        Private btnCancel As Button
        Private pnlContent As Panel

        ' مجموعة الاسم الخماسي
        Private grpNames As GroupBox
        Private txtFirstName As TextBox
        Private txtFatherName As TextBox
        Private txtGrandFatherName As TextBox
        Private txtGreatGrandFatherName As TextBox
        Private txtFamilyName As TextBox
        Private txtMotherName As TextBox

        ' مجموعة الهوية والوثائق العراقية
        Private grpIdentity As GroupBox
        Private cboIdentityType As ComboBox
        Private txtNationalId As TextBox
        Private txtIssuingAuthority As TextBox
        Private cboIssuingProvince As ComboBox
        Private txtPageNumber As TextBox
        Private txtRecordNumber As TextBox

        ' مجموعة الاتصال والعنوان العراقي
        Private grpAddressAndContact As GroupBox
        Private txtParentPhone As TextBox
        Private txtStudentPhone As TextBox
        Private lblParentCarrier As Label
        Private cboProvince As ComboBox
        Private txtDistrict As TextBox
        Private txtSubDistrict As TextBox
        Private txtArea As TextBox
        Private txtMahalla As TextBox
        Private txtZuqaq As TextBox
        Private txtHouseNumber As TextBox
        Private txtLandmark As TextBox

        ' مجموعة البيانات الأكاديمية
        Private grpAcademic As GroupBox
        Private cboClass As ComboBox
        Private cboSection As ComboBox
        Private cboBloodType As ComboBox
        Private dtpBirthDate As DateTimePicker

        Public Sub New()
            InitializeComponent()
            CurrentStudent = New Student()
            LoadDefaults()
        End Sub

        Public Sub New(studentToEdit As Student)
            InitializeComponent()
            CurrentStudent = studentToEdit
            LoadDefaults()
            BindStudentData()
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "بيانات الطالب - المعايير العراقية الرسمية"
            Me.Size = New Size(920, 720)
            Me.MinimumSize = New Size(850, 650)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            Me.BackColor = Color.FromArgb(15, 23, 42)
            Me.ForeColor = Color.FromArgb(241, 245, 249)

            ' 1. Header
            pnlHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 55,
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(15, 12, 15, 12)
            }
            lblTitle = New Label With {
                .Text = "🇮🇶 تسجيل طالب جديد - المعايير الرسمية لجمهورية العراق (الاسم الخماسي، الهوية، العنوان)",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(96, 165, 250),
                .Dock = DockStyle.Fill
            }
            pnlHeader.Controls.Add(lblTitle)

            ' 2. Bottom Actions
            pnlActions = New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 60,
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(15, 10, 15, 10)
            }
            btnSave = New Button With {
                .Text = "💾 حفظ بيانات الطالب",
                .Size = New Size(160, 40),
                .Location = New Point(15, 10),
                .BackColor = Color.FromArgb(37, 99, 235),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Cursor = Cursors.Hand
            }
            btnSave.FlatAppearance.BorderSize = 0
            AddHandler btnSave.Click, AddressOf BtnSave_Click

            btnCancel = New Button With {
                .Text = "إلغاء",
                .Size = New Size(100, 40),
                .Location = New Point(185, 10),
                .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .FlatStyle = FlatStyle.Flat,
                .Cursor = Cursors.Hand
            }
            btnCancel.FlatAppearance.BorderSize = 0
            AddHandler btnCancel.Click, Sub(s, e) Me.Close()

            pnlActions.Controls.Add(btnSave)
            pnlActions.Controls.Add(btnCancel)

            ' 3. Scrollable Content
            pnlContent = New Panel With {
                .Dock = DockStyle.Fill,
                .AutoScroll = True,
                .Padding = New Padding(15)
            }

            BuildNameGroup()
            BuildIdentityGroup()
            BuildAddressAndContactGroup()
            BuildAcademicGroup()

            pnlContent.Controls.Add(grpAcademic)
            pnlContent.Controls.Add(grpAddressAndContact)
            pnlContent.Controls.Add(grpIdentity)
            pnlContent.Controls.Add(grpNames)

            Me.Controls.Add(pnlContent)
            Me.Controls.Add(pnlActions)
            Me.Controls.Add(pnlHeader)
        End Sub

        Private Sub BuildNameGroup()
            grpNames = New GroupBox With {
                .Text = "1. الاسم الخماسي العراقي واسم الأم",
                .Dock = DockStyle.Top,
                .Height = 150,
                .ForeColor = Color.FromArgb(147, 197, 253),
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Padding = New Padding(12)
            }

            Dim pnl = New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 3,
                .RowCount = 4
            }
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))

            txtFirstName = CreateStyledTextBox("الاسم الأول للطالب (مثال: علي)")
            txtFatherName = CreateStyledTextBox("اسم الأب (مثال: حسين)")
            txtGrandFatherName = CreateStyledTextBox("اسم الجد (مثال: كاظم)")
            txtGreatGrandFatherName = CreateStyledTextBox("اسم الجد الرابع (مثال: حسن)")
            txtFamilyName = CreateStyledTextBox("اللقب أو العشيرة (مثال: الزبيدي)")
            txtMotherName = CreateStyledTextBox("اسم الأم الثلاثي (مثال: فاطمة جاسم محمد)")

            pnl.Controls.Add(CreateFieldContainer("الاسم الأول *", txtFirstName), 0, 0)
            pnl.Controls.Add(CreateFieldContainer("اسم الأب *", txtFatherName), 1, 0)
            pnl.Controls.Add(CreateFieldContainer("اسم الجد *", txtGrandFatherName), 2, 0)
            pnl.Controls.Add(CreateFieldContainer("اسم الجد الرابع", txtGreatGrandFatherName), 0, 1)
            pnl.Controls.Add(CreateFieldContainer("اللقب / العشيرة", txtFamilyName), 1, 1)
            pnl.Controls.Add(CreateFieldContainer("اسم الأم الثلاثي", txtMotherName), 2, 1)

            grpNames.Controls.Add(pnl)
        End Sub

        Private Sub BuildIdentityGroup()
            grpIdentity = New GroupBox With {
                .Text = "2. وثيقة الهوية الرسمية (البطاقة الوطنية 12 رقماً / هوية الأحوال / جواز السفر)",
                .Dock = DockStyle.Top,
                .Height = 150,
                .ForeColor = Color.FromArgb(147, 197, 253),
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Padding = New Padding(12)
            }

            Dim pnl = New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 3,
                .RowCount = 2
            }
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))

            cboIdentityType = CreateStyledComboBox(New String() {
                "البطاقة الوطنية الموحدة",
                "هوية الأحوال المدنية",
                "شهادة الجنسية العراقية",
                "جواز السفر العراقي"
            })
            txtNationalId = CreateStyledTextBox("12 رقماً للبطاقة الوطنية (مثال: 200812345678)")
            txtIssuingAuthority = CreateStyledTextBox("مثال: دائرة أحوال الكرخ")
            cboIssuingProvince = CreateStyledComboBox(IraqiValidationService.IraqiProvinces.ToArray())
            txtPageNumber = CreateStyledTextBox("رقم الصحيفة")
            txtRecordNumber = CreateStyledTextBox("رقم السجل")

            pnl.Controls.Add(CreateFieldContainer("نوع الوثيقة الثبوتية *", cboIdentityType), 0, 0)
            pnl.Controls.Add(CreateFieldContainer("رقم الوثيقة / الرقم الوطني (12 رقم) *", txtNationalId), 1, 0)
            pnl.Controls.Add(CreateFieldContainer("جهة الإصدار / الدائرة", txtIssuingAuthority), 2, 0)
            pnl.Controls.Add(CreateFieldContainer("محافظة الإصدار", cboIssuingProvince), 0, 1)
            pnl.Controls.Add(CreateFieldContainer("الصحيفة (لهوية الأحوال)", txtPageNumber), 1, 1)
            pnl.Controls.Add(CreateFieldContainer("السجل (لهوية الأحوال)", txtRecordNumber), 2, 1)

            grpIdentity.Controls.Add(pnl)
        End Sub

        Private Sub BuildAddressAndContactGroup()
            grpAddressAndContact = New GroupBox With {
                .Text = "3. أرقام الاتصال والعنوان السكني التفصيلي داخل العراق",
                .Dock = DockStyle.Top,
                .Height = 220,
                .ForeColor = Color.FromArgb(147, 197, 253),
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Padding = New Padding(12)
            }

            Dim pnl = New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 4,
                .RowCount = 3
            }
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))

            txtParentPhone = CreateStyledTextBox("07801234567")
            AddHandler txtParentPhone.TextChanged, AddressOf OnParentPhoneChanged
            lblParentCarrier = New Label With {
                .Text = "زين العراق / آسيا سيل / كورك",
                .ForeColor = Color.FromArgb(52, 211, 153),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .Dock = DockStyle.Bottom,
                .Height = 18
            }

            txtStudentPhone = CreateStyledTextBox("07701234567")
            cboProvince = CreateStyledComboBox(IraqiValidationService.IraqiProvinces.ToArray())
            txtDistrict = CreateStyledTextBox("مثال: الكرخ / الرصافة")
            txtSubDistrict = CreateStyledTextBox("مثال: المنصور")
            txtArea = CreateStyledTextBox("مثال: حي اليرموك")
            txtMahalla = CreateStyledTextBox("مثال: 612")
            txtZuqaq = CreateStyledTextBox("مثال: 14")
            txtHouseNumber = CreateStyledTextBox("مثال: 25")
            txtLandmark = CreateStyledTextBox("مثال: قرب جامع المأمون")

            Dim parentPhoneContainer = CreateFieldContainer("هاتف ولي الأمر (واتساب) *", txtParentPhone)
            parentPhoneContainer.Controls.Add(lblParentCarrier)

            pnl.Controls.Add(parentPhoneContainer, 0, 0)
            pnl.Controls.Add(CreateFieldContainer("هاتف الطالب (اختياري)", txtStudentPhone), 1, 0)
            pnl.Controls.Add(CreateFieldContainer("المحافظة *", cboProvince), 2, 0)
            pnl.Controls.Add(CreateFieldContainer("القضاء", txtDistrict), 3, 0)

            pnl.Controls.Add(CreateFieldContainer("الناحية", txtSubDistrict), 0, 1)
            pnl.Controls.Add(CreateFieldContainer("الحي / المنطقة", txtArea), 1, 1)
            pnl.Controls.Add(CreateFieldContainer("المحلة", txtMahalla), 2, 1)
            pnl.Controls.Add(CreateFieldContainer("الزقاق", txtZuqaq), 3, 1)

            pnl.Controls.Add(CreateFieldContainer("رقم الدار", txtHouseNumber), 0, 2)
            pnl.Controls.Add(CreateFieldContainer("أقرب نقطة دالة", txtLandmark), 1, 2)

            grpAddressAndContact.Controls.Add(pnl)
        End Sub

        Private Sub BuildAcademicGroup()
            grpAcademic = New GroupBox With {
                .Text = "4. البيانات الأكاديمية وفصيلة الدم",
                .Dock = DockStyle.Top,
                .Height = 110,
                .ForeColor = Color.FromArgb(147, 197, 253),
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .Padding = New Padding(12)
            }

            Dim pnl = New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 4,
                .RowCount = 1
            }
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            pnl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))

            cboClass = CreateStyledComboBox(New String() {"الأول متوسط", "الثاني متوسط", "الثالث متوسط", "الرابع العلمي", "الخامس العلمي", "السادس العلمي"})
            cboSection = CreateStyledComboBox(New String() {"شعبة أ", "شعبة ب", "شعبة ج"})
            cboBloodType = CreateStyledComboBox(New String() {"O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-"})
            dtpBirthDate = New DateTimePicker With {
                .Font = New Font("Segoe UI", 9.5F),
                .Format = DateTimePickerFormat.Short,
                .Dock = DockStyle.Top
            }

            pnl.Controls.Add(CreateFieldContainer("الصف الدراسي", cboClass), 0, 0)
            pnl.Controls.Add(CreateFieldContainer("الشعبة", cboSection), 1, 0)
            pnl.Controls.Add(CreateFieldContainer("فصيلة الدم", cboBloodType), 2, 0)
            pnl.Controls.Add(CreateFieldContainer("تاريخ الميلاد", dtpBirthDate), 3, 0)

            grpAcademic.Controls.Add(pnl)
        End Sub

        Private Function CreateStyledTextBox(placeholder As String) As TextBox
            Return New TextBox With {
                .Font = New Font("Segoe UI", 9.5F),
                .BackColor = Color.FromArgb(30, 41, 59),
                .ForeColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle,
                .Dock = DockStyle.Top,
                .PlaceholderText = placeholder
            }
        End Function

        Private Function CreateStyledComboBox(items As String()) As ComboBox
            Dim cbo = New ComboBox With {
                .Font = New Font("Segoe UI", 9.5F),
                .BackColor = Color.FromArgb(30, 41, 59),
                .ForeColor = Color.White,
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Dock = DockStyle.Top
            }
            cbo.Items.AddRange(items)
            If items.Length > 0 Then cbo.SelectedIndex = 0
            Return cbo
        End Function

        Private Function CreateFieldContainer(label As String, ctrl As Control) As Panel
            Dim pnl = New Panel With {
                .Dock = DockStyle.Fill,
                .Padding = New Padding(4)
            }
            Dim lbl = New Label With {
                .Text = label,
                .Dock = DockStyle.Top,
                .Height = 22,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(203, 213, 225)
            }
            pnl.Controls.Add(ctrl)
            pnl.Controls.Add(lbl)
            Return pnl
        End Function

        Private Sub LoadDefaults()
            cboProvince.SelectedItem = "بغداد"
            cboIssuingProvince.SelectedItem = "بغداد"
            cboIdentityType.SelectedItem = "البطاقة الوطنية الموحدة"
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
            txtStudentPhone.Text = CurrentStudent.Phone
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs)
            ' تحقق الأسماء
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
            CurrentStudent.Phone = If(Not String.IsNullOrWhiteSpace(txtStudentPhone.Text), txtStudentPhone.Text.Trim(), phoneRes.CleanPhone)
            CurrentStudent.BloodType = cboBloodType.Text
            CurrentStudent.DateOfBirth = dtpBirthDate.Value

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub
    End Class
End Namespace
