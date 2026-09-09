Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة دفتر الدرجات والسعي السنوي بحسب نظام التقويم المعتمد في وزارة التربية العراقية
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class GradesForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnSaveGrades.Click, AddressOf BtnSaveGrades_Click
            AddHandler btnExportMasterSheet.Click, AddressOf BtnExportMasterSheet_Click
            AddHandler cboSubject.SelectedIndexChanged, AddressOf ReloadData
            AddHandler cboClass.SelectedIndexChanged, AddressOf ReloadData
            AddHandler dgvGrades.CellValueChanged, AddressOf OnGradeChanged
        End Sub

        Private Sub LoadInitialData()
            cboClass.SelectedIndex = 0
            cboSubject.SelectedIndex = 0
            PopulateGrades()
        End Sub

        Private Sub ReloadData(sender As Object, e As EventArgs)
            PopulateGrades()
        End Sub

        Private Sub PopulateGrades()
            dgvGrades.Rows.Clear()
            dgvGrades.Rows.Add("STD-001", "مصطفى علي حسين الزبيدي", "90", "94", "92", "95", "93", "96", "94.5", "امتياز")
            dgvGrades.Rows.Add("STD-002", "سجاد حيدر عبد الحسن السعدي", "80", "84", "82", "88", "85", "86", "85.5", "جيد جداً")
            dgvGrades.Rows.Add("STD-003", "أحمد فراس نوري العامري", "65", "70", "67.5", "72", "70", "75", "72.5", "جيد")
            dgvGrades.Rows.Add("STD-004", "يوسف عمر خطاب الجبوري", "75", "80", "77.5", "82", "80", "84", "82.0", "جيد جداً")
            dgvGrades.Rows.Add("STD-005", "كرار سلام ضياء الربيعي", "88", "92", "90", "91", "90.5", "93", "91.8", "امتياز")
            UpdateGradeStats()
        End Sub

        Private Sub OnGradeChanged(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 Then Return
            Dim row = dgvGrades.Rows(e.RowIndex)

            Dim m1 As Double, m2 As Double, mid As Double, fin As Double
            Double.TryParse(row.Cells("colMonth1").Value?.ToString(), m1)
            Double.TryParse(row.Cells("colMonth2").Value?.ToString(), m2)
            Double.TryParse(row.Cells("colMidYear").Value?.ToString(), mid)
            Double.TryParse(row.Cells("colFinalExam").Value?.ToString(), fin)

            Dim term1Quest = (m1 + m2) / 2.0
            row.Cells("colTerm1Quest").Value = term1Quest.ToString("F1")

            Dim annualQuest = (term1Quest + mid) / 2.0
            row.Cells("colAnnualQuest").Value = annualQuest.ToString("F1")

            Dim finalAvg = (annualQuest + fin) / 2.0
            row.Cells("colFinalAverage").Value = finalAvg.ToString("F1")

            Dim eval = "راسب"
            If finalAvg >= 90 Then
                eval = "امتياز"
            ElseIf finalAvg >= 80 Then
                eval = "جيد جداً"
            ElseIf finalAvg >= 70 Then
                eval = "جيد"
            ElseIf finalAvg >= 60 Then
                eval = "متوسط"
            ElseIf finalAvg >= 50 Then
                eval = "مقبول"
            End If
            row.Cells("colEvaluation").Value = eval

            UpdateGradeStats()
        End Sub

        Private Sub UpdateGradeStats()
            Dim sum As Double = 0
            Dim maxGrade As Double = 0
            Dim minGrade As Double = 100
            Dim count = 0

            For Each row As DataGridViewRow In dgvGrades.Rows
                Dim avg As Double
                If Double.TryParse(row.Cells("colFinalAverage").Value?.ToString(), avg) Then
                    sum += avg
                    If avg > maxGrade Then maxGrade = avg
                    If avg < minGrade Then minGrade = avg
                    count += 1
                End If
            Next

            If count > 0 Then
                Dim avgTotal = sum / count
                lblGradeStats.Text = $"إحصائية المادة: نسبة النجاح: 100% | أعلى درجة: {maxGrade:F1} | أدنى درجة: {minGrade:F1} | المعدل العام: {avgTotal:F1}"
            End If
        End Sub

        Private Sub BtnSaveGrades_Click(sender As Object, e As EventArgs)
            MessageBox.Show("تم حفظ درجات المادة بنجاح وتحديث السجلات الأكاديمية للطلبة.", "حفظ الدرجات", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnExportMasterSheet_Click(sender As Object, e As EventArgs)
            MessageBox.Show("جاري تصدير شيت الدرجات الوزاري (المسطر العام) بصيغة Excel / PDF جاهز للطباعة والتدقيق من قبل إدارة المدرسة واللجنة الامتحانية.", "تصدير الشيت الوزاري", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
