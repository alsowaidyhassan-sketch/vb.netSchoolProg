Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StudentsForm
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
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.btnAddStudent = New SchoolManagement.App.Controls.ModernButton()
            Me.btnWhatsApp = New SchoolManagement.App.Controls.ModernButton()
            Me.btnProfile = New SchoolManagement.App.Controls.ModernButton()
            Me.txtSearch = New SchoolManagement.App.Controls.ModernTextBox()
            Me.cboClassFilter = New System.Windows.Forms.ComboBox()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblStudentCount = New System.Windows.Forms.Label()
            Me.dgvStudents = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colStudentNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMotherName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colNationalId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnAddStudent)
            Me.pnlTop.Controls.Add(Me.btnWhatsApp)
            Me.pnlTop.Controls.Add(Me.btnProfile)
            Me.pnlTop.Controls.Add(Me.txtSearch)
            Me.pnlTop.Controls.Add(Me.cboClassFilter)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(1000, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnAddStudent
            '
            Me.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnAddStudent.BorderRadius = 8
            Me.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddStudent.FlatAppearance.BorderSize = 0
            Me.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddStudent.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnAddStudent.ForeColor = System.Drawing.Color.White
            Me.btnAddStudent.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnAddStudent.Location = New System.Drawing.Point(12, 12)
            Me.btnAddStudent.Name = "btnAddStudent"
            Me.btnAddStudent.Size = New System.Drawing.Size(160, 40)
            Me.btnAddStudent.TabIndex = 0
            Me.btnAddStudent.Text = "➕ تسجيل طالب جديد"
            Me.btnAddStudent.UseVisualStyleBackColor = False
            '
            'btnWhatsApp
            '
            Me.btnWhatsApp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129)
            Me.btnWhatsApp.BorderRadius = 8
            Me.btnWhatsApp.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnWhatsApp.FlatAppearance.BorderSize = 0
            Me.btnWhatsApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnWhatsApp.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnWhatsApp.ForeColor = System.Drawing.Color.White
            Me.btnWhatsApp.HoverColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.btnWhatsApp.Location = New System.Drawing.Point(180, 12)
            Me.btnWhatsApp.Name = "btnWhatsApp"
            Me.btnWhatsApp.Size = New System.Drawing.Size(150, 40)
            Me.btnWhatsApp.TabIndex = 1
            Me.btnWhatsApp.Text = "💬 واتساب ولي الأمر"
            Me.btnWhatsApp.UseVisualStyleBackColor = False
            '
            'btnProfile
            '
            Me.btnProfile.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnProfile.BorderRadius = 8
            Me.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnProfile.FlatAppearance.BorderSize = 0
            Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnProfile.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnProfile.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnProfile.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnProfile.Location = New System.Drawing.Point(340, 12)
            Me.btnProfile.Name = "btnProfile"
            Me.btnProfile.Size = New System.Drawing.Size(130, 40)
            Me.btnProfile.TabIndex = 2
            Me.btnProfile.Text = "👤 الإضبارة الشاملة"
            Me.btnProfile.UseVisualStyleBackColor = False
            '
            'txtSearch
            '
            Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtSearch.ForeColor = System.Drawing.Color.White
            Me.txtSearch.Location = New System.Drawing.Point(710, 18)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.PlaceholderText = "بحث باسم الطالب، الهوية أو الهاتف..."
            Me.txtSearch.Size = New System.Drawing.Size(275, 25)
            Me.txtSearch.TabIndex = 3
            '
            'cboClassFilter
            '
            Me.cboClassFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboClassFilter.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboClassFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClassFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboClassFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboClassFilter.ForeColor = System.Drawing.Color.White
            Me.cboClassFilter.FormattingEnabled = True
            Me.cboClassFilter.Items.AddRange(New Object() {"جميع المراحل والصفوف", "الأول متوسط", "الثاني متوسط", "الثالث متوسط", "الرابع العلمي", "الخامس العلمي", "السادس العلمي"})
            Me.cboClassFilter.Location = New System.Drawing.Point(520, 18)
            Me.cboClassFilter.Name = "cboClassFilter"
            Me.cboClassFilter.Size = New System.Drawing.Size(175, 25)
            Me.cboClassFilter.TabIndex = 4
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblStudentCount)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 565)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(1000, 35)
            Me.pnlBottom.TabIndex = 1
            '
            'lblStudentCount
            '
            Me.lblStudentCount.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblStudentCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStudentCount.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStudentCount.Location = New System.Drawing.Point(700, 8)
            Me.lblStudentCount.Name = "lblStudentCount"
            Me.lblStudentCount.Size = New System.Drawing.Size(285, 19)
            Me.lblStudentCount.TabIndex = 0
            Me.lblStudentCount.Text = "إجمالي عدد الطلاب المسجلين: 5 طلاب"
            Me.lblStudentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvStudents
            '
            Me.dgvStudents.AllowUserToAddRows = False
            Me.dgvStudents.AllowUserToDeleteRows = False
            Me.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvStudents.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvStudents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStudentNumber, Me.colFullName, Me.colMotherName, Me.colNationalId, Me.colClass, Me.colPhone, Me.colAddress, Me.colStatus})
            Me.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvStudents.EnableHeadersVisualStyles = False
            Me.dgvStudents.Location = New System.Drawing.Point(0, 65)
            Me.dgvStudents.Name = "dgvStudents"
            Me.dgvStudents.ReadOnly = True
            Me.dgvStudents.RowHeadersVisible = False
            Me.dgvStudents.RowTemplate.Height = 42
            Me.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvStudents.Size = New System.Drawing.Size(1000, 500)
            Me.dgvStudents.TabIndex = 2
            '
            'colStudentNumber
            '
            Me.colStudentNumber.FillWeight = 85.0!
            Me.colStudentNumber.HeaderText = "الرقم الأكاديمي"
            Me.colStudentNumber.Name = "colStudentNumber"
            Me.colStudentNumber.ReadOnly = True
            '
            'colFullName
            '
            Me.colFullName.FillWeight = 160.0!
            Me.colFullName.HeaderText = "الاسم الخماسي واللقب (عراق)"
            Me.colFullName.Name = "colFullName"
            Me.colFullName.ReadOnly = True
            '
            'colMotherName
            '
            Me.colMotherName.FillWeight = 110.0!
            Me.colMotherName.HeaderText = "اسم الأم الثلاثي"
            Me.colMotherName.Name = "colMotherName"
            Me.colMotherName.ReadOnly = True
            '
            'colNationalId
            '
            Me.colNationalId.FillWeight = 115.0!
            Me.colNationalId.HeaderText = "البطاقة الوطنية / الهوية"
            Me.colNationalId.Name = "colNationalId"
            Me.colNationalId.ReadOnly = True
            '
            'colClass
            '
            Me.colClass.FillWeight = 90.0!
            Me.colClass.HeaderText = "الصف والشعبة"
            Me.colClass.Name = "colClass"
            Me.colClass.ReadOnly = True
            '
            'colPhone
            '
            Me.colPhone.FillWeight = 115.0!
            Me.colPhone.HeaderText = "هاتف ولي الأمر"
            Me.colPhone.Name = "colPhone"
            Me.colPhone.ReadOnly = True
            '
            'colAddress
            '
            Me.colAddress.FillWeight = 130.0!
            Me.colAddress.HeaderText = "العنوان (المحافظة - القضاء)"
            Me.colAddress.Name = "colAddress"
            Me.colAddress.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 70.0!
            Me.colStatus.HeaderText = "الحالة"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'StudentsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(1000, 600)
            Me.Controls.Add(Me.dgvStudents)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "StudentsForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "شؤون الطلاب - جمهورية العراق"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnAddStudent As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnWhatsApp As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnProfile As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents txtSearch As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents cboClassFilter As System.Windows.Forms.ComboBox
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblStudentCount As System.Windows.Forms.Label
        Friend WithEvents dgvStudents As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colStudentNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMotherName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colNationalId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colClass As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAddress As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
