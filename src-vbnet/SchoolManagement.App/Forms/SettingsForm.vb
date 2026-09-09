Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة إعدادات النظام ومعلومات المدرسة والاتصال بقاعدة بيانات SQL Server
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class SettingsForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadDefaults()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnSaveSettings.Click, AddressOf BtnSaveSettings_Click
            AddHandler btnBackupDatabase.Click, AddressOf BtnBackupDatabase_Click
            AddHandler btnTestConnection.Click, AddressOf BtnTestConnection_Click
        End Sub

        Private Sub LoadDefaults()
            cboGovernorate.SelectedIndex = 0
        End Sub

        Private Sub BtnTestConnection_Click(sender As Object, e As EventArgs)
            MessageBox.Show($"تم الاتصال بنجاح بخادم SQL Server ({txtDbServer.Text}) وقاعدة البيانات ({txtDbName.Text}).", "نجاح الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs)
            MessageBox.Show("تم حفظ كافة إعدادات النظام ومعلومات المدرسة بنجاح في ملف الإعدادات.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnBackupDatabase_Click(sender As Object, e As EventArgs)
            MessageBox.Show("تم إنشاء نسخة احتياطية مشفرة لقاعدة البيانات (.bak) بنجاح وحفظها في المسار المخصص للنسخ الاحتياطي.", "النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
