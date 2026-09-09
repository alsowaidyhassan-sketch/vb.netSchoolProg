Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TeachersForm
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
            Me.btnAddTeacher = New SchoolManagement.App.Controls.ModernButton()
            Me.btnEditTeacher = New SchoolManagement.App.Controls.ModernButton()
            Me.txtSearch = New SchoolManagement.App.Controls.ModernTextBox()
            Me.cboSpecialtyFilter = New System.Windows.Forms.ComboBox()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblTeacherCount = New System.Windows.Forms.Label()
            Me.dgvTeachers = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colStaffId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTeacherName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSpecialization = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDegree = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colWeeklyHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvTeachers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnAddTeacher)
            Me.pnlTop.Controls.Add(Me.btnEditTeacher)
            Me.pnlTop.Controls.Add(Me.txtSearch)
            Me.pnlTop.Controls.Add(Me.cboSpecialtyFilter)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnAddTeacher
            '
            Me.btnAddTeacher.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnAddTeacher.BorderRadius = 8
            Me.btnAddTeacher.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddTeacher.FlatAppearance.BorderSize = 0
            Me.btnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddTeacher.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnAddTeacher.ForeColor = System.Drawing.Color.White
            Me.btnAddTeacher.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnAddTeacher.Location = New System.Drawing.Point(12, 12)
            Me.btnAddTeacher.Name = "btnAddTeacher"
            Me.btnAddTeacher.Size = New System.Drawing.Size(160, 40)
            Me.btnAddTeacher.TabIndex = 0
            Me.btnAddTeacher.Text = "➕ إضافة تدريسي جديد"
            Me.btnAddTeacher.UseVisualStyleBackColor = False
            '
            'btnEditTeacher
            '
            Me.btnEditTeacher.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnEditTeacher.BorderRadius = 8
            Me.btnEditTeacher.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnEditTeacher.FlatAppearance.BorderSize = 0
            Me.btnEditTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEditTeacher.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnEditTeacher.ForeColor = System.Drawing.Color.White
            Me.btnEditTeacher.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnEditTeacher.Location = New System.Drawing.Point(180, 12)
            Me.btnEditTeacher.Name = "btnEditTeacher"
            Me.btnEditTeacher.Size = New System.Drawing.Size(120, 40)
            Me.btnEditTeacher.TabIndex = 1
            Me.btnEditTeacher.Text = "✏️ تعديل البيانات"
            Me.btnEditTeacher.UseVisualStyleBackColor = False
            '
            'txtSearch
            '
            Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtSearch.ForeColor = System.Drawing.Color.White
            Me.txtSearch.Location = New System.Drawing.Point(660, 18)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.PlaceholderText = "بحث باسم المعلم أو التخصص أو الهاتف..."
            Me.txtSearch.Size = New System.Drawing.Size(275, 25)
            Me.txtSearch.TabIndex = 2
            '
            'cboSpecialtyFilter
            '
            Me.cboSpecialtyFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboSpecialtyFilter.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboSpecialtyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSpecialtyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboSpecialtyFilter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboSpecialtyFilter.ForeColor = System.Drawing.Color.White
            Me.cboSpecialtyFilter.FormattingEnabled = True
            Me.cboSpecialtyFilter.Items.AddRange(New Object() {"جميع التخصصات", "اللغة العربية", "اللغة الإنجليزية", "الرياضيات", "الفيزياء", "الكيمياء", "الأحياء", "التربية الإسلامية", "الحاسوب"})
            Me.cboSpecialtyFilter.Location = New System.Drawing.Point(470, 18)
            Me.cboSpecialtyFilter.Name = "cboSpecialtyFilter"
            Me.cboSpecialtyFilter.Size = New System.Drawing.Size(175, 25)
            Me.cboSpecialtyFilter.TabIndex = 3
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblTeacherCount)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 525)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(950, 35)
            Me.pnlBottom.TabIndex = 1
            '
            'lblTeacherCount
            '
            Me.lblTeacherCount.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblTeacherCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTeacherCount.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblTeacherCount.Location = New System.Drawing.Point(650, 8)
            Me.lblTeacherCount.Name = "lblTeacherCount"
            Me.lblTeacherCount.Size = New System.Drawing.Size(285, 19)
            Me.lblTeacherCount.TabIndex = 0
            Me.lblTeacherCount.Text = "إجمالي عدد الكادر التدريسي: 4 معلمين"
            Me.lblTeacherCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvTeachers
            '
            Me.dgvTeachers.AllowUserToAddRows = False
            Me.dgvTeachers.AllowUserToDeleteRows = False
            Me.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvTeachers.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvTeachers.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvTeachers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStaffId, Me.colTeacherName, Me.colSpecialization, Me.colDegree, Me.colPhone, Me.colWeeklyHours, Me.colStatus})
            Me.dgvTeachers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvTeachers.EnableHeadersVisualStyles = False
            Me.dgvTeachers.Location = New System.Drawing.Point(0, 65)
            Me.dgvTeachers.Name = "dgvTeachers"
            Me.dgvTeachers.ReadOnly = True
            Me.dgvTeachers.RowHeadersVisible = False
            Me.dgvTeachers.RowTemplate.Height = 40
            Me.dgvTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvTeachers.Size = New System.Drawing.Size(950, 460)
            Me.dgvTeachers.TabIndex = 2
            '
            'colStaffId
            '
            Me.colStaffId.FillWeight = 85.0!
            Me.colStaffId.HeaderText = "الرقم الوظيفي"
            Me.colStaffId.Name = "colStaffId"
            Me.colStaffId.ReadOnly = True
            '
            'colTeacherName
            '
            Me.colTeacherName.FillWeight = 160.0!
            Me.colTeacherName.HeaderText = "اسم التدريسي الرباعي واللقب"
            Me.colTeacherName.Name = "colTeacherName"
            Me.colTeacherName.ReadOnly = True
            '
            'colSpecialization
            '
            Me.colSpecialization.FillWeight = 110.0!
            Me.colSpecialization.HeaderText = "التخصص الدقيق"
            Me.colSpecialization.Name = "colSpecialization"
            Me.colSpecialization.ReadOnly = True
            '
            'colDegree
            '
            Me.colDegree.FillWeight = 100.0!
            Me.colDegree.HeaderText = "المؤهل العلمي"
            Me.colDegree.Name = "colDegree"
            Me.colDegree.ReadOnly = True
            '
            'colPhone
            '
            Me.colPhone.FillWeight = 110.0!
            Me.colPhone.HeaderText = "رقم الهاتف"
            Me.colPhone.Name = "colPhone"
            Me.colPhone.ReadOnly = True
            '
            'colWeeklyHours
            '
            Me.colWeeklyHours.FillWeight = 75.0!
            Me.colWeeklyHours.HeaderText = "النصاب الأسبوعي"
            Me.colWeeklyHours.Name = "colWeeklyHours"
            Me.colWeeklyHours.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 75.0!
            Me.colStatus.HeaderText = "الحالة"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'TeachersForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvTeachers)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "TeachersForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "الهيئة التدريسية"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvTeachers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnAddTeacher As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnEditTeacher As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents txtSearch As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents cboSpecialtyFilter As System.Windows.Forms.ComboBox
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblTeacherCount As System.Windows.Forms.Label
        Friend WithEvents dgvTeachers As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colStaffId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTeacherName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSpecialization As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDegree As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colWeeklyHours As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
