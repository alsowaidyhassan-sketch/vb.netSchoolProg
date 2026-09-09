Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Services

Namespace Forms

    Public Class TeachersControl
        Inherits UserControl

        Private dgvTeachers As DataGridView
        Private pnlHeader As Panel
        Private btnAddTeacher As Button
        Private btnRefresh As Button
        Private txtSearch As TextBox

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.Dock = DockStyle.Fill
            Me.BackColor = Color.FromArgb(15, 23, 42)
            Me.RightToLeft = RightToLeft.Yes

            pnlHeader = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 60,
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(12)
            }

            btnAddTeacher = New Button With {
                .Text = "➕ إضافة معلم جديد",
                .BackColor = Color.FromArgb(37, 99, 235),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .Size = New Size(140, 36),
                .Location = New Point(12, 12)
            }
            btnAddTeacher.FlatAppearance.BorderSize = 0

            txtSearch = New TextBox With {
                .Font = New Font("Segoe UI", 10.0F),
                .Size = New Size(220, 32),
                .Location = New Point(170, 14),
                .PlaceholderText = "بحث باسم المعلم أو التخصص..."
            }

            pnlHeader.Controls.Add(btnAddTeacher)
            pnlHeader.Controls.Add(txtSearch)

            dgvTeachers = New DataGridView With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.FromArgb(15, 23, 42),
                .BorderStyle = BorderStyle.None,
                .EnableHeadersVisualStyles = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .ReadOnly = True,
                .AllowUserToAddRows = False
            }

            dgvTeachers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            dgvTeachers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgvTeachers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            dgvTeachers.RowsDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
            dgvTeachers.RowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
            dgvTeachers.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)

            Me.Controls.Add(dgvTeachers)
            Me.Controls.Add(pnlHeader)
        End Sub
    End Class

End Namespace
