Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TeacherEditForm
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
            Me.grpInfo = New System.Windows.Forms.GroupBox()
            Me.txtSalary = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblSalary = New System.Windows.Forms.Label()
            Me.txtWeeklyQuota = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblWeeklyQuota = New System.Windows.Forms.Label()
            Me.cboDegree = New System.Windows.Forms.ComboBox()
            Me.lblDegree = New System.Windows.Forms.Label()
            Me.cboSpecialization = New System.Windows.Forms.ComboBox()
            Me.lblSpecialization = New System.Windows.Forms.Label()
            Me.txtPhone = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtNationalId = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblNationalId = New System.Windows.Forms.Label()
            Me.txtFamilyName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFamilyName = New System.Windows.Forms.Label()
            Me.txtFatherName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFatherName = New System.Windows.Forms.Label()
            Me.txtFirstName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblFirstName = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlActions.SuspendLayout()
            Me.grpInfo.SuspendLayout()
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
            Me.pnlHeader.Size = New System.Drawing.Size(680, 55)
            Me.pnlHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTitle.Location = New System.Drawing.Point(15, 12)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(650, 31)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "👨‍🏫 بيانات المدرس / المعلم - الهيئة التدريسية"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlActions
            '
            Me.pnlActions.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlActions.Controls.Add(Me.btnSave)
            Me.pnlActions.Controls.Add(Me.btnCancel)
            Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlActions.Location = New System.Drawing.Point(0, 425)
            Me.pnlActions.Name = "pnlActions"
            Me.pnlActions.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
            Me.pnlActions.Size = New System.Drawing.Size(680, 60)
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
            Me.btnSave.Size = New System.Drawing.Size(140, 40)
            Me.btnSave.TabIndex = 0
            Me.btnSave.Text = "💾 حفظ البيانات"
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
            Me.btnCancel.Location = New System.Drawing.Point(165, 10)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(95, 40)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "إلغاء"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'grpInfo
            '
            Me.grpInfo.Controls.Add(Me.txtSalary)
            Me.grpInfo.Controls.Add(Me.lblSalary)
            Me.grpInfo.Controls.Add(Me.txtWeeklyQuota)
            Me.grpInfo.Controls.Add(Me.lblWeeklyQuota)
            Me.grpInfo.Controls.Add(Me.cboDegree)
            Me.grpInfo.Controls.Add(Me.lblDegree)
            Me.grpInfo.Controls.Add(Me.cboSpecialization)
            Me.grpInfo.Controls.Add(Me.lblSpecialization)
            Me.grpInfo.Controls.Add(Me.txtPhone)
            Me.grpInfo.Controls.Add(Me.lblPhone)
            Me.grpInfo.Controls.Add(Me.txtNationalId)
            Me.grpInfo.Controls.Add(Me.lblNationalId)
            Me.grpInfo.Controls.Add(Me.txtFamilyName)
            Me.grpInfo.Controls.Add(Me.lblFamilyName)
            Me.grpInfo.Controls.Add(Me.txtFatherName)
            Me.grpInfo.Controls.Add(Me.lblFatherName)
            Me.grpInfo.Controls.Add(Me.txtFirstName)
            Me.grpInfo.Controls.Add(Me.lblFirstName)
            Me.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpInfo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.grpInfo.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpInfo.Location = New System.Drawing.Point(0, 55)
            Me.grpInfo.Name = "grpInfo"
            Me.grpInfo.Padding = New System.Windows.Forms.Padding(15)
            Me.grpInfo.Size = New System.Drawing.Size(680, 370)
            Me.grpInfo.TabIndex = 2
            Me.grpInfo.TabStop = False
            Me.grpInfo.Text = "المعلومات الشخصية والوظيفية"
            '
            'txtSalary
            '
            Me.txtSalary.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSalary.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtSalary.ForeColor = System.Drawing.Color.White
            Me.txtSalary.Location = New System.Drawing.Point(30, 290)
            Me.txtSalary.Name = "txtSalary"
            Me.txtSalary.PlaceholderText = "1200000"
            Me.txtSalary.Size = New System.Drawing.Size(280, 25)
            Me.txtSalary.TabIndex = 17
            '
            'lblSalary
            '
            Me.lblSalary.AutoSize = True
            Me.lblSalary.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSalary.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblSalary.Location = New System.Drawing.Point(210, 270)
            Me.lblSalary.Name = "lblSalary"
            Me.lblSalary.Size = New System.Drawing.Size(100, 15)
            Me.lblSalary.TabIndex = 16
            Me.lblSalary.Text = "الراتب الشهري (IQD):"
            '
            'txtWeeklyQuota
            '
            Me.txtWeeklyQuota.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtWeeklyQuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWeeklyQuota.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtWeeklyQuota.ForeColor = System.Drawing.Color.White
            Me.txtWeeklyQuota.Location = New System.Drawing.Point(350, 290)
            Me.txtWeeklyQuota.Name = "txtWeeklyQuota"
            Me.txtWeeklyQuota.PlaceholderText = "18"
            Me.txtWeeklyQuota.Size = New System.Drawing.Size(290, 25)
            Me.txtWeeklyQuota.TabIndex = 15
            '
            'lblWeeklyQuota
            '
            Me.lblWeeklyQuota.AutoSize = True
            Me.lblWeeklyQuota.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblWeeklyQuota.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblWeeklyQuota.Location = New System.Drawing.Point(525, 270)
            Me.lblWeeklyQuota.Name = "lblWeeklyQuota"
            Me.lblWeeklyQuota.Size = New System.Drawing.Size(115, 15)
            Me.lblWeeklyQuota.TabIndex = 14
            Me.lblWeeklyQuota.Text = "النصاب الأسبوعي (حصص):"
            '
            'cboDegree
            '
            Me.cboDegree.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDegree.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboDegree.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboDegree.ForeColor = System.Drawing.Color.White
            Me.cboDegree.FormattingEnabled = True
            Me.cboDegree.Items.AddRange(New Object() {"دبلوم", "بكالوريوس", "دبلوم عالي", "ماجستير", "دكتوراه"})
            Me.cboDegree.Location = New System.Drawing.Point(30, 225)
            Me.cboDegree.Name = "cboDegree"
            Me.cboDegree.Size = New System.Drawing.Size(280, 25)
            Me.cboDegree.TabIndex = 13
            '
            'lblDegree
            '
            Me.lblDegree.AutoSize = True
            Me.lblDegree.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblDegree.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDegree.Location = New System.Drawing.Point(235, 205)
            Me.lblDegree.Name = "lblDegree"
            Me.lblDegree.Size = New System.Drawing.Size(75, 15)
            Me.lblDegree.TabIndex = 12
            Me.lblDegree.Text = "المؤهل العلمي:"
            '
            'cboSpecialization
            '
            Me.cboSpecialization.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cboSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSpecialization.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboSpecialization.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboSpecialization.ForeColor = System.Drawing.Color.White
            Me.cboSpecialization.FormattingEnabled = True
            Me.cboSpecialization.Items.AddRange(New Object() {"اللغة العربية", "اللغة الإنجليزية", "الرياضيات", "الفيزياء", "الكيمياء", "الأحياء", "التربية الإسلامية", "الحاسوب", "التربية الفنية", "التربية الرياضية"})
            Me.cboSpecialization.Location = New System.Drawing.Point(350, 225)
            Me.cboSpecialization.Name = "cboSpecialization"
            Me.cboSpecialization.Size = New System.Drawing.Size(290, 25)
            Me.cboSpecialization.TabIndex = 11
            '
            'lblSpecialization
            '
            Me.lblSpecialization.AutoSize = True
            Me.lblSpecialization.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblSpecialization.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblSpecialization.Location = New System.Drawing.Point(560, 205)
            Me.lblSpecialization.Name = "lblSpecialization"
            Me.lblSpecialization.Size = New System.Drawing.Size(80, 15)
            Me.lblSpecialization.TabIndex = 10
            Me.lblSpecialization.Text = "التخصص الدقيق:"
            '
            'txtPhone
            '
            Me.txtPhone.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPhone.ForeColor = System.Drawing.Color.White
            Me.txtPhone.Location = New System.Drawing.Point(30, 160)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.PlaceholderText = "0780XXXXXXX"
            Me.txtPhone.Size = New System.Drawing.Size(280, 25)
            Me.txtPhone.TabIndex = 9
            '
            'lblPhone
            '
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblPhone.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblPhone.Location = New System.Drawing.Point(250, 140)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(60, 15)
            Me.lblPhone.TabIndex = 8
            Me.lblPhone.Text = "رقم الهاتف:"
            '
            'txtNationalId
            '
            Me.txtNationalId.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtNationalId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalId.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtNationalId.ForeColor = System.Drawing.Color.White
            Me.txtNationalId.Location = New System.Drawing.Point(350, 160)
            Me.txtNationalId.Name = "txtNationalId"
            Me.txtNationalId.PlaceholderText = "12 رقماً"
            Me.txtNationalId.Size = New System.Drawing.Size(290, 25)
            Me.txtNationalId.TabIndex = 7
            '
            'lblNationalId
            '
            Me.lblNationalId.AutoSize = True
            Me.lblNationalId.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblNationalId.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblNationalId.Location = New System.Drawing.Point(520, 140)
            Me.lblNationalId.Name = "lblNationalId"
            Me.lblNationalId.Size = New System.Drawing.Size(120, 15)
            Me.lblNationalId.TabIndex = 6
            Me.lblNationalId.Text = "البطاقة الوطنية الموحدة:"
            '
            'txtFamilyName
            '
            Me.txtFamilyName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFamilyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFamilyName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFamilyName.ForeColor = System.Drawing.Color.White
            Me.txtFamilyName.Location = New System.Drawing.Point(30, 95)
            Me.txtFamilyName.Name = "txtFamilyName"
            Me.txtFamilyName.PlaceholderText = "اللقب / العشيرة"
            Me.txtFamilyName.Size = New System.Drawing.Size(280, 25)
            Me.txtFamilyName.TabIndex = 5
            '
            'lblFamilyName
            '
            Me.lblFamilyName.AutoSize = True
            Me.lblFamilyName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFamilyName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFamilyName.Location = New System.Drawing.Point(270, 75)
            Me.lblFamilyName.Name = "lblFamilyName"
            Me.lblFamilyName.Size = New System.Drawing.Size(40, 15)
            Me.lblFamilyName.TabIndex = 4
            Me.lblFamilyName.Text = "اللقب:"
            '
            'txtFatherName
            '
            Me.txtFatherName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFatherName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFatherName.ForeColor = System.Drawing.Color.White
            Me.txtFatherName.Location = New System.Drawing.Point(350, 95)
            Me.txtFatherName.Name = "txtFatherName"
            Me.txtFatherName.PlaceholderText = "اسم الأب والجد"
            Me.txtFatherName.Size = New System.Drawing.Size(290, 25)
            Me.txtFatherName.TabIndex = 3
            '
            'lblFatherName
            '
            Me.lblFatherName.AutoSize = True
            Me.lblFatherName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFatherName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFatherName.Location = New System.Drawing.Point(530, 75)
            Me.lblFatherName.Name = "lblFatherName"
            Me.lblFatherName.Size = New System.Drawing.Size(110, 15)
            Me.lblFatherName.TabIndex = 2
            Me.lblFatherName.Text = "اسم الأب والجد الثاني:"
            '
            'txtFirstName
            '
            Me.txtFirstName.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtFirstName.ForeColor = System.Drawing.Color.White
            Me.txtFirstName.Location = New System.Drawing.Point(350, 45)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.PlaceholderText = "الاسم الأول"
            Me.txtFirstName.Size = New System.Drawing.Size(290, 25)
            Me.txtFirstName.TabIndex = 1
            '
            'lblFirstName
            '
            Me.lblFirstName.AutoSize = True
            Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblFirstName.Location = New System.Drawing.Point(575, 25)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(65, 15)
            Me.lblFirstName.TabIndex = 0
            Me.lblFirstName.Text = "الاسم الأول:"
            '
            'TeacherEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(680, 485)
            Me.Controls.Add(Me.grpInfo)
            Me.Controls.Add(Me.pnlActions)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(650, 450)
            Me.Name = "TeacherEditForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "بيانات المدرس"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlActions.ResumeLayout(False)
            Me.grpInfo.ResumeLayout(False)
            Me.grpInfo.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents pnlActions As System.Windows.Forms.Panel
        Friend WithEvents btnSave As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnCancel As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblFirstName As System.Windows.Forms.Label
        Friend WithEvents txtFirstName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblFatherName As System.Windows.Forms.Label
        Friend WithEvents txtFatherName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblFamilyName As System.Windows.Forms.Label
        Friend WithEvents txtFamilyName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblNationalId As System.Windows.Forms.Label
        Friend WithEvents txtNationalId As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblSpecialization As System.Windows.Forms.Label
        Friend WithEvents cboSpecialization As System.Windows.Forms.ComboBox
        Friend WithEvents lblDegree As System.Windows.Forms.Label
        Friend WithEvents cboDegree As System.Windows.Forms.ComboBox
        Friend WithEvents lblWeeklyQuota As System.Windows.Forms.Label
        Friend WithEvents txtWeeklyQuota As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblSalary As System.Windows.Forms.Label
        Friend WithEvents txtSalary As SchoolManagement.App.Controls.ModernTextBox
    End Class
End Namespace
