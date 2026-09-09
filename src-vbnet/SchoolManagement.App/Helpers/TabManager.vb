Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Krypton.Toolkit
Imports Krypton.Navigator

Namespace Helpers
    Public Class TabManager
        Private ReadOnly _tabMain As KryptonNavigator
        
        Public Sub New(tabMain As KryptonNavigator)
            _tabMain = tabMain
            ConfigureNavigator()
        End Sub

        Private Sub ConfigureNavigator()
            _tabMain.Button.ButtonDisplayLogic = ButtonDisplayLogic.Context
            _tabMain.Button.CloseButtonAction = CloseButtonAction.RemovePageAndDispose
            _tabMain.Button.CloseButtonDisplay = ButtonDisplay.Show
            
            _tabMain.AllowPageReorder = True
            _tabMain.AllowTabFocus = True
            
            ' Adding Context Menu for Tabs
            Dim contextMenu As New KryptonContextMenu()
            Dim items As New KryptonContextMenuItems()
            
            Dim mnuClose As New KryptonContextMenuItem("إغلاق التاب")
            AddHandler mnuClose.Click, Sub(s, e) CloseTab(_tabMain.SelectedPage)
            
            Dim mnuCloseOthers As New KryptonContextMenuItem("إغلاق التابات الأخرى")
            AddHandler mnuCloseOthers.Click, Sub(s, e) CloseOtherTabsForSelected()
            
            Dim mnuCloseAll As New KryptonContextMenuItem("إغلاق جميع التابات")
            AddHandler mnuCloseAll.Click, Sub(s, e) CloseAllTabs()
            
            items.Items.Add(mnuClose)
            items.Items.Add(mnuCloseOthers)
            items.Items.Add(mnuCloseAll)
            contextMenu.Items.Add(items)
            
            _tabMain.KryptonContextMenu = contextMenu
            
            ' Middle click logic
            AddHandler _tabMain.MouseDown, AddressOf OnNavigatorMouseDown
        End Sub

        Public Sub OpenTab(title As String, key As String, controlOrFormContent As Control)
            ' منع التكرار
            For Each page As KryptonPage In _tabMain.Pages
                If page.UniqueName = key Then
                    _tabMain.SelectedPage = page
                    Return
                End If
            Next

            Dim newPage = New KryptonPage() With {
                .UniqueName = key,
                .Text = title,
                .TextTitle = title
            }

            If controlOrFormContent IsNot Nothing Then
                controlOrFormContent.Dock = DockStyle.Fill
                newPage.Controls.Add(controlOrFormContent)
            End If

            _tabMain.Pages.Add(newPage)
            _tabMain.SelectedPage = newPage
        End Sub

        Public Sub CloseTab(page As KryptonPage)
            If page IsNot Nothing AndAlso page.UniqueName <> "Dashboard" Then
                _tabMain.Pages.Remove(page)
                page.Dispose()
            End If
        End Sub

        Public Sub CloseAllTabs()
            For i As Integer = _tabMain.Pages.Count - 1 To 0 Step -1
                Dim page = _tabMain.Pages(i)
                If page.UniqueName <> "Dashboard" Then
                    _tabMain.Pages.Remove(page)
                    page.Dispose()
                End If
            Next
        End Sub

        Public Sub CloseOtherTabsForSelected()
            Dim selectedPage = _tabMain.SelectedPage
            For i As Integer = _tabMain.Pages.Count - 1 To 0 Step -1
                Dim page = _tabMain.Pages(i)
                If page.UniqueName <> "Dashboard" AndAlso page IsNot selectedPage Then
                    _tabMain.Pages.Remove(page)
                    page.Dispose()
                End If
            Next
        End Sub

        Private Sub OnNavigatorMouseDown(sender As Object, e As MouseEventArgs)
            If e.Button = MouseButtons.Middle Then
                Dim target = _tabMain.HitTest(e.Location)
                If target IsNot Nothing AndAlso TypeOf target Is KryptonPage Then
                    CloseTab(DirectCast(target, KryptonPage))
                End If
            End If
        End Sub
    End Class
End Namespace
