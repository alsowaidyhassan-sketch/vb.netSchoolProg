Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities

Namespace Forms
    ''' <summary>
    ''' نافذة إدارة شؤون الطلاب - مصممة لفتح وتعديل العناصر في Visual Studio Designer
    ''' </summary>
    Partial Public Class StudentsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddStudent.Click, AddressOf BtnAddStudent_Click
            AddHandler btnWhatsApp.Click, AddressOf BtnWhatsApp_Click
            AddHandler btnProfile.Click, AddressOf BtnProfile_Click
            AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        End Sub

        Private Sub LoadInitialData()
            dgvStudents.Rows.Clear()
            dgvStudents.Rows.Add("STD-2025-001", "مصطفى علي حسين كاظم الزبيدي", "فاطمة جاسم محمد", "200812345678", "الرابع العلمي - أ", "07801234567", "بغداد - الكرخ (المنصور)", "منتظم")
            dgvStudents.Rows.Add("STD-2025-002", "سجاد حيدر عبد الحسن حميد السعدي", "زينب مهدي صالح", "200987654321", "الثالث متوسط - ب", "07709876543", "بغداد - الرصافة (الكرادة)", "منتظم")
            dgvStudents.Rows.Add("STD-2025-003", "أحمد فراس نوري عبد الجبار العامري", "مريم خليل إسماعيل", "200745678912", "السادس العلمي - أ", "07504567890", "أربيل - عينكاوة", "منتظم")
            dgvStudents.Rows.Add("STD-2025-004", "يوسف عمر خطاب طه الجبوري", "عائشة عبد القادر أحمد", "200898761234", "الرابع العلمي - ج", "07812349876", "الأنبار - الرمادي", "منتظم")
            dgvStudents.Rows.Add("STD-2025-005", "كرار سلام ضياء مطشر الربيعي", "منى عادل خضير", "201011223344", "الأول متوسط - أ", "07715566778", "البصرة - العشار", "منتظم")
            lblStudentCount.Text = $"إجمالي عدد الطلاب المسجلين: {dgvStudents.Rows.Count} طلاب"
        End Sub

        Private Sub BtnAddStudent_Click(sender As Object, e As EventArgs)
            Using frm As New StudentEditForm()
                If frm.ShowDialog() = DialogResult.OK Then
                    Dim s = frm.CurrentStudent
                    dgvStudents.Rows.Add(
                        If(String.IsNullOrWhiteSpace(s.StudentNumber), $"STD-2025-{dgvStudents.Rows.Count + 1:D3}", s.StudentNumber),
                        s.FullName,
                        s.MotherName,
                        s.NationalId,
                        "الرابع العلمي - أ",
                        s.EmergencyContactPhone,
                        $"{s.Province} - {s.District}",
                        "منتظم"
                    )
                    lblStudentCount.Text = $"إجمالي عدد الطلاب المسجلين: {dgvStudents.Rows.Count} طلاب"
                End If
            End Using
        End Sub

        Private Sub BtnWhatsApp_Click(sender As Object, e As EventArgs)
            If dgvStudents.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد طالب من القائمة لمراسلته عبر الواتساب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvStudents.SelectedRows(0)
            Dim studentName = row.Cells("colFullName").Value.ToString()
            Dim phone = row.Cells("colPhone").Value.ToString()

            Dim cleanPhone = phone.Replace(" ", "").Replace("-", "")
            If cleanPhone.StartsWith("07") Then
                cleanPhone = "964" & cleanPhone.Substring(1)
            End If

            Dim text = Uri.EscapeDataString($"السلام عليكم ورحمة الله، ولي أمر الطالب المكرم {studentName}، تحية طيبة من إدارة ثانوية دجلة الأهلية للبنين...")
            Dim url = $"https://api.whatsapp.com/send?phone={cleanPhone}&text={text}"

            Try
                Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            Catch ex As Exception
                MessageBox.Show($"تعذر فتح المتصفح تلقائياً: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BtnProfile_Click(sender As Object, e As EventArgs)
            If dgvStudents.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد طالب لعرض إضبارته الشاملة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvStudents.SelectedRows(0)
            Dim s As New Student With {
                .StudentNumber = row.Cells("colStudentNumber").Value.ToString(),
                .FirstName = row.Cells("colFullName").Value.ToString(),
                .MotherName = row.Cells("colMotherName").Value.ToString(),
                .NationalId = row.Cells("colNationalId").Value.ToString(),
                .Phone = row.Cells("colPhone").Value.ToString()
            }

            Using profileFrm As New StudentProfileForm(s)
                profileFrm.ShowDialog()
            End Using
        End Sub

        Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
            Dim term = txtSearch.Text.Trim().ToLower()
            For Each row As DataGridViewRow In dgvStudents.Rows
                Dim name = row.Cells("colFullName").Value?.ToString().ToLower()
                Dim id = row.Cells("colNationalId").Value?.ToString().ToLower()
                Dim phone = row.Cells("colPhone").Value?.ToString().ToLower()
                row.Visible = String.IsNullOrWhiteSpace(term) OrElse name.Contains(term) OrElse id.Contains(term) OrElse phone.Contains(term)
            Next
        End Sub
    End Class
End Namespace
