Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' النموذج الرئيسي لنظام إدارة المدارس العراقي
    ''' متوافق بالكامل مع Visual Studio Designer مع فصل الكود عن التصميم
    ''' </summary>
    Partial Public Class MainForm
        Inherits Form

        Private _tabManager As TabManager

        Public Sub New()
            InitializeComponent()

            ' التحقق من وضع التصميم لمنع أي أخطاء وقت التصميم
            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            _tabManager = New TabManager(tabMain)
            WireNavigationEvents()
        End Sub

        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)
            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            ' افتراضياً نقوم بفتح تبويب شؤون الطلاب
            OpenStudentsTab()
        End Sub

        Private Sub WireNavigationEvents()
            AddHandler btnNavDashboard.Click, Sub(s, e) tabMain.SelectedTab = tabDashboard
            AddHandler btnNavStudents.Click, AddressOf BtnNavStudents_Click
            AddHandler btnNavTeachers.Click, AddressOf BtnNavTeachers_Click
            AddHandler btnNavAttendance.Click, AddressOf BtnNavAttendance_Click
            AddHandler btnNavClasses.Click, AddressOf BtnNavClasses_Click
            AddHandler btnNavSubjects.Click, AddressOf BtnNavSubjects_Click
            AddHandler btnNavExams.Click, AddressOf BtnNavExams_Click
            AddHandler btnNavGrades.Click, AddressOf BtnNavGrades_Click
            AddHandler btnNavFinance.Click, AddressOf BtnNavFinance_Click
            AddHandler btnNavReports.Click, AddressOf BtnNavReports_Click
            AddHandler btnNavSettings.Click, AddressOf BtnNavSettings_Click
        End Sub

        Private Sub BtnNavStudents_Click(sender As Object, e As EventArgs)
            OpenStudentsTab()
        End Sub

        Private Sub OpenStudentsTab()
            Dim frm As New StudentsForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("🎓 شؤون الطلاب", "Students", frm)
        End Sub

        Private Sub BtnNavTeachers_Click(sender As Object, e As EventArgs)
            Dim frm As New TeachersForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("👨‍🏫 المعلمون", "Teachers", frm)
        End Sub

        Private Sub BtnNavAttendance_Click(sender As Object, e As EventArgs)
            Dim frm As New AttendanceForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("📅 الحضور والغياب", "Attendance", frm)
        End Sub

        Private Sub BtnNavClasses_Click(sender As Object, e As EventArgs)
            Dim frm As New ClassesForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("🏫 الصفوف والشعب", "Classes", frm)
        End Sub

        Private Sub BtnNavSubjects_Click(sender As Object, e As EventArgs)
            Dim frm As New SubjectsForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("📚 المواد الدراسية", "Subjects", frm)
        End Sub

        Private Sub BtnNavExams_Click(sender As Object, e As EventArgs)
            Dim frm As New ExamsForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("📝 الامتحانات", "Exams", frm)
        End Sub

        Private Sub BtnNavGrades_Click(sender As Object, e As EventArgs)
            Dim frm As New GradesForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("📈 الدرجات والشهادات", "Grades", frm)
        End Sub

        Private Sub BtnNavFinance_Click(sender As Object, e As EventArgs)
            Dim frm As New FinanceForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("💰 المالية والأقساط", "Finance", frm)
        End Sub

        Private Sub BtnNavReports_Click(sender As Object, e As EventArgs)
            Dim frm As New ReportsForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("📑 التقارير الرسمية", "Reports", frm)
        End Sub

        Private Sub BtnNavSettings_Click(sender As Object, e As EventArgs)
            Dim frm As New SettingsForm()
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.Visible = True
            _tabManager.OpenTab("⚙️ إعدادات النظام", "Settings", frm)
        End Sub
    End Class
End Namespace
