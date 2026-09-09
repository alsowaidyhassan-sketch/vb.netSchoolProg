Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Forms

Public Module Program
    <STAThread>
    Public Sub Main()
        ApplicationConfiguration.Initialize()
        Application.Run(New MainForm())
    End Sub
End Module
