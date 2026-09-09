Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SettingsForm
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
            Me.btnSaveSettings = New SchoolManagement.App.Controls.ModernButton()
            Me.btnBackupDatabase = New SchoolManagement.App.Controls.ModernButton()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlContent = New System.Windows.Forms.Panel()
            Me.grpDatabase = New System.Windows.Forms.GroupBox()
            Me.btnTestConnection = New SchoolManagement.App.Controls.ModernButton()
            Me.txtDbServer = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblDbServer = New System.Windows.Forms.Label()
            Me.txtDbName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblDbName = New System.Windows.Forms.Label()
            Me.grpGeneral = New System.Windows.Forms.GroupBox()
            Me.txtSchoolName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblSchoolName = New System.Windows.Forms.Label()
            Me.txtDirectorName = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblDirector = New System.Windows.Forms.Label()
            Me.cboGovernorate = New System.Windows.Forms.ComboBox()
            Me.lblGovernorate = New System.Windows.Forms.Label()
            Me.txtAcademicYear = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblAcademicYear = New System.Windows.Forms.Label()
            Me.txtPhone = New SchoolManagement.App.Controls.ModernTextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.pnlTop.SuspendLayout()
            Me.pnlContent.SuspendLayout()
            Me.grpDatabase.SuspendLayout()
            Me.grpGeneral.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnSaveSettings)
            Me.pnlTop.Controls.Add(Me.btnBackupDatabase)
            Me.pnlTop.Controls.Add(Me.lblTitle)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnSaveSettings
            '
            Me.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnSaveSettings.BorderRadius = 8
            Me.btnSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveSettings.FlatAppearance.BorderSize = 0
            Me.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveSettings.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSaveSettings.ForeColor = System.Drawing.Color.White
            Me.btnSaveSettings.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnSaveSettings.Location = New System.Drawing.Point(12, 12)
            Me.btnSaveSettings.Name = "btnSaveSettings"
            Me.btnSaveSettings.Size = New System.Drawing.Size(150, 40)
            Me.btnSaveSettings.TabIndex = 0
            Me.btnSaveSettings.Text = "💾 حفظ الإعدادات"
            Me.btnSaveSettings.UseVisualStyleBackColor = False
            '
            'btnBackupDatabase
            '
            Me.btnBackupDatabase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129)
            Me.btnBackupDatabase.BorderRadius = 8
            Me.btnBackupDatabase.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBackupDatabase.FlatAppearance.BorderSize = 0
            Me.btnBackupDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBackupDatabase.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnBackupDatabase.ForeColor = System.Drawing.Color.White
            Me.btnBackupDatabase.HoverColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.btnBackupDatabase.Location = New System.Drawing.Point(170, 12)
            Me.btnBackupDatabase.Name = "btnBackupDatabase"
            Me.btnBackupDatabase.Size = New System.Drawing.Size(175, 40)
            Me.btnBackupDatabase.TabIndex = 1
            Me.btnBackupDatabase.Text = "💾 نسخ احتياطي لقاعدة البيانات"
            Me.btnBackupDatabase.UseVisualStyleBackColor = False
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTitle.Location = New System.Drawing.Point(740, 22)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(193, 20)
            Me.lblTitle.TabIndex = 2
            Me.lblTitle.Text = "⚙️ إعدادات النظام والمدرسة"
            '
            'pnlContent
            '
            Me.pnlContent.AutoScroll = True
            Me.pnlContent.Controls.Add(Me.grpDatabase)
            Me.pnlContent.Controls.Add(Me.grpGeneral)
            Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContent.Location = New System.Drawing.Point(0, 65)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
            Me.pnlContent.Size = New System.Drawing.Size(950, 495)
            Me.pnlContent.TabIndex = 1
            '
            'grpDatabase
            '
            Me.grpDatabase.Controls.Add(Me.btnTestConnection)
            Me.grpDatabase.Controls.Add(Me.txtDbServer)
            Me.grpDatabase.Controls.Add(Me.lblDbServer)
            Me.grpDatabase.Controls.Add(Me.txtDbName)
            Me.grpDatabase.Controls.Add(Me.lblDbName)
            Me.grpDatabase.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpDatabase.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.grpDatabase.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpDatabase.Location = New System.Drawing.Point(20, 225)
            Me.grpDatabase.Name = "grpDatabase"
            Me.grpDatabase.Padding = New System.Windows.Forms.Padding(15)
            Me.grpDatabase.Size = New System.Drawing.Size(910, 160)
            Me.grpDatabase.TabIndex = 1
            Me.grpDatabase.TabStop = False
            Me.grpDatabase.Text = "إعدادات الاتصال بقاعدة بيانات SQL Server"
            '
            'btnTestConnection
            '
            Me.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnTestConnection.BorderRadius = 8
            Me.btnTestConnection.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnTestConnection.FlatAppearance.BorderSize = 0
            Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.btnTestConnection.ForeColor = System.Drawing.Color.White
            Me.btnTestConnection.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnTestConnection.Location = New System.Drawing.Point(20, 105)
            Me.btnTestConnection.Name = "btnTestConnection"
            Me.btnTestConnection.Size = New System.Drawing.Size(160, 35)
            Me.btnTestConnection.TabIndex = 4
            Me.btnTestConnection.Text = "🔌 فحص الاتصال بالسيرفر"
            Me.btnTestConnection.UseVisualStyleBackColor = False
            '
            'txtDbServer
            '
            Me.txtDbServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbServer.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtDbServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDbServer.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDbServer.ForeColor = System.Drawing.Color.White
            Me.txtDbServer.Location = New System.Drawing.Point(470, 55)
            Me.txtDbServer.Name = "txtDbServer"
            Me.txtDbServer.Size = New System.Drawing.Size(300, 25)
            Me.txtDbServer.TabIndex = 1
            Me.txtDbServer.Text = ".\SQLEXPRESS"
            '
            'lblDbServer
            '
            Me.lblDbServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbServer.AutoSize = True
            Me.lblDbServer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblDbServer.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDbServer.Location = New System.Drawing.Point(780, 58)
            Me.lblDbServer.Name = "lblDbServer"
            Me.lblDbServer.Size = New System.Drawing.Size(109, 15)
            Me.lblDbServer.TabIndex = 0
            Me.lblDbServer.Text = "خادم SQL Server:"
            '
            'txtDbName
            '
            Me.txtDbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDbName.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtDbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDbName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDbName.ForeColor = System.Drawing.Color.White
            Me.txtDbName.Location = New System.Drawing.Point(20, 55)
            Me.txtDbName.Name = "txtDbName"
            Me.txtDbName.Size = New System.Drawing.Size(300, 25)
            Me.txtDbName.TabIndex = 3
            Me.txtDbName.Text = "SchoolManagementDb"
            '
            'lblDbName
            '
            Me.lblDbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDbName.AutoSize = True
            Me.lblDbName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblDbName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDbName.Location = New System.Drawing.Point(330, 58)
            Me.lblDbName.Name = "lblDbName"
            Me.lblDbName.Size = New System.Drawing.Size(95, 15)
            Me.lblDbName.TabIndex = 2
            Me.lblDbName.Text = "اسم قاعدة البيانات:"
            '
            'grpGeneral
            '
            Me.grpGeneral.Controls.Add(Me.txtPhone)
            Me.grpGeneral.Controls.Add(Me.lblPhone)
            Me.grpGeneral.Controls.Add(Me.txtAcademicYear)
            Me.grpGeneral.Controls.Add(Me.lblAcademicYear)
            Me.grpGeneral.Controls.Add(Me.cboGovernorate)
            Me.grpGeneral.Controls.Add(Me.lblGovernorate)
            Me.grpGeneral.Controls.Add(Me.txtDirectorName)
            Me.grpGeneral.Controls.Add(Me.lblDirector)
            Me.grpGeneral.Controls.Add(Me.txtSchoolName)
            Me.grpGeneral.Controls.Add(Me.lblSchoolName)
            Me.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpGeneral.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.grpGeneral.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253)
            Me.grpGeneral.Location = New System.Drawing.Point(20, 20)
            Me.grpGeneral.Name = "grpGeneral"
            Me.grpGeneral.Padding = New System.Windows.Forms.Padding(15)
            Me.grpGeneral.Size = New System.Drawing.Size(910, 205)
            Me.grpGeneral.TabIndex = 0
            Me.grpGeneral.TabStop = False
            Me.grpGeneral.Text = "المعلومات العامة للمؤسسة التعليمية"
            '
            'txtSchoolName
            '
            Me.txtSchoolName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSchoolName.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtSchoolName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSchoolName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtSchoolName.ForeColor = System.Drawing.Color.White
            Me.txtSchoolName.Location = New System.Drawing.Point(470, 40)
            Me.txtSchoolName.Name = "txtSchoolName"
            Me.txtSchoolName.Size = New System.Drawing.Size(300, 25)
            Me.txtSchoolName.TabIndex = 1
            Me.txtSchoolName.Text = "ثانوية دجلة الأهلية للبنين"
            '
            'lblSchoolName
            '
            Me.lblSchoolName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSchoolName.AutoSize = True
            Me.lblSchoolName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblSchoolName.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblSchoolName.Location = New System.Drawing.Point(780, 43)
            Me.lblSchoolName.Name = "lblSchoolName"
            Me.lblSchoolName.Size = New System.Drawing.Size(73, 15)
            Me.lblSchoolName.TabIndex = 0
            Me.lblSchoolName.Text = "اسم المدرسة:"
            '
            'txtDirectorName
            '
            Me.txtDirectorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDirectorName.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtDirectorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDirectorName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtDirectorName.ForeColor = System.Drawing.Color.White
            Me.txtDirectorName.Location = New System.Drawing.Point(20, 40)
            Me.txtDirectorName.Name = "txtDirectorName"
            Me.txtDirectorName.Size = New System.Drawing.Size(300, 25)
            Me.txtDirectorName.TabIndex = 3
            Me.txtDirectorName.Text = "الأستاذ الدكتور صباح كريم الشمري"
            '
            'lblDirector
            '
            Me.lblDirector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDirector.AutoSize = True
            Me.lblDirector.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblDirector.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblDirector.Location = New System.Drawing.Point(330, 43)
            Me.lblDirector.Name = "lblDirector"
            Me.lblDirector.Size = New System.Drawing.Size(71, 15)
            Me.lblDirector.TabIndex = 2
            Me.lblDirector.Text = "مدير المدرسة:"
            '
            'cboGovernorate
            '
            Me.cboGovernorate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboGovernorate.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboGovernorate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboGovernorate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboGovernorate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboGovernorate.ForeColor = System.Drawing.Color.White
            Me.cboGovernorate.FormattingEnabled = True
            Me.cboGovernorate.Items.AddRange(New Object() {"بغداد - الكرخ الأولى", "بغداد - الكرخ الثانية", "بغداد - الرصافة الأولى", "بغداد - الرصافة الثانية", "البصرة", "نينوى", "أربيل", "النجف الأشرف", "كربلاء المقدسة", "بابل", "واسط", "صلاح الدين"})
            Me.cboGovernorate.Location = New System.Drawing.Point(470, 95)
            Me.cboGovernorate.Name = "cboGovernorate"
            Me.cboGovernorate.Size = New System.Drawing.Size(300, 25)
            Me.cboGovernorate.TabIndex = 5
            '
            'lblGovernorate
            '
            Me.lblGovernorate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGovernorate.AutoSize = True
            Me.lblGovernorate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblGovernorate.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblGovernorate.Location = New System.Drawing.Point(780, 98)
            Me.lblGovernorate.Name = "lblGovernorate"
            Me.lblGovernorate.Size = New System.Drawing.Size(126, 15)
            Me.lblGovernorate.TabIndex = 4
            Me.lblGovernorate.Text = "المديرية العامة للتربية:"
            '
            'txtAcademicYear
            '
            Me.txtAcademicYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAcademicYear.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtAcademicYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAcademicYear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtAcademicYear.ForeColor = System.Drawing.Color.White
            Me.txtAcademicYear.Location = New System.Drawing.Point(20, 95)
            Me.txtAcademicYear.Name = "txtAcademicYear"
            Me.txtAcademicYear.Size = New System.Drawing.Size(300, 25)
            Me.txtAcademicYear.TabIndex = 7
            Me.txtAcademicYear.Text = "2024 - 2025"
            '
            'lblAcademicYear
            '
            Me.lblAcademicYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAcademicYear.AutoSize = True
            Me.lblAcademicYear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblAcademicYear.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblAcademicYear.Location = New System.Drawing.Point(330, 98)
            Me.lblAcademicYear.Name = "lblAcademicYear"
            Me.lblAcademicYear.Size = New System.Drawing.Size(76, 15)
            Me.lblAcademicYear.TabIndex = 6
            Me.lblAcademicYear.Text = "العام الدراسي:"
            '
            'txtPhone
            '
            Me.txtPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtPhone.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.txtPhone.ForeColor = System.Drawing.Color.White
            Me.txtPhone.Location = New System.Drawing.Point(470, 150)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(300, 25)
            Me.txtPhone.TabIndex = 9
            Me.txtPhone.Text = "07801122334"
            '
            'lblPhone
            '
            Me.lblPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblPhone.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblPhone.Location = New System.Drawing.Point(780, 153)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(95, 15)
            Me.lblPhone.TabIndex = 8
            Me.lblPhone.Text = "هاتف الإدارة العامة:"
            '
            'SettingsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.pnlContent)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "SettingsForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "إعدادات النظام"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlContent.ResumeLayout(False)
            Me.grpDatabase.ResumeLayout(False)
            Me.grpDatabase.PerformLayout()
            Me.grpGeneral.ResumeLayout(False)
            Me.grpGeneral.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnSaveSettings As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnBackupDatabase As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
        Friend WithEvents txtSchoolName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblSchoolName As System.Windows.Forms.Label
        Friend WithEvents txtDirectorName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblDirector As System.Windows.Forms.Label
        Friend WithEvents cboGovernorate As System.Windows.Forms.ComboBox
        Friend WithEvents lblGovernorate As System.Windows.Forms.Label
        Friend WithEvents txtAcademicYear As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblAcademicYear As System.Windows.Forms.Label
        Friend WithEvents txtPhone As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents grpDatabase As System.Windows.Forms.GroupBox
        Friend WithEvents txtDbServer As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblDbServer As System.Windows.Forms.Label
        Friend WithEvents txtDbName As SchoolManagement.App.Controls.ModernTextBox
        Friend WithEvents lblDbName As System.Windows.Forms.Label
        Friend WithEvents btnTestConnection As SchoolManagement.App.Controls.ModernButton
    End Class
End Namespace
