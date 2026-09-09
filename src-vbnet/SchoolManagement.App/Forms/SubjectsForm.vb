Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة المناهج والمواد الدراسية بحسب وزارة التربية العراقية
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class SubjectsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddSubject.Click, AddressOf BtnAddSubject_Click
            AddHandler btnCurriculumGuide.Click, AddressOf BtnCurriculumGuide_Click
        End Sub

        Private Sub LoadInitialData()
            dgvSubjects.Rows.Clear()
            dgvSubjects.Rows.Add("SUB-ISL", "التربية الإسلامية والقرآن الكريم", "الرابع الإعدادي", "100", "50", "2", "أ. مؤيد نزار السامرائي")
            dgvSubjects.Rows.Add("SUB-ARB", "اللغة العربية (قواعد وأدب وبلاغة)", "الرابع الإعدادي", "100", "50", "5", "أ. د. عبد الرحمن الحديثي")
            dgvSubjects.Rows.Add("SUB-ENG", "اللغة الإنجليزية (English for Iraq)", "الرابع الإعدادي", "100", "50", "4", "أ. طارق مهدي المشهداني")
            dgvSubjects.Rows.Add("SUB-MTH", "الرياضيات العامة والتحليلية", "الرابع الإعدادي", "100", "50", "5", "أ. حيدر جاسم الخفاجي")
            dgvSubjects.Rows.Add("SUB-PHY", "الفيزياء (النظري والعملي)", "الرابع الإعدادي", "100", "50", "4", "أ. وسام عادل التميمي")
            dgvSubjects.Rows.Add("SUB-CHM", "الكيمياء العامة والمعملية", "الرابع الإعدادي", "100", "50", "4", "أ. قيس حميد الكلابي")
            dgvSubjects.Rows.Add("SUB-BIO", "علم الأحياء والتشريح", "الرابع الإعدادي", "100", "50", "3", "أ. سمير جليل الطائي")
            lblStats.Text = $"إجمالي المواد المقررة: {dgvSubjects.Rows.Count} مواد أساسية"
        End Sub

        Private Sub BtnAddSubject_Click(sender As Object, e As EventArgs)
            MessageBox.Show("إضافة مادة دراسية جديدة وفق الخطة التعليمية الوزارية.", "إضافة مادة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnCurriculumGuide_Click(sender As Object, e As EventArgs)
            MessageBox.Show("دليل المناهج الوزارية لجمهورية العراق: جميع الكتب والمقررات معتمدة من مديرية المناهج العامة بوزارة التربية.", "دليل المناهج", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
