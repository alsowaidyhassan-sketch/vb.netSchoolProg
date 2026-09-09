Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MainForm
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
            Me.components = New System.ComponentModel.Container()
            Me.pnlSidebar = New System.Windows.Forms.Panel()
            Me.flpNavButtons = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnNavDashboard = New System.Windows.Forms.Button()
            Me.btnNavStudents = New System.Windows.Forms.Button()
            Me.btnNavTeachers = New System.Windows.Forms.Button()
            Me.btnNavAttendance = New System.Windows.Forms.Button()
            Me.btnNavClasses = New System.Windows.Forms.Button()
            Me.btnNavSubjects = New System.Windows.Forms.Button()
            Me.btnNavExams = New System.Windows.Forms.Button()
            Me.btnNavGrades = New System.Windows.Forms.Button()
            Me.btnNavFinance = New System.Windows.Forms.Button()
            Me.btnNavReports = New System.Windows.Forms.Button()
            Me.btnNavSettings = New System.Windows.Forms.Button()
            Me.pnlSidebarHeader = New System.Windows.Forms.Panel()
            Me.lblAppSubtitle = New System.Windows.Forms.Label()
            Me.lblAppTitle = New System.Windows.Forms.Label()
            Me.pnlTopBar = New System.Windows.Forms.Panel()
            Me.lblDbConnectionStatus = New System.Windows.Forms.Label()
            Me.lblCurrentUser = New System.Windows.Forms.Label()
            Me.lblTopTitle = New System.Windows.Forms.Label()
            Me.pnlStatusBar = New System.Windows.Forms.Panel()
            Me.lblStatusTime = New System.Windows.Forms.Label()
            Me.lblStatusInfo = New System.Windows.Forms.Label()
            Me.tabMain = New Krypton.Navigator.KryptonNavigator()
            Me.tabDashboard = New Krypton.Navigator.KryptonPage()
            Me.pnlDashboardContent = New System.Windows.Forms.Panel()
            Me.lblDashboardWelcome = New System.Windows.Forms.Label()
            Me.pnlSidebar.SuspendLayout()
            Me.flpNavButtons.SuspendLayout()
            Me.pnlSidebarHeader.SuspendLayout()
            Me.pnlTopBar.SuspendLayout()
            Me.pnlStatusBar.SuspendLayout()
            Me.tabMain.SuspendLayout()
            Me.tabDashboard.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlSidebar
            '
            Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.pnlSidebar.Controls.Add(Me.flpNavButtons)
            Me.pnlSidebar.Controls.Add(Me.pnlSidebarHeader)
            Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlSidebar.Location = New System.Drawing.Point(984, 0)
            Me.pnlSidebar.Name = "pnlSidebar"
            Me.pnlSidebar.Size = New System.Drawing.Size(280, 761)
            Me.pnlSidebar.TabIndex = 0
            '
            'flpNavButtons
            '
            Me.flpNavButtons.AutoScroll = True
            Me.flpNavButtons.Controls.Add(Me.btnNavDashboard)
            Me.flpNavButtons.Controls.Add(Me.btnNavStudents)
            Me.flpNavButtons.Controls.Add(Me.btnNavTeachers)
            Me.flpNavButtons.Controls.Add(Me.btnNavAttendance)
            Me.flpNavButtons.Controls.Add(Me.btnNavClasses)
            Me.flpNavButtons.Controls.Add(Me.btnNavSubjects)
            Me.flpNavButtons.Controls.Add(Me.btnNavExams)
            Me.flpNavButtons.Controls.Add(Me.btnNavGrades)
            Me.flpNavButtons.Controls.Add(Me.btnNavFinance)
            Me.flpNavButtons.Controls.Add(Me.btnNavReports)
            Me.flpNavButtons.Controls.Add(Me.btnNavSettings)
            Me.flpNavButtons.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpNavButtons.Location = New System.Drawing.Point(0, 75)
            Me.flpNavButtons.Name = "flpNavButtons"
            Me.flpNavButtons.Padding = New System.Windows.Forms.Padding(10)
            Me.flpNavButtons.Size = New System.Drawing.Size(280, 686)
            Me.flpNavButtons.TabIndex = 1
            '
            'btnNavDashboard
            '
            Me.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnNavDashboard.FlatAppearance.BorderSize = 0
            Me.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnNavDashboard.ForeColor = System.Drawing.Color.White
            Me.btnNavDashboard.Location = New System.Drawing.Point(17, 13)
            Me.btnNavDashboard.Name = "btnNavDashboard"
            Me.btnNavDashboard.Size = New System.Drawing.Size(240, 42)
            Me.btnNavDashboard.TabIndex = 0
            Me.btnNavDashboard.Text = "📊 لوحة التحكم الرئيسية"
            Me.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavDashboard.UseVisualStyleBackColor = False
            '
            'btnNavStudents
            '
            Me.btnNavStudents.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavStudents.FlatAppearance.BorderSize = 0
            Me.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavStudents.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavStudents.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavStudents.Location = New System.Drawing.Point(17, 61)
            Me.btnNavStudents.Name = "btnNavStudents"
            Me.btnNavStudents.Size = New System.Drawing.Size(240, 42)
            Me.btnNavStudents.TabIndex = 1
            Me.btnNavStudents.Text = "🎓 شؤون الطلاب (العراق)"
            Me.btnNavStudents.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavStudents.UseVisualStyleBackColor = False
            '
            'btnNavTeachers
            '
            Me.btnNavTeachers.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavTeachers.FlatAppearance.BorderSize = 0
            Me.btnNavTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavTeachers.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavTeachers.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavTeachers.Location = New System.Drawing.Point(17, 109)
            Me.btnNavTeachers.Name = "btnNavTeachers"
            Me.btnNavTeachers.Size = New System.Drawing.Size(240, 42)
            Me.btnNavTeachers.TabIndex = 2
            Me.btnNavTeachers.Text = "👨‍🏫 الهيئة التدريسية"
            Me.btnNavTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavTeachers.UseVisualStyleBackColor = False
            '
            'btnNavAttendance
            '
            Me.btnNavAttendance.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavAttendance.FlatAppearance.BorderSize = 0
            Me.btnNavAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavAttendance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavAttendance.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavAttendance.Location = New System.Drawing.Point(17, 157)
            Me.btnNavAttendance.Name = "btnNavAttendance"
            Me.btnNavAttendance.Size = New System.Drawing.Size(240, 42)
            Me.btnNavAttendance.TabIndex = 3
            Me.btnNavAttendance.Text = "📅 الحضور والغياب الذكي"
            Me.btnNavAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavAttendance.UseVisualStyleBackColor = False
            '
            'btnNavClasses
            '
            Me.btnNavClasses.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavClasses.FlatAppearance.BorderSize = 0
            Me.btnNavClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavClasses.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavClasses.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavClasses.Location = New System.Drawing.Point(17, 205)
            Me.btnNavClasses.Name = "btnNavClasses"
            Me.btnNavClasses.Size = New System.Drawing.Size(240, 42)
            Me.btnNavClasses.TabIndex = 4
            Me.btnNavClasses.Text = "🏫 الصفوف والشعب"
            Me.btnNavClasses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavClasses.UseVisualStyleBackColor = False
            '
            'btnNavSubjects
            '
            Me.btnNavSubjects.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavSubjects.FlatAppearance.BorderSize = 0
            Me.btnNavSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavSubjects.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavSubjects.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavSubjects.Location = New System.Drawing.Point(17, 253)
            Me.btnNavSubjects.Name = "btnNavSubjects"
            Me.btnNavSubjects.Size = New System.Drawing.Size(240, 42)
            Me.btnNavSubjects.TabIndex = 5
            Me.btnNavSubjects.Text = "📚 المواد والمناهج"
            Me.btnNavSubjects.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavSubjects.UseVisualStyleBackColor = False
            '
            'btnNavExams
            '
            Me.btnNavExams.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavExams.FlatAppearance.BorderSize = 0
            Me.btnNavExams.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavExams.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavExams.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavExams.Location = New System.Drawing.Point(17, 301)
            Me.btnNavExams.Name = "btnNavExams"
            Me.btnNavExams.Size = New System.Drawing.Size(240, 42)
            Me.btnNavExams.TabIndex = 6
            Me.btnNavExams.Text = "📝 الامتحانات والجداول"
            Me.btnNavExams.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavExams.UseVisualStyleBackColor = False
            '
            'btnNavGrades
            '
            Me.btnNavGrades.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavGrades.FlatAppearance.BorderSize = 0
            Me.btnNavGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavGrades.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavGrades.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavGrades.Location = New System.Drawing.Point(17, 349)
            Me.btnNavGrades.Name = "btnNavGrades"
            Me.btnNavGrades.Size = New System.Drawing.Size(240, 42)
            Me.btnNavGrades.TabIndex = 7
            Me.btnNavGrades.Text = "📈 الدرجات والشهادات"
            Me.btnNavGrades.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavGrades.UseVisualStyleBackColor = False
            '
            'btnNavFinance
            '
            Me.btnNavFinance.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavFinance.FlatAppearance.BorderSize = 0
            Me.btnNavFinance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavFinance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavFinance.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavFinance.Location = New System.Drawing.Point(17, 397)
            Me.btnNavFinance.Name = "btnNavFinance"
            Me.btnNavFinance.Size = New System.Drawing.Size(240, 42)
            Me.btnNavFinance.TabIndex = 8
            Me.btnNavFinance.Text = "💰 المالية والأقساط (IQD)"
            Me.btnNavFinance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavFinance.UseVisualStyleBackColor = False
            '
            'btnNavReports
            '
            Me.btnNavReports.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavReports.FlatAppearance.BorderSize = 0
            Me.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavReports.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavReports.Location = New System.Drawing.Point(17, 445)
            Me.btnNavReports.Name = "btnNavReports"
            Me.btnNavReports.Size = New System.Drawing.Size(240, 42)
            Me.btnNavReports.TabIndex = 9
            Me.btnNavReports.Text = "📑 التقارير والإحصائيات"
            Me.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavReports.UseVisualStyleBackColor = False
            '
            'btnNavSettings
            '
            Me.btnNavSettings.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.btnNavSettings.FlatAppearance.BorderSize = 0
            Me.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavSettings.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.btnNavSettings.Location = New System.Drawing.Point(17, 493)
            Me.btnNavSettings.Name = "btnNavSettings"
            Me.btnNavSettings.Size = New System.Drawing.Size(240, 42)
            Me.btnNavSettings.TabIndex = 10
            Me.btnNavSettings.Text = "⚙️ إعدادات النظام"
            Me.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnNavSettings.UseVisualStyleBackColor = False
            '
            'pnlSidebarHeader
            '
            Me.pnlSidebarHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlSidebarHeader.Controls.Add(Me.lblAppSubtitle)
            Me.pnlSidebarHeader.Controls.Add(Me.lblAppTitle)
            Me.pnlSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlSidebarHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlSidebarHeader.Name = "pnlSidebarHeader"
            Me.pnlSidebarHeader.Size = New System.Drawing.Size(280, 75)
            Me.pnlSidebarHeader.TabIndex = 0
            '
            'lblAppSubtitle
            '
            Me.lblAppSubtitle.AutoSize = True
            Me.lblAppSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblAppSubtitle.Location = New System.Drawing.Point(40, 42)
            Me.lblAppSubtitle.Name = "lblAppSubtitle"
            Me.lblAppSubtitle.Size = New System.Drawing.Size(189, 15)
            Me.lblAppSubtitle.TabIndex = 1
            Me.lblAppSubtitle.Text = "نظام إدارة المدارس - جمهورية العراق"
            '
            'lblAppTitle
            '
            Me.lblAppTitle.AutoSize = True
            Me.lblAppTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblAppTitle.Location = New System.Drawing.Point(50, 16)
            Me.lblAppTitle.Name = "lblAppTitle"
            Me.lblAppTitle.Size = New System.Drawing.Size(175, 21)
            Me.lblAppTitle.TabIndex = 0
            Me.lblAppTitle.Text = "ثانوية دجلة الأهلية للبنين"
            '
            'pnlTopBar
            '
            Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTopBar.Controls.Add(Me.lblDbConnectionStatus)
            Me.pnlTopBar.Controls.Add(Me.lblCurrentUser)
            Me.pnlTopBar.Controls.Add(Me.lblTopTitle)
            Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTopBar.Location = New System.Drawing.Point(0, 0)
            Me.pnlTopBar.Name = "pnlTopBar"
            Me.pnlTopBar.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlTopBar.Size = New System.Drawing.Size(984, 60)
            Me.pnlTopBar.TabIndex = 1
            '
            'lblDbConnectionStatus
            '
            Me.lblDbConnectionStatus.BackColor = System.Drawing.Color.FromArgb(6, 78, 59)
            Me.lblDbConnectionStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
            Me.lblDbConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.lblDbConnectionStatus.Location = New System.Drawing.Point(15, 16)
            Me.lblDbConnectionStatus.Name = "lblDbConnectionStatus"
            Me.lblDbConnectionStatus.Size = New System.Drawing.Size(160, 28)
            Me.lblDbConnectionStatus.TabIndex = 2
            Me.lblDbConnectionStatus.Text = "🟢 SQL Server: متصل"
            Me.lblDbConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCurrentUser
            '
            Me.lblCurrentUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblCurrentUser.AutoSize = True
            Me.lblCurrentUser.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblCurrentUser.Location = New System.Drawing.Point(750, 22)
            Me.lblCurrentUser.Name = "lblCurrentUser"
            Me.lblCurrentUser.Size = New System.Drawing.Size(170, 17)
            Me.lblCurrentUser.TabIndex = 1
            Me.lblCurrentUser.Text = "👤 المدير العام (أحمد العراقي)"
            '
            'lblTopTitle
            '
            Me.lblTopTitle.AutoSize = True
            Me.lblTopTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.lblTopTitle.Location = New System.Drawing.Point(200, 20)
            Me.lblTopTitle.Name = "lblTopTitle"
            Me.lblTopTitle.Size = New System.Drawing.Size(326, 20)
            Me.lblTopTitle.TabIndex = 0
            Me.lblTopTitle.Text = "النظام العراقي المتكامل لإدارة المدارس الأهلية والحكومية"
            '
            'pnlStatusBar
            '
            Me.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.pnlStatusBar.Controls.Add(Me.lblStatusTime)
            Me.pnlStatusBar.Controls.Add(Me.lblStatusInfo)
            Me.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlStatusBar.Location = New System.Drawing.Point(0, 731)
            Me.pnlStatusBar.Name = "pnlStatusBar"
            Me.pnlStatusBar.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
            Me.pnlStatusBar.Size = New System.Drawing.Size(984, 30)
            Me.pnlStatusBar.TabIndex = 2
            '
            'lblStatusTime
            '
            Me.lblStatusTime.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblStatusTime.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblStatusTime.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStatusTime.Location = New System.Drawing.Point(10, 5)
            Me.lblStatusTime.Name = "lblStatusTime"
            Me.lblStatusTime.Size = New System.Drawing.Size(200, 20)
            Me.lblStatusTime.TabIndex = 1
            Me.lblStatusTime.Text = "التوقيت: بغداد (GMT+3)"
            Me.lblStatusTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatusInfo
            '
            Me.lblStatusInfo.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblStatusInfo.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblStatusInfo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStatusInfo.Location = New System.Drawing.Point(674, 5)
            Me.lblStatusInfo.Name = "lblStatusInfo"
            Me.lblStatusInfo.Size = New System.Drawing.Size(300, 20)
            Me.lblStatusInfo.TabIndex = 0
            Me.lblStatusInfo.Text = "الإصدار 2.5 (معايير العراق الرسمية) - جاهز للعمل"
            Me.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tabMain
            '
            Me.tabMain.Pages.Add(Me.tabDashboard)
            Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabMain.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.tabMain.Location = New System.Drawing.Point(0, 60)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(984, 671)
            Me.tabMain.TabIndex = 3
            '
            'tabDashboard
            '
            Me.tabDashboard.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.tabDashboard.Controls.Add(Me.pnlDashboardContent)
            Me.tabDashboard.Location = New System.Drawing.Point(4, 26)
            Me.tabDashboard.Name = "tabDashboard"
            Me.tabDashboard.Padding = New System.Windows.Forms.Padding(15)
            Me.tabDashboard.Size = New System.Drawing.Size(976, 641)
            Me.tabDashboard.TabIndex = 0
            Me.tabDashboard.Text = "📊 لوحة التحكم"
            '
            'pnlDashboardContent
            '
            Me.pnlDashboardContent.Controls.Add(Me.lblDashboardWelcome)
            Me.pnlDashboardContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlDashboardContent.Location = New System.Drawing.Point(15, 15)
            Me.pnlDashboardContent.Name = "pnlDashboardContent"
            Me.pnlDashboardContent.Size = New System.Drawing.Size(946, 611)
            Me.pnlDashboardContent.TabIndex = 0
            '
            'lblDashboardWelcome
            '
            Me.lblDashboardWelcome.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblDashboardWelcome.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblDashboardWelcome.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249)
            Me.lblDashboardWelcome.Location = New System.Drawing.Point(0, 0)
            Me.lblDashboardWelcome.Name = "lblDashboardWelcome"
            Me.lblDashboardWelcome.Size = New System.Drawing.Size(946, 40)
            Me.lblDashboardWelcome.TabIndex = 0
            Me.lblDashboardWelcome.Text = "مرحباً بكم في نظام إدارة ثانوية دجلة الأهلية للبنين"
            Me.lblDashboardWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(1264, 761)
            Me.Controls.Add(Me.tabMain)
            Me.Controls.Add(Me.pnlStatusBar)
            Me.Controls.Add(Me.pnlTopBar)
            Me.Controls.Add(Me.pnlSidebar)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.MinimumSize = New System.Drawing.Size(1024, 700)
            Me.Name = "MainForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "نظام إدارتي لإدارة المدارس | Edura School Management"
            Me.pnlSidebar.ResumeLayout(False)
            Me.flpNavButtons.ResumeLayout(False)
            Me.pnlSidebarHeader.ResumeLayout(False)
            Me.pnlSidebarHeader.PerformLayout()
            Me.pnlTopBar.ResumeLayout(False)
            Me.pnlTopBar.PerformLayout()
            Me.pnlStatusBar.ResumeLayout(False)
            Me.tabMain.ResumeLayout(False)
            Me.tabDashboard.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
        Friend WithEvents pnlSidebarHeader As System.Windows.Forms.Panel
        Friend WithEvents lblAppTitle As System.Windows.Forms.Label
        Friend WithEvents lblAppSubtitle As System.Windows.Forms.Label
        Friend WithEvents flpNavButtons As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnNavDashboard As System.Windows.Forms.Button
        Friend WithEvents btnNavStudents As System.Windows.Forms.Button
        Friend WithEvents btnNavTeachers As System.Windows.Forms.Button
        Friend WithEvents btnNavAttendance As System.Windows.Forms.Button
        Friend WithEvents btnNavClasses As System.Windows.Forms.Button
        Friend WithEvents btnNavSubjects As System.Windows.Forms.Button
        Friend WithEvents btnNavExams As System.Windows.Forms.Button
        Friend WithEvents btnNavGrades As System.Windows.Forms.Button
        Friend WithEvents btnNavFinance As System.Windows.Forms.Button
        Friend WithEvents btnNavReports As System.Windows.Forms.Button
        Friend WithEvents btnNavSettings As System.Windows.Forms.Button
        Friend WithEvents pnlTopBar As System.Windows.Forms.Panel
        Friend WithEvents lblTopTitle As System.Windows.Forms.Label
        Friend WithEvents lblCurrentUser As System.Windows.Forms.Label
        Friend WithEvents lblDbConnectionStatus As System.Windows.Forms.Label
        Friend WithEvents pnlStatusBar As System.Windows.Forms.Panel
        Friend WithEvents lblStatusInfo As System.Windows.Forms.Label
        Friend WithEvents lblStatusTime As System.Windows.Forms.Label
        Friend WithEvents tabMain As Krypton.Navigator.KryptonNavigator
        Friend WithEvents tabDashboard As Krypton.Navigator.KryptonPage
        Friend WithEvents pnlDashboardContent As System.Windows.Forms.Panel
        Friend WithEvents lblDashboardWelcome As System.Windows.Forms.Label
    End Class
End Namespace
