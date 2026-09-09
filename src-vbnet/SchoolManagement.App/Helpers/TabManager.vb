Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Helpers
    ''' <summary>
    ''' مدير علامات التبويب لنموذج MainForm
    ''' يفصل سلوك إدارة التبويبات عن تصميم الواجهة البصري
    ''' </summary>
    Public Class TabManager
        Private ReadOnly _tabMain As TabControl

        Public Sub New(tabMain As TabControl)
            _tabMain = tabMain
            ConfigureTabDrawing()
        End Sub

        Private Sub ConfigureTabDrawing()
            _tabMain.DrawMode = TabDrawMode.OwnerDrawFixed
            _tabMain.ItemSize = New Size(140, 36)
            _tabMain.SizeMode = TabSizeMode.Fixed

            AddHandler _tabMain.DrawItem, AddressOf OnTabDrawItem
            AddHandler _tabMain.MouseDown, AddressOf OnTabMouseDown
        End Sub

        Public Sub OpenTab(title As String, key As String, controlOrFormContent As Control)
            ' تحقق إذا كان التبويب مفتوحاً بالفعل
            For Each tab As TabPage In _tabMain.TabPages
                If tab.Name = key Then
                    _tabMain.SelectedTab = tab
                    Return
                End If
            Next

            ' إنشاء تبويب جديد
            Dim newTab = New TabPage With {
                .Name = key,
                .Text = title & "   ✕",
                .BackColor = Color.FromArgb(15, 23, 42)
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
                If _tabMain.TabPages(index).Name <> "Dashboard" Then
                    _tabMain.TabPages.RemoveAt(index)
                End If
            End If
        End Sub

        Public Sub CloseAllTabs()
            For i As Integer = _tabMain.TabCount - 1 To 0 Step -1
                If _tabMain.TabPages(i).Name <> "Dashboard" Then
                    _tabMain.TabPages.RemoveAt(i)
                End If
            Next
        End Sub

        Public Sub CloseOtherTabs(activeKey As String)
            For i As Integer = _tabMain.TabCount - 1 To 0 Step -1
                Dim tab = _tabMain.TabPages(i)
                If tab.Name <> "Dashboard" AndAlso tab.Name <> activeKey Then
                    _tabMain.TabPages.RemoveAt(i)
                End If
            Next
        End Sub

        Private Sub OnTabDrawItem(sender As Object, e As DrawItemEventArgs)
            Dim g = e.Graphics
            Dim tab = _tabMain.TabPages(e.Index)
            Dim isSelected = (e.State And DrawItemState.Selected) = DrawItemState.Selected

            Dim bgBrush = If(isSelected, New SolidBrush(Color.FromArgb(30, 41, 59)), New SolidBrush(Color.FromArgb(15, 23, 42)))
            Dim textBrush = If(isSelected, New SolidBrush(Color.FromArgb(96, 165, 250)), New SolidBrush(Color.FromArgb(148, 163, 184)))

            g.FillRectangle(bgBrush, e.Bounds)
            g.DrawString(tab.Text, _tabMain.Font, textBrush, e.Bounds.X + 10, e.Bounds.Y + 8)
        End Sub

        Private Sub OnTabMouseDown(sender As Object, e As MouseEventArgs)
            For i As Integer = 0 To _tabMain.TabCount - 1
                Dim r = _tabMain.GetTabRect(i)
                Dim closeRect = New Rectangle(r.Right - 25, r.Top + 6, 20, 20)
                If closeRect.Contains(e.Location) Then
                    CloseTab(i)
                    Return
                End If
            Next
        End Sub
    End Class
End Namespace
