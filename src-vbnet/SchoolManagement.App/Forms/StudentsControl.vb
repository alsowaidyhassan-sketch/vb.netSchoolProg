Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Services

Namespace Forms
    ''' <summary>
    ''' واجهة إدارة شؤون الطلاب وفق المعايير الرسمية لجمهورية العراق
    ''' مصممة لتكون مرئية وقابلة للتعديل والتصميم المباشر عبر Visual Studio Designer
    ''' </summary>
    Public Class StudentsControl
        Inherits UserControl

        Private pnlHeader As Panel
        Private btnAddStudent As Button
        Private btnWhatsApp As Button
        Private btnRefresh As Button
        Private txtSearch As TextBox
        Private cboFilterClass As ComboBox
        Private dgvStudents As DataGridView

        Public Sub New()
            InitializeComponent()
            LoadSampleIraqiStudents()
        End Sub

        Private Sub InitializeComponent()
            Me.Dock = DockStyle.Fill
            Me.BackColor = Color.FromArgb(15, 23, 42)
            Me.RightToLeft = RightToLeft.Yes
            Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)

            ' 1. شريط الأدوات العلوي
            pnlHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 65,
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(12)
            }

            btnAddStudent = New Button With {
                .Text = "➕ تسجيل طالب جديد",
                .BackColor = Color.FromArgb(37, 99, 235),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .Size = New Size(160, 40),
                .Location = New Point(12, 12),
                .Cursor = Cursors.Hand
            }
            btnAddStudent.FlatAppearance.BorderSize = 0
            AddHandler btnAddStudent.Click, AddressOf BtnAddStudent_Click

            btnWhatsApp = New Button With {
                .Text = "💬 مراسلة واتساب",
                .BackColor = Color.FromArgb(16, 185, 129),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .Size = New Size(140, 40),
                .Location = New Point(180, 12),
                .Cursor = Cursors.Hand
            }
            btnWhatsApp.FlatAppearance.BorderSize = 0
            AddHandler btnWhatsApp.Click, AddressOf BtnWhatsApp_Click

            txtSearch = New TextBox With {
                .Font = New Font("Segoe UI", 10.0F),
                .Size = New Size(240, 35),
                .Location = New Point(330, 15),
                .PlaceholderText = "بحث باسم الطالب، الهوية أو الهاتف..."
            }

            cboFilterClass = New ComboBox With {
                .Font = New Font("Segoe UI", 10.0F),
                .Size = New Size(160, 35),
                .Location = New Point(580, 15),
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            cboFilterClass.Items.AddRange(New String() {"جميع الصفوف", "الأول متوسط", "الثاني متوسط", "الثالث متوسط", "الرابع العلمي", "الخامس العلمي", "السادس العلمي"})
            cboFilterClass.SelectedIndex = 0

            pnlHeader.Controls.Add(btnAddStudent)
            pnlHeader.Controls.Add(btnWhatsApp)
            pnlHeader.Controls.Add(txtSearch)
            pnlHeader.Controls.Add(cboFilterClass)

            ' 2. جدول بيانات الطلاب (DataGridView)
            dgvStudents = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.FromArgb(15, 23, 42),
                .BorderStyle = BorderStyle.None,
                .EnableHeadersVisualStyles = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .ReadOnly = True,
                .AllowUserToAddRows = False,
                .RowTemplate = New DataGridViewRow With {.Height = 42}
            }

            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            dgvStudents.ColumnHeadersHeight = 45
            dgvStudents.RowsDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
            dgvStudents.RowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
            dgvStudents.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            dgvStudents.RowsDefaultCellStyle.SelectionForeColor = Color.White

            ConfigureGridColumns()

            Me.Controls.Add(dgvStudents)
            Me.Controls.Add(pnlHeader)
        End Sub

        Private Sub ConfigureGridColumns()
            dgvStudents.Columns.Clear()

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "StudentNumber",
                .HeaderText = "الرقم الأكاديمي",
                .FillWeight = 85
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "FullName",
                .HeaderText = "اسم الطالب الخماسي واللقب",
                .FillWeight = 160
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "MotherName",
                .HeaderText = "اسم الأم الثلاثي",
                .FillWeight = 110
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "NationalId",
                .HeaderText = "البطاقة الوطنية / الهوية",
                .FillWeight = 115
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "ClassSection",
                .HeaderText = "الصف والشعبة",
                .FillWeight = 90
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "ParentPhone",
                .HeaderText = "هاتف ولي الأمر (عراق)",
                .FillWeight = 115
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Address",
                .HeaderText = "العنوان (المحافظة - القضاء)",
                .FillWeight = 130
            })

            dgvStudents.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Status",
                .HeaderText = "الحالة",
                .FillWeight = 70
            })
        End Sub

        Private Sub LoadSampleIraqiStudents()
            dgvStudents.Rows.Clear()
            dgvStudents.Rows.Add("STD-2025-001", "مصطفى علي حسين كاظم الزبيدي", "فاطمة جاسم محمد", "200812345678", "الرابع العلمي - أ", "07801234567", "بغداد - الكرخ (المنصور)", "منتظم")
            dgvStudents.Rows.Add("STD-2025-002", "سجاد حيدر عبد الحسن حميد السعدي", "زينب مهدي صالح", "200987654321", "الثالث متوسط - ب", "07709876543", "بغداد - الرصافة (الكرادة)", "منتظم")
            dgvStudents.Rows.Add("STD-2025-003", "أحمد فراس نوري عبد الجبار العامري", "مريم خليل إسماعيل", "200745678912", "السادس العلمي - أ", "07504567890", "أربيل - عينكاوة", "منتظم")
            dgvStudents.Rows.Add("STD-2025-004", "يوسف عمر خطاب طه الجبوري", "عائشة عبد القادر أحمد", "200898761234", "الرابع العلمي - ج", "07812349876", "الأنبار - الرمادي", "منتظم")
            dgvStudents.Rows.Add("STD-2025-005", "كرار سلام ضياء مطشر الربيعي", "منى عادل خضير", "201011223344", "الأول متوسط - أ", "07715566778", "البصرة - العشار", "منتظم")
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
                    MessageBox.Show("تم تسجيل الطالب بنجاح وتوليد سجله في قاعدة البيانات.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Sub

        Private Sub BtnWhatsApp_Click(sender As Object, e As EventArgs)
            If dgvStudents.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى اختيار طالب من القائمة أولاً للمراسلة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row = dgvStudents.SelectedRows(0)
            Dim studentName = Convert.ToString(row.Cells("FullName").Value)
            Dim phone = Convert.ToString(row.Cells("ParentPhone").Value)

            ' إرسال مباشر عبر واتساب برقم عراقي دولي
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
    End Class
End Namespace
