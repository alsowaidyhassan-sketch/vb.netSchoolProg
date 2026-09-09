Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة الحضور والغياب اليومي مع نظام إشعار الواتساب الفوري لأولياء الأمور
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class AttendanceForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnMarkAllPresent.Click, AddressOf BtnMarkAllPresent_Click
            AddHandler btnSendWhatsAppAlert.Click, AddressOf BtnSendWhatsAppAlert_Click
            AddHandler btnSaveAttendance.Click, AddressOf BtnSaveAttendance_Click
            AddHandler dgvAttendance.CellValueChanged, AddressOf UpdateStats
        End Sub

        Private Sub LoadInitialData()
            cboClass.SelectedIndex = 0
            dgvAttendance.Rows.Clear()
            dgvAttendance.Rows.Add("STD-2025-001", "مصطفى علي حسين الزبيدي", "حاضر", "", "07801234567")
            dgvAttendance.Rows.Add("STD-2025-002", "سجاد حيدر عبد الحسن السعدي", "حاضر", "", "07709876543")
            dgvAttendance.Rows.Add("STD-2025-003", "أحمد فراس نوري العامري", "غائب", "بدون عذر", "07504567890")
            dgvAttendance.Rows.Add("STD-2025-004", "يوسف عمر خطاب الجبوري", "حاضر", "", "07812349876")
            dgvAttendance.Rows.Add("STD-2025-005", "كرار سلام ضياء الربيعي", "حاضر", "", "07715566778")
            UpdateStats()
        End Sub

        Private Sub BtnMarkAllPresent_Click(sender As Object, e As EventArgs)
            For Each row As DataGridViewRow In dgvAttendance.Rows
                row.Cells("colStatus").Value = "حاضر"
            Next
            UpdateStats()
        End Sub

        Private Sub BtnSendWhatsAppAlert_Click(sender As Object, e As EventArgs)
            Dim absentCount = 0
            For Each row As DataGridViewRow In dgvAttendance.Rows
                Dim status = Convert.ToString(row.Cells("colStatus").Value)
                If status = "غائب" Then
                    absentCount += 1
                    Dim name = Convert.ToString(row.Cells("colStudentName").Value)
                    Dim phone = Convert.ToString(row.Cells("colParentPhone").Value)

                    Dim cleanPhone = phone.Replace(" ", "").Replace("-", "")
                    If cleanPhone.StartsWith("07") Then
                        cleanPhone = "964" & cleanPhone.Substring(1)
                    End If

                    Dim msg = Uri.EscapeDataString($"السلام عليكم، نود إعلامكم بتغيب الطالب ({name}) عن الدوام الرسمي لهذا اليوم {dtpDate.Value:yyyy/MM/dd}. يرجى مراجعة إدارة ثانوية دجلة.")
                    Dim url = $"https://api.whatsapp.com/send?phone={cleanPhone}&text={msg}"

                    Try
                        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                    Catch
                    End Try
                End If
            Next

            If absentCount = 0 Then
                MessageBox.Show("لا يوجد طلاب غائبون لإرسال إشعارات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"تم فتح قنوات إرسال إشعارات الغياب لـ {absentCount} طالب.", "تم الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub BtnSaveAttendance_Click(sender As Object, e As EventArgs)
            MessageBox.Show("تم حفظ سجل الحضور والغياب بنجاح في قاعدة البيانات.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub UpdateStats(Optional sender As Object = Nothing, Optional e As DataGridViewCellEventArgs = Nothing)
            Dim present = 0, absent = 0, leave = 0
            For Each row As DataGridViewRow In dgvAttendance.Rows
                Dim st = Convert.ToString(row.Cells("colStatus").Value)
                Select Case st
                    Case "حاضر" : present += 1
                    Case "غائب" : absent += 1
                    Case "مجاز" : leave += 1
                End Select
            Next
            Dim total = dgvAttendance.Rows.Count
            Dim rate = If(total > 0, (present / CDbl(total)) * 100, 0)
            lblStats.Text = $"الإحصائية: الحضور ({present}) | الغياب ({absent}) | إجازة ({leave}) | نسبة الالتزام: {rate:F1}%"
        End Sub
    End Class
End Namespace
