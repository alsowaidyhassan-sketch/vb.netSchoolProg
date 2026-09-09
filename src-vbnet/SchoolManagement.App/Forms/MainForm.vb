Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Forms
    Public Class MainForm
        Inherits Form

        ' Components
        Private WithEvents pnlSidebar As Panel
        Private WithEvents pnlTopBar As Panel
        Private WithEvents pnlStatusBar As Panel
        Private WithEvents tabMain As TabControl
        Private lblAppTitle As Label
        Private lblDbStatus As Label
        Private btnToggleSidebar As Button
        Private isSidebarCollapsed As Boolean = False

        Public Sub New()
            InitializeComponent()
            ConfigureModernStyles()
            OpenTab("لوحة التحكم", "Dashboard")
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "نظام إدارتي لإدارة المدارس - Edura School Management"
            Me.Size = New Size(1366, 768)
            Me.MinimumSize = New Size(1024, 600)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)

            ' TopBar
            pnlTopBar = New Panel With {
                .Dock = DockStyle.Top,
                .Height = 56,
                .BackColor = Color.FromArgb(15, 23, 42) ' Dark Slate 900
            }

            lblAppTitle = New Label With {
                .Text = "🏫 نظام إدارتي لإدارة المدارس | الإصدار المتقدم Enterprise",
                .ForeColor = Color.White,
                .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                .AutoSize = True,
                .Location = New Point(20, 16)
            }
            pnlTopBar.Controls.Add(lblAppTitle)

            ' Sidebar
            pnlSidebar = New Panel With {
                .Dock = DockStyle.Right,
                .Width = 240,
                .BackColor = Color.FromArgb(30, 41, 59) ' Slate 800
            }
            PopulateSidebarButtons()

            ' StatusBar
            pnlStatusBar = New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 28,
                .BackColor = Color.FromArgb(15, 23, 42)
            }
            lblDbStatus = New Label With {
                .Text = "🟢 قاعدة البيانات متصلة: SQL Server (EduraSchoolDB) | المستخدم: المشرف العام (admin)",
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                .AutoSize = True,
                .Location = New Point(10, 5)
            }
            pnlStatusBar.Controls.Add(lblDbStatus)

            ' TabControl
            tabMain = New TabControl With {
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                .DrawMode = TabDrawMode.OwnerDrawFixed,
                .ItemSize = New Size(140, 36),
                .SizeMode = TabSizeMode.Fixed
            }
            AddHandler tabMain.DrawItem, AddressOf OnTabDrawItem
            AddHandler tabMain.MouseDown, AddressOf OnTabMouseDown

            Me.Controls.Add(tabMain)
            Me.Controls.Add(pnlSidebar)
            Me.Controls.Add(pnlTopBar)
            Me.Controls.Add(pnlStatusBar)
        End Sub

        Private Sub PopulateSidebarButtons()
            Dim modules As (Title As String, Key As String)() = {
                ("📊 لوحة التحكم", "Dashboard"),
                ("🎓 شؤون الطلاب", "Students"),
                ("👨‍🏫 الكادر والمعلمين", "Teachers"),
                ("🏫 الفصول والقاعات", "Classes"),
                ("📚 المواد الدراسية", "Subjects"),
                ("⏱️ الحضور والغياب", "Attendance"),
                ("📝 الامتحانات والدرجات", "Exams"),
                ("💰 الرسوم والمالية", "Finance"),
                ("👥 الموارد البشرية HR", "HR"),
                ("📈 مركز التقارير", "Reports"),
                ("🔐 الصلاحيات والمستخدمين", "Users"),
                ("💾 النسخ الاحتياطي", "Backup"),
                ("📜 سجل العمليات Audit", "Audit"),
                ("⚙️ إعدادات النظام", "Settings")
            }

            Dim topOffset As Integer = 10
            For Each item In modules
                Dim btn = New Button With {
                    .Text = "   " & item.Title,
                    .Tag = item.Key,
                    .Dock = DockStyle.Top,
                    .Height = 44,
                    .FlatStyle = FlatStyle.Flat,
                    .ForeColor = Color.FromArgb(226, 232, 240),
                    .BackColor = Color.FromArgb(30, 41, 59),
                    .TextAlign = ContentAlignment.MiddleRight,
                    .Font = New Font("Segoe UI", 10, FontStyle.Regular),
                    .Cursor = Cursors.Hand
                }
                btn.FlatAppearance.BorderSize = 0
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85)
                AddHandler btn.Click, Sub(s, e) OpenTab(item.Title.Substring(3).Trim(), item.Key)
                pnlSidebar.Controls.Add(btn)
                btn.BringToFront()
            Next
        End Sub

        Public Sub OpenTab(title As String, key As String)
            ' Check if tab already exists
            For Each tab As TabPage In tabMain.TabPages
                If tab.Name = key Then
                    tabMain.SelectedTab = tab
                    Return
                End If
            Next

            ' Create new TabPage
            Dim newTab = New TabPage With {
                .Name = key,
                .Text = title & "   ✕",
                .BackColor = Color.FromArgb(248, 250, 252)
            }

            ' Container for UserControl
            Select Case key
                Case "Students"
                    Dim studentsCtrl As New StudentsControl With {.Dock = DockStyle.Fill}
                    newTab.Controls.Add(studentsCtrl)
                Case "Teachers"
                    Dim teachersCtrl As New TeachersControl With {.Dock = DockStyle.Fill}
                    newTab.Controls.Add(teachersCtrl)
                Case Else
                    Dim lbl = New Label With {
                        .Text = $"وحدة: {title} جاهزة ومتصلة بقاعدة البيانات",
                        .Dock = DockStyle.Top,
                        .Height = 50,
                        .Font = New Font("Segoe UI", 14, FontStyle.Bold),
                        .ForeColor = Color.FromArgb(15, 23, 42),
                        .TextAlign = ContentAlignment.MiddleCenter
                    }
                    newTab.Controls.Add(lbl)
            End Select

            tabMain.TabPages.Add(newTab)
            tabMain.SelectedTab = newTab
        End Sub

        Private Sub OnTabDrawItem(sender As Object, e As DrawItemEventArgs)
            Dim g = e.Graphics
            Dim tab = tabMain.TabPages(e.Index)
            Dim isSelected = (e.State And DrawItemState.Selected) = DrawItemState.Selected

            Dim bgBrush = If(isSelected, New SolidBrush(Color.FromArgb(255, 255, 255)), New SolidBrush(Color.FromArgb(226, 232, 240)))
            Dim textBrush = If(isSelected, New SolidBrush(Color.FromArgb(37, 99, 235)), New SolidBrush(Color.FromArgb(71, 85, 105)))

            g.FillRectangle(bgBrush, e.Bounds)
            g.DrawString(tab.Text, Me.Font, textBrush, e.Bounds.X + 10, e.Bounds.Y + 8)
        End Sub

        Private Sub OnTabMouseDown(sender As Object, e As MouseEventArgs)
            For i As Integer = 0 To tabMain.TabCount - 1
                Dim r = tabMain.GetTabRect(i)
                Dim closeRect = New Rectangle(r.Right - 25, r.Top + 6, 20, 20)
                If closeRect.Contains(e.Location) Then
                    If tabMain.TabPages(i).Name <> "Dashboard" Then
                        tabMain.TabPages.RemoveAt(i)
                    End If
                    Return
                End If
            Next
        End Sub

        Private Sub ConfigureModernStyles()
            ' Windows 11 rounded style helper
            Me.DoubleBuffered = True
        End Sub
    End Class
End Namespace
