Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Forms
    ''' <summary>
    ''' نافذة إدارة شؤون الطلاب - مصممة لفتح وتعديل العناصر في Visual Studio Designer
    ''' </summary>
    Partial Public Class StudentsForm
        Inherits Form

        Private ReadOnly _studentRepository As IStudentRepository

        Public Sub New()
            InitializeComponent()
            ' Parameterless constructor required by Designer
        End Sub

        Public Sub New(studentRepository As IStudentRepository)
            Me.New()
            
            If DesignModeHelper.IsInDesignMode(Me) Then
                Return
            End If

            _studentRepository = studentRepository

            ' Instead of loading in constructor directly, defer to Form_Load to allow async fetching
            AddHandler Me.Load, AddressOf OnFormLoad
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddStudent.Click, AddressOf BtnAddStudent_Click
            AddHandler btnWhatsApp.Click, AddressOf BtnWhatsApp_Click
            AddHandler btnProfile.Click, AddressOf BtnProfile_Click
            AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
            AddHandler dgvStudents.CellDoubleClick, AddressOf DgvStudents_CellDoubleClick
        End Sub

        Private Async Sub DgvStudents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 Then Return
            
            Dim row = dgvStudents.Rows(e.RowIndex)
            Dim studentNumber = Convert.ToString(row.Cells("colStudentNumber").Value)
            
            Try
                ' Assuming there is a GetByStudentNumberAsync method in repository.
                ' Wait, earlier we didn't add it. Let's just fetch all and filter for now, or just use NationalId.
                ' Actually let's use the DB.
                Dim students = Await _studentRepository.GetAllAsync()
                Dim student = students.FirstOrDefault(Function(s) s.StudentNumber = studentNumber)
                
                If student Is Nothing Then
                    MessageBox.Show("لم يتم العثور على الطالب في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Using frm As New StudentEditForm(student)
                    If frm.ShowDialog() = DialogResult.OK Then
                        Await _studentRepository.UpdateAsync(frm.CurrentStudent)
                        Await LoadInitialDataAsync()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"تعذر تعديل بيانات الطالب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub OnFormLoad(sender As Object, e As EventArgs)
            Await LoadInitialDataAsync()
        End Sub

        Private Async Function LoadInitialDataAsync() As Task
            Try
                dgvStudents.Rows.Clear()
                Dim students = Await _studentRepository.GetAllAsync()
                
                For Each s In students
                    dgvStudents.Rows.Add(
                        s.StudentNumber,
                        s.FullName,
                        s.MotherName,
                        s.NationalId,
                        "الرابع العلمي - أ", ' Mock class name for now until Class details loaded
                        s.EmergencyContactPhone,
                        $"{s.Province} - {s.District}",
                        s.Status
                    )
                Next
                
                lblStudentCount.Text = $"إجمالي عدد الطلاب المسجلين: {dgvStudents.Rows.Count} طلاب"
            Catch ex As Exception
                MessageBox.Show($"حدث خطأ أثناء تحميل بيانات الطلاب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Async Sub BtnAddStudent_Click(sender As Object, e As EventArgs)
            Using frm As New StudentEditForm()
                If frm.ShowDialog() = DialogResult.OK Then
                    Dim s = frm.CurrentStudent
                    
                    ' Ensure StudentNumber is unique or generate a new one safely via DB transaction later
                    s.StudentNumber = If(String.IsNullOrWhiteSpace(s.StudentNumber), $"STD-{DateTime.Now.Year}-{New Random().Next(1000, 9999)}", s.StudentNumber)
                    
                    Try
                        Await _studentRepository.AddAsync(s)
                        Await LoadInitialDataAsync()
                    Catch ex As Exception
                        MessageBox.Show($"تعذر إضافة الطالب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        End Sub

        Private Sub BtnWhatsApp_Click(sender As Object, e As EventArgs)
            If dgvStudents.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد طالب من القائمة لمراسلته عبر الواتساب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvStudents.SelectedRows(0)
            Dim studentName = Convert.ToString(row.Cells("colFullName").Value)
            Dim phone = Convert.ToString(row.Cells("colPhone").Value)

            Dim cleanPhone = phone?.Replace(" ", "")?.Replace("-", "")
            If Not String.IsNullOrEmpty(cleanPhone) AndAlso cleanPhone.StartsWith("07") Then
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
                .StudentNumber = If(Convert.ToString(row.Cells("colStudentNumber").Value), String.Empty),
                .FirstName = If(Convert.ToString(row.Cells("colFullName").Value), String.Empty),
                .MotherName = If(Convert.ToString(row.Cells("colMotherName").Value), String.Empty),
                .NationalId = If(Convert.ToString(row.Cells("colNationalId").Value), String.Empty),
                .Phone = If(Convert.ToString(row.Cells("colPhone").Value), String.Empty)
            }

            Using profileFrm As New StudentProfileForm(s)
                profileFrm.ShowDialog()
            End Using
        End Sub

        Private Async Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
            Dim term = txtSearch.Text.Trim().ToLower()
            Try
                If String.IsNullOrWhiteSpace(term) Then
                    Await LoadInitialDataAsync()
                Else
                    dgvStudents.Rows.Clear()
                    Dim students = Await _studentRepository.SearchStudentsAsync(term, Nothing, Nothing)
                    For Each s In students
                        dgvStudents.Rows.Add(
                            s.StudentNumber,
                            s.FullName,
                            s.MotherName,
                            s.NationalId,
                            "الرابع العلمي - أ", ' Mock class name
                            s.EmergencyContactPhone,
                            $"{s.Province} - {s.District}",
                            s.Status
                        )
                    Next
                End If
            Catch ex As Exception
                ' Silent fail on search to avoid UI blocking
                Console.WriteLine($"Search failed: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace
