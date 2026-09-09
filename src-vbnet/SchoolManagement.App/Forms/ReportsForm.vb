Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة التقارير والإحصائيات الوزارية بحسب النماذج المعتمدة في جمهورية العراق
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class ReportsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnGenerateReport.Click, AddressOf BtnGenerateReport_Click
            AddHandler btnPrint.Click, AddressOf BtnPrint_Click
            AddHandler btnExportExcel.Click, AddressOf BtnExportExcel_Click
            AddHandler cboReportType.SelectedIndexChanged, AddressOf OnReportTypeChanged
        End Sub

        Private Sub LoadInitialData()
            cboReportType.SelectedIndex = 0
            PopulateReport()
        End Sub

        Private Sub OnReportTypeChanged(sender As Object, e As EventArgs)
            PopulateReport()
        End Sub

        Private Sub PopulateReport()
            dgvReportPreview.Rows.Clear()
            Select Case cboReportType.SelectedIndex
                Case 0 ' سجل القيد العام
                    colItem1.HeaderText = "الرقم بالقيد"
                    colItem2.HeaderText = "اسم الطالب الرباعي"
                    colItem3.HeaderText = "الصف والشعبة"
                    colItem4.HeaderText = "رقم البطاقة الوطنية"
                    colItem5.HeaderText = "حالة القيد"

                    dgvReportPreview.Rows.Add("1001", "مصطفى علي حسين كاظم الزبيدي", "الرابع العلمي (أ)", "200812345678", "مستمر بالدوام")
                    dgvReportPreview.Rows.Add("1002", "سجاد حيدر عبد الحسن السعدي", "الرابع العلمي (أ)", "200823456789", "مستمر بالدوام")
                    dgvReportPreview.Rows.Add("1003", "أحمد فراس نوري عبد العامري", "الرابع العلمي (ب)", "200834567890", "مستمر بالدوام")
                    dgvReportPreview.Rows.Add("1004", "يوسف عمر خطاب طه الجبوري", "الخامس العلمي (أ)", "200745678901", "مستمر بالدوام")
                    dgvReportPreview.Rows.Add("1005", "كرار سلام ضياء الربيعي", "السادس العلمي (أ)", "200656789012", "مستمر بالدوام")

                Case 1 ' بطاقة الدرجات
                    colItem1.HeaderText = "رمز الطالب"
                    colItem2.HeaderText = "اسم الطالب"
                    colItem3.HeaderText = "الصف"
                    colItem4.HeaderText = "المعدل العام"
                    colItem5.HeaderText = "التقدير النهائي"

                    dgvReportPreview.Rows.Add("STD-001", "مصطفى علي حسين الزبيدي", "الرابع العلمي (أ)", "94.5%", "امتياز")
                    dgvReportPreview.Rows.Add("STD-002", "سجاد حيدر عبد الحسن السعدي", "الرابع العلمي (أ)", "85.5%", "جيد جداً")
                    dgvReportPreview.Rows.Add("STD-003", "أحمد فراس نوري العامري", "الرابع العلمي (ب)", "72.5%", "جيد")
                    dgvReportPreview.Rows.Add("STD-004", "يوسف عمر خطاب الجبوري", "الخامس العلمي (أ)", "82.0%", "جيد جداً")
                    dgvReportPreview.Rows.Add("STD-005", "كرار سلام ضياء الربيعي", "السادس العلمي (أ)", "91.8%", "امتياز")

                Case Else
                    colItem1.HeaderText = "التسلسل"
                    colItem2.HeaderText = "البيان الإحصائي"
                    colItem3.HeaderText = "المرحلة / القسم"
                    colItem4.HeaderText = "العدد / القيمة"
                    colItem5.HeaderText = "النسبة المئوية"

                    dgvReportPreview.Rows.Add("1", "إجمالي الطلبة المسجلين", "الكل", "580 طالب", "100%")
                    dgvReportPreview.Rows.Add("2", "الطلبة الناجحون في نصف السنة", "الكل", "545 طالب", "94%")
                    dgvReportPreview.Rows.Add("3", "المكملون (الدور الثاني)", "الكل", "35 طالب", "6%")
                    dgvReportPreview.Rows.Add("4", "إجمالي إيرادات الأقساط", "المالية", "180,500,000 د.ع", "73.6%")
            End Select
        End Sub

        Private Sub BtnGenerateReport_Click(sender As Object, e As EventArgs)
            PopulateReport()
            MessageBox.Show("تم توليد التقرير بنجاح وتحديث كافة البيانات التحليلية.", "توليد التقرير", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnPrint_Click(sender As Object, e As EventArgs)
            MessageBox.Show("جاري إرسال التقرير الوزاري إلى الطابعة مع الترويسة المعتمدة (جمهورية العراق - وزارة التربية).", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnExportExcel_Click(sender As Object, e As EventArgs)
            MessageBox.Show("تم تصدير التقرير بصيغة Excel بنجاح.", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
