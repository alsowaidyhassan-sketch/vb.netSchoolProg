Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StudentEditForm
        Inherits System.Windows.Forms.Form

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlActions = New System.Windows.Forms.Panel()
            Me.btnSave = New SchoolManagement.App.Controls.ModernButton()
            Me.btnCancel = New SchoolManagement.App.Controls.ModernButton()
            Me.pnlContent = New System.Windows.Forms.Panel()
            Me.grpAcademic = New System.Windows.Forms.GroupBox()
            Me.cboBloodType = New System.Windows.Forms.ComboBox()
            Me.lblBloodType = New System.Windows.Forms.Label()
            Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
            Me.lblBirthDate = New System.Windows.Forms.Label()
            Me.cboSection = New System.Windows.Forms.ComboBox()
            Me.lblSection = New System.Windows.Forms.Label()
            Me.cboClass = New System.Windows.Forms.ComboBox()
            Me.lblClass = New System.Windows.Forms.Label()
            Me.grpAddressAndContact = New System.Windows.Forms.GroupBox()
            Me.txtLandmark = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblLandmark = New System.Windows.Forms.Label()
            Me.txtHouseNumber = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblHouseNumber = New System.Windows.Forms.Label()
            Me.txtZuqaq = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblZuqaq = New System.Windows.Forms.Label()
            Me.txtMahalla = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblMahalla = New System.Windows.Forms.Label()
            Me.txtArea = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblArea = New System.Windows.Forms.Label()
            Me.txtDistrict = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblDistrict = New System.Windows.Forms.Label()
            Me.cboProvince = New System.Windows.Forms.ComboBox()
            Me.lblProvince = New System.Windows.Forms.Label()
            Me.lblParentCarrier = New System.Windows.Forms.Label()
            Me.txtParentPhone = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblParentPhone = New System.Windows.Forms.Label()
            Me.grpIdentity = New System.Windows.Forms.GroupBox()
            Me.txtRecordNumber = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblRecordNumber = New System.Windows.Forms.Label()
            Me.txtPageNumber = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblPageNumber = New System.Windows.Forms.Label()
            Me.cboIssuingProvince = New System.Windows.Forms.ComboBox()
            Me.lblIssuingProvince = New System.Windows.Forms.Label()
            Me.txtIssuingAuthority = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblIssuingAuthority = New System.Windows.Forms.Label()
            Me.txtNationalId = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblNationalId = New System.Windows.Forms.Label()
            Me.cboIdentityType = New System.Windows.Forms.ComboBox()
            Me.lblIdentityType = New System.Windows.Forms.Label()
            Me.grpNames = New System.Windows.Forms.GroupBox()
            Me.txtMotherName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblMotherName = New System.Windows.Forms.Label()
            Me.txtFamilyName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFamilyName = New System.Windows.Forms.Label()
            Me.txtGreatGrandFatherName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblGreatGrandFatherName = New System.Windows.Forms.Label()
            Me.txtGrandFatherName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblGrandFatherName = New System.Windows.Forms.Label()
            Me.txtFatherName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFatherName = New System.Windows.Forms.Label()
            Me.txtFirstName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFirstName = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlActions.SuspendLayout()
            Me.pnlContent.SuspendLayout()
            Me.grpAcademic.SuspendLayout()
            Me.grpAddressAndContact.SuspendLayout()
            Me.grpIdentity.SuspendLayout()
            Me.grpNames.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Padding = New System.Windows.Forms.Padding(15, 12, 15, 12)
            Me.pnlHeader.Size = New System.Drawing.Size(920, 55)
            Me.pnlHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTitle.Location = New System.Drawing.Point(15, 12)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(890, 31)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "🇮🇶 تسجيل وتعديل بيانات الطالب - المعايير الرسمية المعتمدة في جمهورية العراق"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlActions
            '
            Me.pnlActions.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlActions.Controls.Add(Me.btnSave)
            Me.pnlActions.Controls.Add(Me.btnCancel)
            Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlActions.Location = New System.Drawing.Point(0, 645)
            Me.pnlActions.Name = "pnlActions"
            Me.pnlActions.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
            Me.pnlActions.Size = New System.Drawing.Size(920, 60)
            Me.pnlActions.TabIndex = 1
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnSave.BorderRadius = 8
            Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSave.FlatAppearance.BorderSize = 0
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnSave.Location = New System.Drawing.Point(15, 10)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(160, 40)
            Me.btnSave.TabIndex = 0
            Me.btnSave.Text = "💾 حفظ بيانات الطالب"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnCancel.BorderRadius = 8
            Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
            Me.btnCancel.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnCancel.Location = New System.Drawing.Point(185, 10)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(100, 40)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "إلغاء"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'pnlContent
            '
            Me.pnlContent.AutoScroll = True
            Me.pnlContent.Controls.Add(Me.grpAcademic)
            Me.pnlContent.Controls.Add(Me.grpAddressAndContact)
            Me.pnlContent.Controls.Add(Me.grpIdentity)
            Me.pnlContent.Controls.Add(Me.grpNames)
            Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContent.Location = New System.Drawing.Point(0, 55)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlContent.Size = New System.Drawing.Size(920, 590)
            Me.pnlContent.TabIndex = 2
            '
            'grpAcademic
            '
            Me.grpAcademic.Controls.Add(Me.cboBloodType)
            Me.grpAcademic.Controls.Add(Me.lblBloodType)
            Me.grpAcademic.Controls.Add(Me.dtpBirthDate)
            Me.grpAcademic.Controls.Add(Me.lblBirthDate)
            Me.grpAcademic.Controls.Add(Me.cboSection)
            Me.grpAcademic.Controls.Add(Me.lblSection)
            Me.grpAcademic.Controls.Add(Me.cboClass)
            Me.grpAcademic.Controls.Add(Me.lblClass)
            Me.grpAcademic.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpAcademic.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.grpAcademic.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpAcademic.Location = New System.Drawing.Point(15, 465)
            Me.grpAcademic.Name = "grpAcademic"
            Me.grpAcademic.Padding = New System.Windows.Forms.Padding(12)
            Me.grpAcademic.Size = New System.Drawing.Size(890, 100)
            Me.grpAcademic.TabIndex = 3
            Me.grpAcademic.TabStop = False
            Me.grpAcademic.Text = "4. البيانات الأكاديمية والصحية"
            '
            'cboBloodType
            '
            Me.cboBloodType.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBloodType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboBloodType.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboBloodType.ForeColor = System.Drawing.Color.White
            Me.cboBloodType.FormattingEnabled = True
            Me.cboBloodType.Items.AddRange(New Object() {"O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-"})
            Me.cboBloodType.Location = New System.Drawing.Point(20, 50)
            Me.cboBloodType.Name = "cboBloodType"
            Me.cboBloodType.Size = New System.Drawing.Size(180, 25)
            Me.cboBloodType.TabIndex = 7
            '
            'lblBloodType
            '
            Me.lblBloodType.AutoSize = True
            Me.lblBloodType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblBloodType.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblBloodType.Location = New System.Drawing.Point(135, 25)
            Me.lblBloodType.Name = "lblBloodType"
            Me.lblBloodType.Size = New System.Drawing.Size(65, 15)
            Me.lblBloodType.TabIndex = 6
            Me.lblBloodType.Text = "فصيلة الدم:"
            '
            'dtpBirthDate
            '
            Me.dtpBirthDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpBirthDate.Location = New System.Drawing.Point(240, 50)
            Me.dtpBirthDate.Name = "dtpBirthDate"
            Me.dtpBirthDate.Size = New System.Drawing.Size(180, 24)
            Me.dtpBirthDate.TabIndex = 5
            '
            'lblBirthDate
            '
            Me.lblBirthDate.AutoSize = True
            Me.lblBirthDate.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblBirthDate.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblBirthDate.Location = New System.Drawing.Point(350, 25)
            Me.lblBirthDate.Name = "lblBirthDate"
            Me.lblBirthDate.Size = New System.Drawing.Size(70, 15)
            Me.lblBirthDate.TabIndex = 4
            Me.lblBirthDate.Text = "تاريخ الميلاد:"
            '
            'cboSection
            '
            Me.cboSection.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboSection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboSection.ForeColor = System.Drawing.Color.White
            Me.cboSection.FormattingEnabled = True
            Me.cboSection.Items.AddRange(New Object() {"شعبة أ", "شعبة ب", "شعبة ج", "شعبة د"})
            Me.cboSection.Location = New System.Drawing.Point(460, 50)
            Me.cboSection.Name = "cboSection"
            Me.cboSection.Size = New System.Drawing.Size(180, 25)
            Me.cboSection.TabIndex = 3
            '
            'lblSection
            '
            Me.lblSection.AutoSize = True
            Me.lblSection.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSection.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblSection.Location = New System.Drawing.Point(595, 25)
            Me.lblSection.Name = "lblSection"
            Me.lblSection.Size = New System.Drawing.Size(45, 15)
            Me.lblSection.TabIndex = 2
            Me.lblSection.Text = "الشعبة:"
            '
            'cboClass
            '
            Me.cboClass.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboClass.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboClass.ForeColor = System.Drawing.Color.White
            Me.cboClass.FormattingEnabled = True
            Me.cboClass.Items.AddRange(New Object() {"الأول متوسط", "الثاني متوسط", "الثالث متوسط", "الرابع العلمي", "الخامس العلمي", "السادس العلمي"})
            Me.cboClass.Location = New System.Drawing.Point(680, 50)
            Me.cboClass.Name = "cboClass"
            Me.cboClass.Size = New System.Drawing.Size(180, 25)
            Me.cboClass.TabIndex = 1
            '
            'lblClass
            '
            Me.lblClass.AutoSize = True
            Me.lblClass.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblClass.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblClass.Location = New System.Drawing.Point(790, 25)
            Me.lblClass.Name = "lblClass"
            Me.lblClass.Size = New System.Drawing.Size(70, 15)
            Me.lblClass.TabIndex = 0
            Me.lblClass.Text = "الصف الدراسي:"
            '
            'grpAddressAndContact
            '
            Me.grpAddressAndContact.Controls.Add(Me.txtLandmark)
            Me.grpAddressAndContact.Controls.Add(Me.lblLandmark)
            Me.grpAddressAndContact.Controls.Add(Me.txtHouseNumber)
            Me.grpAddressAndContact.Controls.Add(Me.lblHouseNumber)
            Me.grpAddressAndContact.Controls.Add(Me.txtZuqaq)
            Me.grpAddressAndContact.Controls.Add(Me.lblZuqaq)
            Me.grpAddressAndContact.Controls.Add(Me.txtMahalla)
            Me.grpAddressAndContact.Controls.Add(Me.lblMahalla)
            Me.grpAddressAndContact.Controls.Add(Me.txtArea)
            Me.grpAddressAndContact.Controls.Add(Me.lblArea)
            Me.grpAddressAndContact.Controls.Add(Me.txtDistrict)
            Me.grpAddressAndContact.Controls.Add(Me.lblDistrict)
            Me.grpAddressAndContact.Controls.Add(Me.cboProvince)
            Me.grpAddressAndContact.Controls.Add(Me.lblProvince)
            Me.grpAddressAndContact.Controls.Add(Me.lblParentCarrier)
            Me.grpAddressAndContact.Controls.Add(Me.txtParentPhone)
            Me.grpAddressAndContact.Controls.Add(Me.lblParentPhone)
            Me.grpAddressAndContact.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpAddressAndContact.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.grpAddressAndContact.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpAddressAndContact.Location = New System.Drawing.Point(15, 275)
            Me.grpAddressAndContact.Name = "grpAddressAndContact"
            Me.grpAddressAndContact.Padding = New System.Windows.Forms.Padding(12)
            Me.grpAddressAndContact.Size = New System.Drawing.Size(890, 190)
            Me.grpAddressAndContact.TabIndex = 2
            Me.grpAddressAndContact.TabStop = False
            Me.grpAddressAndContact.Text = "3. الاتصال والعنوان السكني التفصيلي داخل العراق"
            '
            'txtLandmark
            '
            Me.txtLandmark.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtLandmark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLandmark.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtLandmark.ForeColor = System.Drawing.Color.White
            Me.txtLandmark.Location = New System.Drawing.Point(20, 145)
            Me.txtLandmark.Name = "txtLandmark"
            Me.txtLandmark.PlaceholderText = "مثال: قرب جامع المأمون"
            Me.txtLandmark.Size = New System.Drawing.Size(400, 25)
            Me.txtLandmark.TabIndex = 16
            '
            'lblLandmark
            '
            Me.lblLandmark.AutoSize = True
            Me.lblLandmark.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblLandmark.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblLandmark.Location = New System.Drawing.Point(335, 125)
            Me.lblLandmark.Name = "lblLandmark"
            Me.lblLandmark.Size = New System.Drawing.Size(85, 15)
            Me.lblLandmark.TabIndex = 15
            Me.lblLandmark.Text = "أقرب نقطة دالة:"
            '
            'txtHouseNumber
            '
            Me.txtHouseNumber.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtHouseNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtHouseNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtHouseNumber.ForeColor = System.Drawing.Color.White
            Me.txtHouseNumber.Location = New System.Drawing.Point(460, 145)
            Me.txtHouseNumber.Name = "txtHouseNumber"
            Me.txtHouseNumber.PlaceholderText = "25"
            Me.txtHouseNumber.Size = New System.Drawing.Size(180, 25)
            Me.txtHouseNumber.TabIndex = 14
            '
            'lblHouseNumber
            '
            Me.lblHouseNumber.AutoSize = True
            Me.lblHouseNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblHouseNumber.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblHouseNumber.Location = New System.Drawing.Point(585, 125)
            Me.lblHouseNumber.Name = "lblHouseNumber"
            Me.lblHouseNumber.Size = New System.Drawing.Size(55, 15)
            Me.lblHouseNumber.TabIndex = 13
            Me.lblHouseNumber.Text = "رقم الدار:"
            '
            'txtZuqaq
            '
            Me.txtZuqaq.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtZuqaq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZuqaq.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtZuqaq.ForeColor = System.Drawing.Color.White
            Me.txtZuqaq.Location = New System.Drawing.Point(680, 145)
            Me.txtZuqaq.Name = "txtZuqaq"
            Me.txtZuqaq.PlaceholderText = "14"
            Me.txtZuqaq.Size = New System.Drawing.Size(180, 25)
            Me.txtZuqaq.TabIndex = 12
            '
            'lblZuqaq
            '
            Me.lblZuqaq.AutoSize = True
            Me.lblZuqaq.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblZuqaq.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblZuqaq.Location = New System.Drawing.Point(825, 125)
            Me.lblZuqaq.Name = "lblZuqaq"
            Me.lblZuqaq.Size = New System.Drawing.Size(35, 15)
            Me.lblZuqaq.TabIndex = 11
            Me.lblZuqaq.Text = "الزقاق:"
            '
            'txtMahalla
            '
            Me.txtMahalla.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtMahalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMahalla.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtMahalla.ForeColor = System.Drawing.Color.White
            Me.txtMahalla.Location = New System.Drawing.Point(20, 95)
            Me.txtMahalla.Name = "txtMahalla"
            Me.txtMahalla.PlaceholderText = "612"
            Me.txtMahalla.Size = New System.Drawing.Size(180, 25)
            Me.txtMahalla.TabIndex = 10
            '
            'lblMahalla
            '
            Me.lblMahalla.AutoSize = True
            Me.lblMahalla.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblMahalla.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblMahalla.Location = New System.Drawing.Point(155, 75)
            Me.lblMahalla.Name = "lblMahalla"
            Me.lblMahalla.Size = New System.Drawing.Size(45, 15)
            Me.lblMahalla.TabIndex = 9
            Me.lblMahalla.Text = "المحلة:"
            '
            'txtArea
            '
            Me.txtArea.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtArea.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtArea.ForeColor = System.Drawing.Color.White
            Me.txtArea.Location = New System.Drawing.Point(240, 95)
            Me.txtArea.Name = "txtArea"
            Me.txtArea.PlaceholderText = "حي اليرموك"
            Me.txtArea.Size = New System.Drawing.Size(180, 25)
            Me.txtArea.TabIndex = 8
            '
            'lblArea
            '
            Me.lblArea.AutoSize = True
            Me.lblArea.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblArea.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblArea.Location = New System.Drawing.Point(345, 75)
            Me.lblArea.Name = "lblArea"
            Me.lblArea.Size = New System.Drawing.Size(75, 15)
            Me.lblArea.TabIndex = 7
            Me.lblArea.Text = "الحي / المنطقة:"
            '
            'txtDistrict
            '
            Me.txtDistrict.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistrict.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDistrict.ForeColor = System.Drawing.Color.White
            Me.txtDistrict.Location = New System.Drawing.Point(460, 95)
            Me.txtDistrict.Name = "txtDistrict"
            Me.txtDistrict.PlaceholderText = "الكرخ"
            Me.txtDistrict.Size = New System.Drawing.Size(180, 25)
            Me.txtDistrict.TabIndex = 6
            '
            'lblDistrict
            '
            Me.lblDistrict.AutoSize = True
            Me.lblDistrict.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblDistrict.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDistrict.Location = New System.Drawing.Point(595, 75)
            Me.lblDistrict.Name = "lblDistrict"
            Me.lblDistrict.Size = New System.Drawing.Size(45, 15)
            Me.lblDistrict.TabIndex = 5
            Me.lblDistrict.Text = "القضاء:"
            '
            'cboProvince
            '
            Me.cboProvince.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboProvince.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboProvince.ForeColor = System.Drawing.Color.White
            Me.cboProvince.FormattingEnabled = True
            Me.cboProvince.Location = New System.Drawing.Point(680, 95)
            Me.cboProvince.Name = "cboProvince"
            Me.cboProvince.Size = New System.Drawing.Size(180, 25)
            Me.cboProvince.TabIndex = 4
            '
            'lblProvince
            '
            Me.lblProvince.AutoSize = True
            Me.lblProvince.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblProvince.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblProvince.Location = New System.Drawing.Point(800, 75)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(60, 15)
            Me.lblProvince.TabIndex = 3
            Me.lblProvince.Text = "المحافظة *:"
            '
            'lblParentCarrier
            '
            Me.lblParentCarrier.AutoSize = True
            Me.lblParentCarrier.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblParentCarrier.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.lblParentCarrier.Location = New System.Drawing.Point(460, 48)
            Me.lblParentCarrier.Name = "lblParentCarrier"
            Me.lblParentCarrier.Size = New System.Drawing.Size(150, 15)
            Me.lblParentCarrier.TabIndex = 2
            Me.lblParentCarrier.Text = "زين العراق / آسيا سيل / كورك"
            '
            'txtParentPhone
            '
            Me.txtParentPhone.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtParentPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtParentPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtParentPhone.ForeColor = System.Drawing.Color.White
            Me.txtParentPhone.Location = New System.Drawing.Point(680, 45)
            Me.txtParentPhone.Name = "txtParentPhone"
            Me.txtParentPhone.PlaceholderText = "07801234567"
            Me.txtParentPhone.Size = New System.Drawing.Size(180, 25)
            Me.txtParentPhone.TabIndex = 1
            '
            'lblParentPhone
            '
            Me.lblParentPhone.AutoSize = True
            Me.lblParentPhone.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblParentPhone.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblParentPhone.Location = New System.Drawing.Point(740, 25)
            Me.lblParentPhone.Name = "lblParentPhone"
            Me.lblParentPhone.Size = New System.Drawing.Size(120, 15)
            Me.lblParentPhone.TabIndex = 0
            Me.lblParentPhone.Text = "هاتف ولي الأمر (واتساب)*:"
            '
            'grpIdentity
            '
            Me.grpIdentity.Controls.Add(Me.txtRecordNumber)
            Me.grpIdentity.Controls.Add(Me.lblRecordNumber)
            Me.grpIdentity.Controls.Add(Me.txtPageNumber)
            Me.grpIdentity.Controls.Add(Me.lblPageNumber)
            Me.grpIdentity.Controls.Add(Me.cboIssuingProvince)
            Me.grpIdentity.Controls.Add(Me.lblIssuingProvince)
            Me.grpIdentity.Controls.Add(Me.txtIssuingAuthority)
            Me.grpIdentity.Controls.Add(Me.lblIssuingAuthority)
            Me.grpIdentity.Controls.Add(Me.txtNationalId)
            Me.grpIdentity.Controls.Add(Me.lblNationalId)
            Me.grpIdentity.Controls.Add(Me.cboIdentityType)
            Me.grpIdentity.Controls.Add(Me.lblIdentityType)
            Me.grpIdentity.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpIdentity.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.grpIdentity.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpIdentity.Location = New System.Drawing.Point(15, 145)
            Me.grpIdentity.Name = "grpIdentity"
            Me.grpIdentity.Padding = New System.Windows.Forms.Padding(12)
            Me.grpIdentity.Size = New System.Drawing.Size(890, 130)
            Me.grpIdentity.TabIndex = 1
            Me.grpIdentity.TabStop = False
            Me.grpIdentity.Text = "2. الوثيقة الثبوتية (البطاقة الوطنية 12 رقماً / هوية الأحوال / جواز السفر)"
            '
            'txtRecordNumber
            '
            Me.txtRecordNumber.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtRecordNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRecordNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtRecordNumber.ForeColor = System.Drawing.Color.White
            Me.txtRecordNumber.Location = New System.Drawing.Point(20, 90)
            Me.txtRecordNumber.Name = "txtRecordNumber"
            Me.txtRecordNumber.Size = New System.Drawing.Size(260, 25)
            Me.txtRecordNumber.TabIndex = 11
            '
            'lblRecordNumber
            '
            Me.lblRecordNumber.AutoSize = True
            Me.lblRecordNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblRecordNumber.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblRecordNumber.Location = New System.Drawing.Point(240, 70)
            Me.lblRecordNumber.Name = "lblRecordNumber"
            Me.lblRecordNumber.Size = New System.Drawing.Size(40, 15)
            Me.lblRecordNumber.TabIndex = 10
            Me.lblRecordNumber.Text = "السجل:"
            '
            'txtPageNumber
            '
            Me.txtPageNumber.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPageNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPageNumber.ForeColor = System.Drawing.Color.White
            Me.txtPageNumber.Location = New System.Drawing.Point(310, 90)
            Me.txtPageNumber.Name = "txtPageNumber"
            Me.txtPageNumber.Size = New System.Drawing.Size(260, 25)
            Me.txtPageNumber.TabIndex = 9
            '
            'lblPageNumber
            '
            Me.lblPageNumber.AutoSize = True
            Me.lblPageNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblPageNumber.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblPageNumber.Location = New System.Drawing.Point(520, 70)
            Me.lblPageNumber.Name = "lblPageNumber"
            Me.lblPageNumber.Size = New System.Drawing.Size(50, 15)
            Me.lblPageNumber.TabIndex = 8
            Me.lblPageNumber.Text = "الصحيفة:"
            '
            'cboIssuingProvince
            '
            Me.cboIssuingProvince.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboIssuingProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboIssuingProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboIssuingProvince.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboIssuingProvince.ForeColor = System.Drawing.Color.White
            Me.cboIssuingProvince.FormattingEnabled = True
            Me.cboIssuingProvince.Location = New System.Drawing.Point(600, 90)
            Me.cboIssuingProvince.Name = "cboIssuingProvince"
            Me.cboIssuingProvince.Size = New System.Drawing.Size(260, 25)
            Me.cboIssuingProvince.TabIndex = 7
            '
            'lblIssuingProvince
            '
            Me.lblIssuingProvince.AutoSize = True
            Me.lblIssuingProvince.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblIssuingProvince.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblIssuingProvince.Location = New System.Drawing.Point(770, 70)
            Me.lblIssuingProvince.Name = "lblIssuingProvince"
            Me.lblIssuingProvince.Size = New System.Drawing.Size(90, 15)
            Me.lblIssuingProvince.TabIndex = 6
            Me.lblIssuingProvince.Text = "محافظة الإصدار:"
            '
            'txtIssuingAuthority
            '
            Me.txtIssuingAuthority.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtIssuingAuthority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIssuingAuthority.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtIssuingAuthority.ForeColor = System.Drawing.Color.White
            Me.txtIssuingAuthority.Location = New System.Drawing.Point(20, 40)
            Me.txtIssuingAuthority.Name = "txtIssuingAuthority"
            Me.txtIssuingAuthority.PlaceholderText = "مثال: دائرة أحوال الكرخ"
            Me.txtIssuingAuthority.Size = New System.Drawing.Size(260, 25)
            Me.txtIssuingAuthority.TabIndex = 5
            '
            'lblIssuingAuthority
            '
            Me.lblIssuingAuthority.AutoSize = True
            Me.lblIssuingAuthority.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblIssuingAuthority.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblIssuingAuthority.Location = New System.Drawing.Point(200, 20)
            Me.lblIssuingAuthority.Name = "lblIssuingAuthority"
            Me.lblIssuingAuthority.Size = New System.Drawing.Size(80, 15)
            Me.lblIssuingAuthority.TabIndex = 4
            Me.lblIssuingAuthority.Text = "دائرة الإصدار:"
            '
            'txtNationalId
            '
            Me.txtNationalId.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtNationalId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalId.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNationalId.ForeColor = System.Drawing.Color.White
            Me.txtNationalId.Location = New System.Drawing.Point(310, 40)
            Me.txtNationalId.Name = "txtNationalId"
            Me.txtNationalId.PlaceholderText = "12 رقماً للبطاقة الموحدة"
            Me.txtNationalId.Size = New System.Drawing.Size(260, 25)
            Me.txtNationalId.TabIndex = 3
            '
            'lblNationalId
            '
            Me.lblNationalId.AutoSize = True
            Me.lblNationalId.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblNationalId.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblNationalId.Location = New System.Drawing.Point(440, 20)
            Me.lblNationalId.Name = "lblNationalId"
            Me.lblNationalId.Size = New System.Drawing.Size(130, 15)
            Me.lblNationalId.TabIndex = 2
            Me.lblNationalId.Text = "رقم الوثيقة (12 رقماً)*:"
            '
            'cboIdentityType
            '
            Me.cboIdentityType.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboIdentityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboIdentityType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboIdentityType.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.cboIdentityType.ForeColor = System.Drawing.Color.White
            Me.cboIdentityType.FormattingEnabled = True
            Me.cboIdentityType.Items.AddRange(New Object() {"البطاقة الوطنية الموحدة", "هوية الأحوال المدنية", "شهادة الجنسية العراقية", "جواز السفر العراقي"})
            Me.cboIdentityType.Location = New System.Drawing.Point(600, 40)
            Me.cboIdentityType.Name = "cboIdentityType"
            Me.cboIdentityType.Size = New System.Drawing.Size(260, 25)
            Me.cboIdentityType.TabIndex = 1
            '
            'lblIdentityType
            '
            Me.lblIdentityType.AutoSize = True
            Me.lblIdentityType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblIdentityType.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblIdentityType.Location = New System.Drawing.Point(770, 20)
            Me.lblIdentityType.Name = "lblIdentityType"
            Me.lblIdentityType.Size = New System.Drawing.Size(90, 15)
            Me.lblIdentityType.TabIndex = 0
            Me.lblIdentityType.Text = "نوع الوثيقة الثبوتية:"
            '
            'grpNames
            '
            Me.grpNames.Controls.Add(Me.txtMotherName)
            Me.grpNames.Controls.Add(Me.lblMotherName)
            Me.grpNames.Controls.Add(Me.txtFamilyName)
            Me.grpNames.Controls.Add(Me.lblFamilyName)
            Me.grpNames.Controls.Add(Me.txtGreatGrandFatherName)
            Me.grpNames.Controls.Add(Me.lblGreatGrandFatherName)
            Me.grpNames.Controls.Add(Me.txtGrandFatherName)
            Me.grpNames.Controls.Add(Me.lblGrandFatherName)
            Me.grpNames.Controls.Add(Me.txtFatherName)
            Me.grpNames.Controls.Add(Me.lblFatherName)
            Me.grpNames.Controls.Add(Me.txtFirstName)
            Me.grpNames.Controls.Add(Me.lblFirstName)
            Me.grpNames.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpNames.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.grpNames.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpNames.Location = New System.Drawing.Point(15, 15)
            Me.grpNames.Name = "grpNames"
            Me.grpNames.Padding = New System.Windows.Forms.Padding(12)
            Me.grpNames.Size = New System.Drawing.Size(890, 130)
            Me.grpNames.TabIndex = 0
            Me.grpNames.TabStop = False
            Me.grpNames.Text = "1. الاسم الخماسي العراقي واسم الأم"
            '
            'txtMotherName
            '
            Me.txtMotherName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMotherName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtMotherName.ForeColor = System.Drawing.Color.White
            Me.txtMotherName.Location = New System.Drawing.Point(20, 90)
            Me.txtMotherName.Name = "txtMotherName"
            Me.txtMotherName.PlaceholderText = "مثال: فاطمة جاسم محمد"
            Me.txtMotherName.Size = New System.Drawing.Size(260, 25)
            Me.txtMotherName.TabIndex = 11
            '
            'lblMotherName
            '
            Me.lblMotherName.AutoSize = True
            Me.lblMotherName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblMotherName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblMotherName.Location = New System.Drawing.Point(180, 70)
            Me.lblMotherName.Name = "lblMotherName"
            Me.lblMotherName.Size = New System.Drawing.Size(100, 15)
            Me.lblMotherName.TabIndex = 10
            Me.lblMotherName.Text = "اسم الأم الثلاثي:"
            '
            'txtFamilyName
            '
            Me.txtFamilyName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFamilyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFamilyName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFamilyName.ForeColor = System.Drawing.Color.White
            Me.txtFamilyName.Location = New System.Drawing.Point(310, 90)
            Me.txtFamilyName.Name = "txtFamilyName"
            Me.txtFamilyName.PlaceholderText = "مثال: الزبيدي"
            Me.txtFamilyName.Size = New System.Drawing.Size(260, 25)
            Me.txtFamilyName.TabIndex = 9
            '
            'lblFamilyName
            '
            Me.lblFamilyName.AutoSize = True
            Me.lblFamilyName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFamilyName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFamilyName.Location = New System.Drawing.Point(480, 70)
            Me.lblFamilyName.Name = "lblFamilyName"
            Me.lblFamilyName.Size = New System.Drawing.Size(90, 15)
            Me.lblFamilyName.TabIndex = 8
            Me.lblFamilyName.Text = "اللقب / العشيرة:"
            '
            'txtGreatGrandFatherName
            '
            Me.txtGreatGrandFatherName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtGreatGrandFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGreatGrandFatherName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtGreatGrandFatherName.ForeColor = System.Drawing.Color.White
            Me.txtGreatGrandFatherName.Location = New System.Drawing.Point(600, 90)
            Me.txtGreatGrandFatherName.Name = "txtGreatGrandFatherName"
            Me.txtGreatGrandFatherName.PlaceholderText = "مثال: حسن"
            Me.txtGreatGrandFatherName.Size = New System.Drawing.Size(260, 25)
            Me.txtGreatGrandFatherName.TabIndex = 7
            '
            'lblGreatGrandFatherName
            '
            Me.lblGreatGrandFatherName.AutoSize = True
            Me.lblGreatGrandFatherName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblGreatGrandFatherName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblGreatGrandFatherName.Location = New System.Drawing.Point(760, 70)
            Me.lblGreatGrandFatherName.Name = "lblGreatGrandFatherName"
            Me.lblGreatGrandFatherName.Size = New System.Drawing.Size(100, 15)
            Me.lblGreatGrandFatherName.TabIndex = 6
            Me.lblGreatGrandFatherName.Text = "اسم الجد الرابع:"
            '
            'txtGrandFatherName
            '
            Me.txtGrandFatherName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtGrandFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGrandFatherName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtGrandFatherName.ForeColor = System.Drawing.Color.White
            Me.txtGrandFatherName.Location = New System.Drawing.Point(20, 40)
            Me.txtGrandFatherName.Name = "txtGrandFatherName"
            Me.txtGrandFatherName.PlaceholderText = "مثال: كاظم"
            Me.txtGrandFatherName.Size = New System.Drawing.Size(260, 25)
            Me.txtGrandFatherName.TabIndex = 5
            '
            'lblGrandFatherName
            '
            Me.lblGrandFatherName.AutoSize = True
            Me.lblGrandFatherName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblGrandFatherName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblGrandFatherName.Location = New System.Drawing.Point(210, 20)
            Me.lblGrandFatherName.Name = "lblGrandFatherName"
            Me.lblGrandFatherName.Size = New System.Drawing.Size(70, 15)
            Me.lblGrandFatherName.TabIndex = 4
            Me.lblGrandFatherName.Text = "اسم الجد *:"
            '
            'txtFatherName
            '
            Me.txtFatherName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFatherName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFatherName.ForeColor = System.Drawing.Color.White
            Me.txtFatherName.Location = New System.Drawing.Point(310, 40)
            Me.txtFatherName.Name = "txtFatherName"
            Me.txtFatherName.PlaceholderText = "مثال: حسين"
            Me.txtFatherName.Size = New System.Drawing.Size(260, 25)
            Me.txtFatherName.TabIndex = 3
            '
            'lblFatherName
            '
            Me.lblFatherName.AutoSize = True
            Me.lblFatherName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFatherName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFatherName.Location = New System.Drawing.Point(500, 20)
            Me.lblFatherName.Name = "lblFatherName"
            Me.lblFatherName.Size = New System.Drawing.Size(70, 15)
            Me.lblFatherName.TabIndex = 2
            Me.lblFatherName.Text = "اسم الأب *:"
            '
            'txtFirstName
            '
            Me.txtFirstName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFirstName.ForeColor = System.Drawing.Color.White
            Me.txtFirstName.Location = New System.Drawing.Point(600, 40)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.PlaceholderText = "مثال: علي"
            Me.txtFirstName.Size = New System.Drawing.Size(260, 25)
            Me.txtFirstName.TabIndex = 1
            '
            'lblFirstName
            '
            Me.lblFirstName.AutoSize = True
            Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFirstName.Location = New System.Drawing.Point(785, 20)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(75, 15)
            Me.lblFirstName.TabIndex = 0
            Me.lblFirstName.Text = "الاسم الأول *:"
            '
            'StudentEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(920, 705)
            Me.Controls.Add(Me.pnlContent)
            Me.Controls.Add(Me.pnlActions)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.MinimumSize = New System.Drawing.Size(850, 650)
            Me.Name = "StudentEditForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "بيانات الطالب - المعايير العراقية الرسمية"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlActions.ResumeLayout(False)
            Me.pnlContent.ResumeLayout(False)
            Me.grpAcademic.ResumeLayout(False)
            Me.grpAcademic.PerformLayout()
            Me.grpAddressAndContact.ResumeLayout(False)
            Me.grpAddressAndContact.PerformLayout()
            Me.grpIdentity.ResumeLayout(False)
            Me.grpIdentity.PerformLayout()
            Me.grpNames.ResumeLayout(False)
            Me.grpNames.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents pnlActions As System.Windows.Forms.Panel
        Friend WithEvents btnSave As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnCancel As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents grpNames As System.Windows.Forms.GroupBox
        Friend WithEvents lblFirstName As System.Windows.Forms.Label
        Friend WithEvents txtFirstName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblFatherName As System.Windows.Forms.Label
        Friend WithEvents txtFatherName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblGrandFatherName As System.Windows.Forms.Label
        Friend WithEvents txtGrandFatherName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblGreatGrandFatherName As System.Windows.Forms.Label
        Friend WithEvents txtGreatGrandFatherName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblFamilyName As System.Windows.Forms.Label
        Friend WithEvents txtFamilyName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblMotherName As System.Windows.Forms.Label
        Friend WithEvents txtMotherName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents grpIdentity As System.Windows.Forms.GroupBox
        Friend WithEvents lblIdentityType As System.Windows.Forms.Label
        Friend WithEvents cboIdentityType As System.Windows.Forms.ComboBox
        Friend WithEvents lblNationalId As System.Windows.Forms.Label
        Friend WithEvents txtNationalId As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblIssuingAuthority As System.Windows.Forms.Label
        Friend WithEvents txtIssuingAuthority As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblIssuingProvince As System.Windows.Forms.Label
        Friend WithEvents cboIssuingProvince As System.Windows.Forms.ComboBox
        Friend WithEvents lblPageNumber As System.Windows.Forms.Label
        Friend WithEvents txtPageNumber As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblRecordNumber As System.Windows.Forms.Label
        Friend WithEvents txtRecordNumber As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents grpAddressAndContact As System.Windows.Forms.GroupBox
        Friend WithEvents lblParentPhone As System.Windows.Forms.Label
        Friend WithEvents txtParentPhone As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblParentCarrier As System.Windows.Forms.Label
        Friend WithEvents lblProvince As System.Windows.Forms.Label
        Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
        Friend WithEvents lblDistrict As System.Windows.Forms.Label
        Friend WithEvents txtDistrict As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblArea As System.Windows.Forms.Label
        Friend WithEvents txtArea As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblMahalla As System.Windows.Forms.Label
        Friend WithEvents txtMahalla As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblZuqaq As System.Windows.Forms.Label
        Friend WithEvents txtZuqaq As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblHouseNumber As System.Windows.Forms.Label
        Friend WithEvents txtHouseNumber As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblLandmark As System.Windows.Forms.Label
        Friend WithEvents txtLandmark As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents grpAcademic As System.Windows.Forms.GroupBox
        Friend WithEvents lblClass As System.Windows.Forms.Label
        Friend WithEvents cboClass As System.Windows.Forms.ComboBox
        Friend WithEvents lblSection As System.Windows.Forms.Label
        Friend WithEvents cboSection As System.Windows.Forms.ComboBox
        Friend WithEvents lblBirthDate As System.Windows.Forms.Label
        Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblBloodType As System.Windows.Forms.Label
        Friend WithEvents cboBloodType As System.Windows.Forms.ComboBox
    End Class
End Namespace
