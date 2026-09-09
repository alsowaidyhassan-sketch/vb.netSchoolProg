Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الهيئة التدريسية - متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class TeachersForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddTeacher.Click, AddressOf BtnAddTeacher_Click
            AddHandler btnEditTeacher.Click, AddressOf BtnEditTeacher_Click
            AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        End Sub

        Private Sub LoadInitialData()
            dgvTeachers.Rows.Clear()
            dgvTeachers.Rows.Add("TCH-101", "أ. د. عبد الرحمن محمد علي الحديثي", "اللغة العربية", "دكتوراه", "07802233445", "18 حصة", "مستمر")
            dgvTeachers.Rows.Add("TCH-102", "أ. حيدر جاسم كاظم الخفاجي", "الرياضيات", "ماجستير", "07703344556", "20 حصة", "مستمر")
            dgvTeachers.Rows.Add("TCH-103", "أ. وسام عادل نصيف التميمي", "الفيزياء", "بكالوريوس", "07504455667", "16 حصة", "مستمر")
            dgvTeachers.Rows.Add("TCH-104", "أ. طارق مهدي حسين المشهداني", "اللغة الإنجليزية", "ماجستير", "07815566778", "18 حصة", "مستمر")
            lblTeacherCount.Text = $"إجمالي عدد الكادر التدريسي: {dgvTeachers.Rows.Count} معلمين"
        End Sub

        Private Sub BtnAddTeacher_Click(sender As Object, e As EventArgs)
            Using frm As New TeacherEditForm()
                If frm.ShowDialog() = DialogResult.OK Then
                    Dim t = frm.CurrentTeacher
                    dgvTeachers.Rows.Add(
                        If(String.IsNullOrWhiteSpace(t.StaffId), $"TCH-{dgvTeachers.Rows.Count + 101}", t.StaffId),
                        t.FullName,
                        t.Specialization,
                        "بكالوريوس",
                        t.Phone,
                        $"{t.WeeklyQuotaHours} حصة",
                        "مستمر"
                    )
                    lblTeacherCount.Text = $"إجمالي عدد الكادر التدريسي: {dgvTeachers.Rows.Count} معلمين"
                End If
            End Using
        End Sub

        Private Sub BtnEditTeacher_Click(sender As Object, e As EventArgs)
            If dgvTeachers.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد مدرس للتعديل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvTeachers.SelectedRows(0)
            Dim t As New Teacher With {
                .StaffId = If(row.Cells("colStaffId").Value?.ToString(), String.Empty),
                .FullName = If(row.Cells("colTeacherName").Value?.ToString(), String.Empty),
                .FirstName = If(row.Cells("colTeacherName").Value?.ToString(), String.Empty),
                .Specialization = If(row.Cells("colSpecialization").Value?.ToString(), String.Empty),
                .Phone = If(row.Cells("colPhone").Value?.ToString(), String.Empty)
            }

            Using frm As New TeacherEditForm(t)
                If frm.ShowDialog() = DialogResult.OK Then
                    row.Cells("colTeacherName").Value = frm.CurrentTeacher.FullName
                    row.Cells("colSpecialization").Value = frm.CurrentTeacher.Specialization
                    row.Cells("colPhone").Value = frm.CurrentTeacher.Phone
                End If
            End Using
        End Sub

        Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
            Dim term = txtSearch.Text.Trim().ToLower()
            For Each row As DataGridViewRow In dgvTeachers.Rows
                Dim name = row.Cells("colTeacherName").Value?.ToString().ToLower()
                Dim spec = row.Cells("colSpecialization").Value?.ToString().ToLower()
                Dim phone = row.Cells("colPhone").Value?.ToString().ToLower()
                row.Visible = String.IsNullOrWhiteSpace(term) OrElse name.Contains(term) OrElse spec.Contains(term) OrElse phone.Contains(term)
            Next
        End Sub
    End Class
End Namespace
