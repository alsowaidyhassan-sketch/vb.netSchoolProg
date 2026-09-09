Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities

Namespace Forms
    ''' <summary>
    ''' الإضبارة الشاملة للطالب العراقي
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class StudentProfileForm
        Inherits Form

        Private _student As Student

        Public Sub New()
            InitializeComponent()
            If DesignModeHelper.IsInDesignMode(Me) Then Return
            LoadSampleData()
            WireEvents()
        End Sub

        Public Sub New(student As Student)
            InitializeComponent()
            _student = student
            If DesignModeHelper.IsInDesignMode(Me) Then Return
            LoadStudentData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnClose.Click, Sub(s, e) Me.Close()
            AddHandler btnPrint.Click, AddressOf BtnPrint_Click
        End Sub

        Private Sub LoadSampleData()
            lblStudentNameHeader.Text = "الإضبارة الأكاديمية: مصطفى علي حسين كاظم الزبيدي"
            lblStudentIdHeader.Text = "الرقم الأكاديمي: STD-2025-001 | الصف: الرابع العلمي (أ)"
            LoadFinanceTable()
            LoadGradesTable()
        End Sub

        Private Sub LoadStudentData()
            If _student Is Nothing Then
                LoadSampleData()
                Return
            End If

            lblStudentNameHeader.Text = $"الإضبارة الأكاديمية: {_student.FullName}"
            lblStudentIdHeader.Text = $"الرقم الأكاديمي: {_student.StudentNumber} | الهوية: {_student.NationalId}"

            lblBasicValue.Text = $"الاسم الخماسي: {_student.FullName} | اسم الأم: {_student.MotherName} | فصيلة الدم: {_student.BloodType}"
            lblIdentityValue.Text = $"نوع الوثيقة: {_student.IdentityDocumentType} | رقم الوثيقة: {_student.NationalId} | الجنسية: {_student.Nationality}"
            lblAddressValue.Text = $"المحافظة: {_student.Province} | القضاء: {_student.District} | هاتف ولي الأمر: {_student.EmergencyContactPhone}"

            LoadFinanceTable()
            LoadGradesTable()
        End Sub

        Private Sub LoadFinanceTable()
            dgvStudentFinance.Rows.Clear()
            dgvStudentFinance.Rows.Add("INV-2025-0101", "القسط السنوي - الدفعة الأولى", "1,000,000 د.ع", "1,000,000 د.ع", "0 د.ع", "مدفوع بالكامل")
            dgvStudentFinance.Rows.Add("INV-2025-0102", "القسط السنوي - الدفعة الثانية", "1,000,000 د.ع", "500,000 د.ع", "500,000 د.ع", "مدفوع جزئياً")
            dgvStudentFinance.Rows.Add("INV-2025-0103", "أجور خط النقل المدرسي (الكرخ)", "150,000 د.ع", "150,000 د.ع", "0 د.ع", "مدفوع")
        End Sub

        Private Sub LoadGradesTable()
            dgvStudentGrades.Rows.Clear()
            dgvStudentGrades.Rows.Add("التربية الإسلامية", "95", "92", "94", "93.6", "ناجح")
            dgvStudentGrades.Rows.Add("اللغة العربية", "88", "85", "86", "86.3", "ناجح")
            dgvStudentGrades.Rows.Add("اللغة الإنجليزية", "90", "94", "91", "91.6", "ناجح")
            dgvStudentGrades.Rows.Add("الرياضيات", "85", "90", "88", "87.6", "ناجح")
            dgvStudentGrades.Rows.Add("الفيزياء", "92", "95", "93", "93.3", "ناجح")
            dgvStudentGrades.Rows.Add("الكيمياء", "89", "91", "90", "90.0", "ناجح")
            dgvStudentGrades.Rows.Add("الأحياء", "94", "96", "95", "95.0", "ناجح")
        End Sub

        Private Sub BtnPrint_Click(sender As Object, e As EventArgs)
            MessageBox.Show("جاري تجهيز وثيقة الإضبارة الشاملة للطباعة بحسب نموذج وزارة التربية العراقية...", "طباعة الإضبارة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
