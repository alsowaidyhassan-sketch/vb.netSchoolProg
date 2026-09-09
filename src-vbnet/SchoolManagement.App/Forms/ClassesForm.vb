Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الصفوف والشعب الدراسية بحسب الهيكل التعليمي العراقي
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class ClassesForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddClass.Click, AddressOf BtnAddClass_Click
            AddHandler btnEditClass.Click, AddressOf BtnEditClass_Click
        End Sub

        Private Sub LoadInitialData()
            dgvClasses.Rows.Clear()
            dgvClasses.Rows.Add("CLS-4A", "الرابع الإعدادي (العلمي)", "أ", "الإعدادية", "35", "30", "قاعة 101 - الطابق الأول", "أ. د. عبد الرحمن الحديثي")
            dgvClasses.Rows.Add("CLS-4B", "الرابع الإعدادي (العلمي)", "ب", "الإعدادية", "35", "28", "قاعة 102 - الطابق الأول", "أ. حيدر جاسم الخفاجي")
            dgvClasses.Rows.Add("CLS-5A", "الخامس الإعدادي (العلمي)", "أ", "الإعدادية", "30", "25", "قاعة 201 - الطابق الثاني", "أ. وسام عادل التميمي")
            dgvClasses.Rows.Add("CLS-6A", "السادس الإعدادي (العلمي)", "أ", "الإعدادية (الوزاري)", "30", "29", "قاعة 301 - الطابق الثالث", "أ. طارق مهدي المشهداني")
            dgvClasses.Rows.Add("CLS-3A", "الثالث المتوسط", "أ", "المتوسطة (الوزاري)", "35", "32", "قاعة 001 - الطابق الأرضي", "أ. مؤيد نزار السامرائي")
            dgvClasses.Rows.Add("CLS-1A", "الأول المتوسط", "أ", "المتوسطة", "40", "35", "قاعة 002 - الطابق الأرضي", "أ. سنان كمال العبيدي")
            lblStats.Text = $"إجمالي عدد الشعب الفعالة: {dgvClasses.Rows.Count} شعب"
        End Sub

        Private Sub BtnAddClass_Click(sender As Object, e As EventArgs)
            MessageBox.Show("إضافة شعبة جديدة: يمكنك تحديد المرحلة الدراسية، السعة والقاعة ومربي الصف.", "فتح شعبة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnEditClass_Click(sender As Object, e As EventArgs)
            If dgvClasses.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد شعبة للتعديل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            MessageBox.Show("تعديل بيانات الشعبة والقاعة الدراسية.", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
