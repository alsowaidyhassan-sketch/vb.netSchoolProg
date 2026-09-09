Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الامتحانات وجداول الاختبارات النصفية والنهائية
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class ExamsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnCreateExamSchedule.Click, AddressOf BtnCreateExamSchedule_Click
            AddHandler btnPrintTable.Click, AddressOf BtnPrintTable_Click
            AddHandler cboExamType.SelectedIndexChanged, AddressOf OnExamTypeChanged
        End Sub

        Private Sub LoadInitialData()
            cboExamType.SelectedIndex = 0
            PopulateTable()
        End Sub

        Private Sub PopulateTable()
            dgvExams.Rows.Clear()
            dgvExams.Rows.Add("EX-01", "امتحان نصف السنة", "التربية الإسلامية", "الرابع العلمي (أ، ب)", "2025/01/20", "08:30 ص", "قاعة 101 و 102", "أ. مؤيد نزار")
            dgvExams.Rows.Add("EX-02", "امتحان نصف السنة", "اللغة العربية", "الرابع العلمي (أ، ب)", "2025/01/22", "08:30 ص", "قاعة 101 و 102", "أ. د. عبد الرحمن الحديثي")
            dgvExams.Rows.Add("EX-03", "امتحان نصف السنة", "اللغة الإنجليزية", "الرابع العلمي (أ، ب)", "2025/01/24", "08:30 ص", "قاعة 101 و 102", "أ. طارق المشهداني")
            dgvExams.Rows.Add("EX-04", "امتحان نصف السنة", "الرياضيات", "الرابع العلمي (أ، ب)", "2025/01/26", "08:30 ص", "قاعة 101 و 102", "أ. حيدر الخفاجي")
            dgvExams.Rows.Add("EX-05", "امتحان نصف السنة", "الفيزياء", "الرابع العلمي (أ، ب)", "2025/01/28", "08:30 ص", "قاعة 101 و 102", "أ. وسام التميمي")
            dgvExams.Rows.Add("EX-06", "امتحان نصف السنة", "الكيمياء", "الرابع العلمي (أ، ب)", "2025/01/30", "08:30 ص", "قاعة 101 و 102", "أ. قيس الكلابي")
            dgvExams.Rows.Add("EX-07", "امتحان نصف السنة", "علم الأحياء", "الرابع العلمي (أ، ب)", "2025/02/01", "08:30 ص", "قاعة 101 و 102", "أ. سمير الطائي")
        End Sub

        Private Sub OnExamTypeChanged(sender As Object, e As EventArgs)
            PopulateTable()
        End Sub

        Private Sub BtnCreateExamSchedule_Click(sender As Object, e As EventArgs)
            MessageBox.Show("جدولة امتحان جديد: تحديد المادة، التاريخ، التوقيت، القاعات، والمراقبين.", "جدولة امتحان", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnPrintTable_Click(sender As Object, e As EventArgs)
            MessageBox.Show("جاري إعداد جدول الامتحانات للطباعة والتوزيع على الطلبة وإعلانه في لوحة الإعلانات المدرسية.", "طباعة الجدول", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
