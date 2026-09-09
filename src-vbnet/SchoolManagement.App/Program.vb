Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Forms
Imports SchoolManagement.App.Helpers

Public Module Program
    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        
        ' Initialize Krypton Theme
        ThemeManager.InitializeTheme()
        
        Application.Run(New MainForm())
    End Sub
End Module
