Imports System
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الهيئة التدريسية - متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class TeachersForm
        Inherits Form

        Private ReadOnly _teacherRepository As ITeacherRepository

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(teacherRepository As ITeacherRepository)
            Me.New()
            
            If DesignModeHelper.IsInDesignMode(Me) Then Return
            
            _teacherRepository = teacherRepository
            
            AddHandler Me.Load, AddressOf OnFormLoad
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnAddTeacher.Click, AddressOf BtnAddTeacher_Click
            AddHandler btnEditTeacher.Click, AddressOf BtnEditTeacher_Click
            AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        End Sub

        Private Async Sub OnFormLoad(sender As Object, e As EventArgs)
            Await LoadInitialDataAsync()
        End Sub

        Private Async Function LoadInitialDataAsync() As Task
            Try
                dgvTeachers.Rows.Clear()
                Dim teachers = Await _teacherRepository.GetAllAsync()
                
                For Each t In teachers
                    dgvTeachers.Rows.Add(
                        t.EmployeeNumber,
                        t.FullName,
                        t.Specialization,
                        t.AcademicDegree,
                        t.Phone,
                        $"{t.WeeklyQuotaHours} حصة",
                        t.Status
                    )
                Next
                
                lblTeacherCount.Text = $"إجمالي عدد الكادر التدريسي: {dgvTeachers.Rows.Count} معلمين"
            Catch ex As Exception
                MessageBox.Show($"حدث خطأ أثناء تحميل بيانات المدرسين: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Async Sub BtnAddTeacher_Click(sender As Object, e As EventArgs)
            Using frm As New TeacherEditForm()
                If frm.ShowDialog() = DialogResult.OK Then
                    Dim t = frm.CurrentTeacher
                    t.EmployeeNumber = If(String.IsNullOrWhiteSpace(t.EmployeeNumber), $"TCH-{DateTime.Now.Year}-{New Random().Next(100, 999)}", t.EmployeeNumber)
                    
                    Try
                        Await _teacherRepository.AddAsync(t)
                        Await LoadInitialDataAsync()
                    Catch ex As Exception
                        MessageBox.Show($"تعذر إضافة المدرس: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        End Sub

        Private Async Sub BtnEditTeacher_Click(sender As Object, e As EventArgs)
            If dgvTeachers.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد مدرس للتعديل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            Dim row = dgvTeachers.SelectedRows(0)
            Dim empNumber = Convert.ToString(row.Cells("colStaffId").Value)
            
            Try
                Dim teacher = Await _teacherRepository.GetByEmployeeNumberAsync(empNumber)
                If teacher Is Nothing Then
                    MessageBox.Show("لم يتم العثور على المدرس في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Using frm As New TeacherEditForm(teacher)
                    If frm.ShowDialog() = DialogResult.OK Then
                        Await _teacherRepository.UpdateAsync(frm.CurrentTeacher)
                        Await LoadInitialDataAsync()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"تعذر تعديل بيانات المدرس: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Async Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
            Dim term = txtSearch.Text.Trim().ToLower()
            Try
                If String.IsNullOrWhiteSpace(term) Then
                    Await LoadInitialDataAsync()
                Else
                    dgvTeachers.Rows.Clear()
                    Dim teachers = Await _teacherRepository.GetAllAsync()
                    Dim filtered = teachers.Where(Function(t) (Not String.IsNullOrWhiteSpace(t.FullName) AndAlso t.FullName.ToLower().Contains(term)) OrElse
                                                              (Not String.IsNullOrWhiteSpace(t.Specialization) AndAlso t.Specialization.ToLower().Contains(term)) OrElse
                                                              (Not String.IsNullOrWhiteSpace(t.Phone) AndAlso t.Phone.ToLower().Contains(term)))
                    For Each t In filtered
                        dgvTeachers.Rows.Add(
                            t.EmployeeNumber,
                            t.FullName,
                            t.Specialization,
                            t.AcademicDegree,
                            t.Phone,
                            $"{t.WeeklyQuotaHours} حصة",
                            t.Status
                        )
                    Next
                End If
            Catch ex As Exception
                Console.WriteLine($"Search failed: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace
