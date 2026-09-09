Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Services

Namespace Forms
    ''' <summary>
    ''' نافذة إضافة وتعديل بيانات التدريسي - متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class TeacherEditForm
        Inherits Krypton.Toolkit.KryptonForm

        Public Property CurrentTeacher As Teacher

        Public Sub New()
            InitializeComponent()
            CurrentTeacher = New Teacher()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadDefaults()
            WireEvents()
        End Sub

        Public Sub New(teacherToEdit As Teacher)
            InitializeComponent()
            CurrentTeacher = teacherToEdit

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadDefaults()
            BindData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnSave.Click, AddressOf BtnSave_Click
            AddHandler btnCancel.Click, Sub(s, e) Me.Close()
        End Sub

        Private Sub LoadDefaults()
            cboSpecialization.SelectedIndex = 0
            cboDegree.SelectedIndex = 1
            txtWeeklyQuota.Text = "18"
            txtSalary.Text = "1000000"
        End Sub

        Private Sub BindData()
            If CurrentTeacher Is Nothing Then Return
            txtFirstName.Text = CurrentTeacher.FirstName
            txtFatherName.Text = CurrentTeacher.FatherName
            txtFamilyName.Text = CurrentTeacher.FamilyName
            txtNationalId.Text = CurrentTeacher.NationalId
            txtPhone.Text = CurrentTeacher.Phone
            cboSpecialization.SelectedItem = CurrentTeacher.Specialization
            txtWeeklyQuota.Text = CurrentTeacher.WeeklyQuotaHours.ToString()
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs)
            If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
                MessageBox.Show("يرجى إدخال اسم المدرس.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFirstName.Focus()
                Return
            End If

            Dim phoneRes = IraqiValidationService.ValidatePhone(txtPhone.Text)
            If Not phoneRes.IsValid Then
                MessageBox.Show(phoneRes.ErrorMessage, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPhone.Focus()
                Return
            End If

            CurrentTeacher.FirstName = txtFirstName.Text.Trim()
            CurrentTeacher.FatherName = txtFatherName.Text.Trim()
            CurrentTeacher.FamilyName = txtFamilyName.Text.Trim()
            CurrentTeacher.NationalId = txtNationalId.Text.Trim()
            CurrentTeacher.Phone = phoneRes.CleanPhone
            CurrentTeacher.Specialization = cboSpecialization.Text
            Integer.TryParse(txtWeeklyQuota.Text, CurrentTeacher.WeeklyQuotaHours)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub
    End Class
End Namespace
