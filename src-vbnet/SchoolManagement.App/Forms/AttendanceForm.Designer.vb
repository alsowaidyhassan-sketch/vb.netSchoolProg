Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AttendanceForm
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
            Me.btnSaveAttendance = New SchoolManagement.App.Controls.ModernButton()
            Me.btnSendWhatsAppAlert = New SchoolManagement.App.Controls.ModernButton()
            Me.btnMarkAllPresent = New SchoolManagement.App.Controls.ModernButton()
            Me.cboClass = New System.Windows.Forms.ComboBox()
            Me.lblClass = New System.Windows.Forms.Label()
            Me.dtpDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblStats = New System.Windows.Forms.Label()
            Me.dgvAttendance = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colStudentNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colParentPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnSaveAttendance)
            Me.pnlTop.Controls.Add(Me.btnSendWhatsAppAlert)
            Me.pnlTop.Controls.Add(Me.btnMarkAllPresent)
            Me.pnlTop.Controls.Add(Me.cboClass)
            Me.pnlTop.Controls.Add(Me.lblClass)
            Me.pnlTop.Controls.Add(Me.dtpDate)
            Me.pnlTop.Controls.Add(Me.lblDate)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 70)
            Me.pnlTop.TabIndex = 0
            '
            'btnSaveAttendance
            '
            Me.btnSaveAttendance.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnSaveAttendance.BorderRadius = 8
            Me.btnSaveAttendance.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveAttendance.FlatAppearance.BorderSize = 0
            Me.btnSaveAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveAttendance.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSaveAttendance.ForeColor = System.Drawing.Color.White
            Me.btnSaveAttendance.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnSaveAttendance.Location = New System.Drawing.Point(12, 14)
            Me.btnSaveAttendance.Name = "btnSaveAttendance"
            Me.btnSaveAttendance.Size = New System.Drawing.Size(140, 40)
            Me.btnSaveAttendance.TabIndex = 6
            Me.btnSaveAttendance.Text = "💾 تثبيت الحضور"
            Me.btnSaveAttendance.UseVisualStyleBackColor = False
            '
            'btnSendWhatsAppAlert
            '
            Me.btnSendWhatsAppAlert.BackColor = System.Drawing.Color.FromArgb(16, 185, 129)
            Me.btnSendWhatsAppAlert.BorderRadius = 8
            Me.btnSendWhatsAppAlert.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSendWhatsAppAlert.FlatAppearance.BorderSize = 0
            Me.btnSendWhatsAppAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSendWhatsAppAlert.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSendWhatsAppAlert.ForeColor = System.Drawing.Color.White
            Me.btnSendWhatsAppAlert.HoverColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.btnSendWhatsAppAlert.Location = New System.Drawing.Point(160, 14)
            Me.btnSendWhatsAppAlert.Name = "btnSendWhatsAppAlert"
            Me.btnSendWhatsAppAlert.Size = New System.Drawing.Size(165, 40)
            Me.btnSendWhatsAppAlert.TabIndex = 5
            Me.btnSendWhatsAppAlert.Text = "📲 إشعار الغياب للواتساب"
            Me.btnSendWhatsAppAlert.UseVisualStyleBackColor = False
            '
            'btnMarkAllPresent
            '
            Me.btnMarkAllPresent.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnMarkAllPresent.BorderRadius = 8
            Me.btnMarkAllPresent.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMarkAllPresent.FlatAppearance.BorderSize = 0
            Me.btnMarkAllPresent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMarkAllPresent.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.btnMarkAllPresent.ForeColor = System.Drawing.Color.White
            Me.btnMarkAllPresent.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnMarkAllPresent.Location = New System.Drawing.Point(335, 14)
            Me.btnMarkAllPresent.Name = "btnMarkAllPresent"
            Me.btnMarkAllPresent.Size = New System.Drawing.Size(125, 40)
            Me.btnMarkAllPresent.TabIndex = 4
            Me.btnMarkAllPresent.Text = "تحديد الكل حاضر"
            Me.btnMarkAllPresent.UseVisualStyleBackColor = False
            '
            'cboClass
            '
            Me.cboClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboClass.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboClass.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboClass.ForeColor = System.Drawing.Color.White
            Me.cboClass.FormattingEnabled = True
            Me.cboClass.Items.AddRange(New Object() {"الرابع العلمي (أ)", "الرابع العلمي (ب)", "الخامس العلمي (أ)", "السادس العلمي (أ)"})
            Me.cboClass.Location = New System.Drawing.Point(520, 22)
            Me.cboClass.Name = "cboClass"
            Me.cboClass.Size = New System.Drawing.Size(160, 25)
            Me.cboClass.TabIndex = 3
            '
            'lblClass
            '
            Me.lblClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblClass.AutoSize = True
            Me.lblClass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblClass.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblClass.Location = New System.Drawing.Point(685, 26)
            Me.lblClass.Name = "lblClass"
            Me.lblClass.Size = New System.Drawing.Size(43, 15)
            Me.lblClass.TabIndex = 2
            Me.lblClass.Text = "الشعبة:"
            '
            'dtpDate
            '
            Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDate.Location = New System.Drawing.Point(740, 22)
            Me.dtpDate.Name = "dtpDate"
            Me.dtpDate.Size = New System.Drawing.Size(140, 25)
            Me.dtpDate.TabIndex = 1
            '
            'lblDate
            '
            Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDate.AutoSize = True
            Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDate.Location = New System.Drawing.Point(885, 26)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(42, 15)
            Me.lblDate.TabIndex = 0
            Me.lblDate.Text = "التاريخ:"
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblStats)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 520)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(950, 40)
            Me.pnlBottom.TabIndex = 1
            '
            'lblStats
            '
            Me.lblStats.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblStats.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.lblStats.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStats.Location = New System.Drawing.Point(15, 8)
            Me.lblStats.Name = "lblStats"
            Me.lblStats.Size = New System.Drawing.Size(920, 24)
            Me.lblStats.TabIndex = 0
            Me.lblStats.Text = "الإحصائية: الحضور (4) | الغياب (1) | إجازة (0) | نسبة الالتزام: 80%"
            Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dgvAttendance
            '
            Me.dgvAttendance.AllowUserToAddRows = False
            Me.dgvAttendance.AllowUserToDeleteRows = False
            Me.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvAttendance.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStudentNumber, Me.colStudentName, Me.colStatus, Me.colNotes, Me.colParentPhone})
            Me.dgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvAttendance.EnableHeadersVisualStyles = False
            Me.dgvAttendance.Location = New System.Drawing.Point(0, 70)
            Me.dgvAttendance.Name = "dgvAttendance"
            Me.dgvAttendance.RowHeadersVisible = False
            Me.dgvAttendance.RowTemplate.Height = 40
            Me.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvAttendance.Size = New System.Drawing.Size(950, 450)
            Me.dgvAttendance.TabIndex = 2
            '
            'colStudentNumber
            '
            Me.colStudentNumber.FillWeight = 80.0!
            Me.colStudentNumber.HeaderText = "الرقم الأكاديمي"
            Me.colStudentNumber.Name = "colStudentNumber"
            Me.colStudentNumber.ReadOnly = True
            '
            'colStudentName
            '
            Me.colStudentName.FillWeight = 180.0!
            Me.colStudentName.HeaderText = "اسم الطالب الرباعي"
            Me.colStudentName.Name = "colStudentName"
            Me.colStudentName.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 90.0!
            Me.colStatus.HeaderText = "حالة الحضور"
            Me.colStatus.Items.AddRange(New Object() {"حاضر", "غائب", "مجاز", "متأخر"})
            Me.colStatus.Name = "colStatus"
            Me.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'colNotes
            '
            Me.colNotes.FillWeight = 130.0!
            Me.colNotes.HeaderText = "ملاحظات وتبرير الغياب"
            Me.colNotes.Name = "colNotes"
            '
            'colParentPhone
            '
            Me.colParentPhone.FillWeight = 110.0!
            Me.colParentPhone.HeaderText = "هاتف ولي الأمر"
            Me.colParentPhone.Name = "colParentPhone"
            Me.colParentPhone.ReadOnly = True
            '
            'AttendanceForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvAttendance)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "AttendanceForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "تسجيل الحضور والغياب اليومي"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents cboClass As System.Windows.Forms.ComboBox
        Friend WithEvents lblClass As System.Windows.Forms.Label
        Friend WithEvents btnMarkAllPresent As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnSendWhatsAppAlert As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnSaveAttendance As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblStats As System.Windows.Forms.Label
        Friend WithEvents dgvAttendance As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colStudentNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStudentName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colParentPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
