Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Helpers
    ''' <summary>
    ''' مدير علامات التبويب الاحترافي (Professional Tab Manager)
    ''' يدعم شريط التحديد العلوي، زر إغلاق حقيقي، قائمة سياق (Context Menu)، النقر المزدوج والنقر الأوسط للإغلاق
    ''' </summary>
    Public Class TabManager
        Private ReadOnly _tabMain As TabControl
        Private ReadOnly _contextMenu As ContextMenuStrip
        Private _hoveredTabIndex As Integer = -1

        Public Sub New(tabMain As TabControl)
            _tabMain = tabMain
            ConfigureTabControl()
            InitializeContextMenu()
        End Sub

        Private Sub ConfigureTabControl()
            _tabMain.DrawMode = TabDrawMode.OwnerDrawFixed
            _tabMain.ItemSize = New Size(160, 40)
            _tabMain.SizeMode = TabSizeMode.Fixed
            _tabMain.Padding = New Point(16, 6)

            AddHandler _tabMain.DrawItem, AddressOf OnTabDrawItem
            AddHandler _tabMain.MouseDown, AddressOf OnTabMouseDown
            AddHandler _tabMain.MouseMove, AddressOf OnTabMouseMove
            AddHandler _tabMain.MouseLeave, AddressOf OnTabMouseLeave
            AddHandler _tabMain.MouseUp, AddressOf OnTabMouseUp
        End Sub

        Private Sub InitializeContextMenu()
            _contextMenu = New ContextMenuStrip()
            _contextMenu.RightToLeft = RightToLeft.Yes

            Dim mnuClose = New ToolStripMenuItem("إغلاق التاب", Nothing, Sub(s, e) CloseTab(_tabMain.SelectedIndex))
            Dim mnuCloseOthers = New ToolStripMenuItem("إغلاق التابات الأخرى", Nothing, Sub(s, e) CloseOtherTabsForSelectedIndex())
            Dim mnuCloseAll = New ToolStripMenuItem("إغلاق جميع التابات", Nothing, Sub(s, e) CloseAllTabs())
            Dim mnuSeparator = New ToolStripSeparator()
            Dim mnuReload = New ToolStripMenuItem("إعادة تحميل الصفحة", Nothing, Sub(s, e) ReloadCurrentTab())

            _contextMenu.Items.AddRange(New ToolStripItem() {mnuClose, mnuCloseOthers, mnuCloseAll, mnuSeparator, mnuReload})
            _tabMain.ContextMenuStrip = _contextMenu
        End Sub

        Public Sub OpenTab(title As String, key As String, controlOrFormContent As Control)
            ' تحقق من عدم فتح نفس التاب مرتين (منع التكرار)
            For Each tab As TabPage In _tabMain.TabPages
                If tab.Name = key Then
                    _tabMain.SelectedTab = tab
                    Return
                End If
            Next

            Dim newTab = New TabPage With {
                .Name = key,
                .Text = title,
                .BackColor = Color.FromArgb(248, 250, 252),
                .UseVisualStyleBackColor = True
            }

            If controlOrFormContent IsNot Nothing Then
                controlOrFormContent.Dock = DockStyle.Fill
                newTab.Controls.Add(controlOrFormContent)
            End If

            _tabMain.TabPages.Add(newTab)
            _tabMain.SelectedTab = newTab
        End Sub

        Public Sub CloseTab(index As Integer)
            If index >= 0 AndAlso index < _tabMain.TabCount Then
                Dim tab = _tabMain.TabPages(index)
                If tab.Name <> "Dashboard" Then
                    For Each ctrl As Control In tab.Controls
                        ctrl.Dispose()
                    Next
                    _tabMain.TabPages.RemoveAt(index)
                End If
            End If
        End Sub

        Public Sub CloseAllTabs()
            For i As Integer = _tabMain.TabCount - 1 To 0 Step -1
                Dim tab = _tabMain.TabPages(i)
                If tab.Name <> "Dashboard" Then
                    For Each ctrl As Control In tab.Controls
                        ctrl.Dispose()
                    Next
                    _tabMain.TabPages.RemoveAt(i)
                End If
            Next
        End Sub

        Public Sub CloseOtherTabsForSelectedIndex()
            Dim selectedIdx = _tabMain.SelectedIndex
            For i As Integer = _tabMain.TabCount - 1 To 0 Step -1
                Dim tab = _tabMain.TabPages(i)
                If tab.Name <> "Dashboard" AndAlso i <> selectedIdx Then
                    For Each ctrl As Control In tab.Controls
                        ctrl.Dispose()
                    Next
                    _tabMain.TabPages.RemoveAt(i)
                End If
            Next
        End Sub

        Private Sub ReloadCurrentTab()
            ' إعادة تحميل محتوى التاب النشط إن وجد
            If _tabMain.SelectedTab IsNot Nothing AndAlso _tabMain.SelectedTab.Name <> "Dashboard" Then
                ' يمكن إضافة منطق إعادة التحميل هنا
            End If
        End Sub

        Private Sub OnTabDrawItem(sender As Object, e As DrawItemEventArgs)
            Dim g = e.Graphics
            Dim tab = _tabMain.TabPages(e.Index)
            Dim isSelected = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            Dim isHovered = (e.Index = _hoveredTabIndex)

            Dim r = _tabMain.GetTabRect(e.Index)

            ' خلفية التاب
            Dim bgColor = If(isSelected, Color.White, If(isHovered, Color.FromArgb(241, 245, 249), Color.FromArgb(226, 232, 240)))
            Using bgBrush As New SolidBrush(bgColor)
                g.FillRectangle(bgBrush, r)
            End Using

            ' شريط التحديد العلوي للتاب النشط
            If isSelected Then
                Using accentBrush As New SolidBrush(Color.FromArgb(37, 99, 235))
                    g.FillRectangle(accentBrush, New Rectangle(r.X, r.Y, r.Width, 3))
                End Using
            End If

            ' لون النص
            Dim textColor = If(isSelected, Color.FromArgb(15, 23, 42), Color.FromArgb(71, 85, 105))
            Using textBrush As New SolidBrush(textColor)
                Dim textFormat As New StringFormat With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Center,
                    .Trimming = StringTrimming.EllipsisCharacter
                }
                Dim textRect As New Rectangle(r.X + 12, r.Y + 2, r.Width - 36, r.Height - 2)
                g.DrawString(tab.Text, FontManager.DefaultFont, textBrush, textRect, textFormat)
            End Using

            ' رسم زر الإغلاق (✕) للتابات غير الرئيسية
            If tab.Name <> "Dashboard" Then
                Dim closeRect = GetCloseButtonRect(r)
                Dim isCloseHovered = closeRect.Contains(_tabMain.PointToClient(Cursor.Position))
                Dim closeColor = If(isCloseHovered, Color.FromArgb(239, 68, 68), Color.FromArgb(148, 163, 184))

                Using closeBrush As New SolidBrush(closeColor)
                    Dim textFormat As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString("✕", New Font("Segoe UI", 8.5!, FontStyle.Bold), closeBrush, closeRect, textFormat)
                End Using
            End If
        End Sub

        Private Function GetCloseButtonRect(tabRect As Rectangle) As Rectangle
            Return New Rectangle(tabRect.Right - 26, tabRect.Y + (tabRect.Height - 18) \ 2, 18, 18)
        End Function

        Private Sub OnTabMouseDown(sender As Object, e As MouseEventArgs)
            For i As Integer = 0 To _tabMain.TabCount - 1
                Dim r = _tabMain.GetTabRect(i)
                Dim tab = _tabMain.TabPages(i)

                If tab.Name <> "Dashboard" Then
                    Dim closeRect = GetCloseButtonRect(r)
                    If closeRect.Contains(e.Location) Then
                        CloseTab(i)
                        Return
                    End If
                End If

                ' النقر المزدوج أو النقر الأوسط (Middle Click) للإغلاق
                If r.Contains(e.Location) Then
                    If e.Button = MouseButtons.Middle Then
                        CloseTab(i)
                        Return
                    End If
                End If
            Next
        End Sub

        Private Sub OnTabMouseUp(sender As Object, e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                For i As Integer = 0 To _tabMain.TabCount - 1
                    Dim r = _tabMain.GetTabRect(i)
                    If r.Contains(e.Location) Then
                        ' التحقق من النقر المزدوج
                        Exit For
                    End If
                Next
            End If
        End Sub

        Private Sub OnTabMouseMove(sender As Object, e As MouseEventArgs)
            Dim oldHover = _hoveredTabIndex
            _hoveredTabIndex = -1

            For i As Integer = 0 To _tabMain.TabCount - 1
                If _tabMain.GetTabRect(i).Contains(e.Location) Then
                    _hoveredTabIndex = i
                    Exit For
                End If
            Next

            If oldHover <> _hoveredTabIndex Then
                _tabMain.Invalidate()
            End If
        End Sub

        Private Sub OnTabMouseLeave(sender As Object, e As EventArgs)
            If _hoveredTabIndex <> -1 Then
                _hoveredTabIndex = -1
                _tabMain.Invalidate()
            End If
        End Sub
    End Class
End Namespace
