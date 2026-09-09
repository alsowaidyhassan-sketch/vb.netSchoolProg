Imports System.Windows.Forms
Imports Krypton.Toolkit

Namespace Services
    Public Class DialogService
        Public Shared Sub ShowInfo(message As String, Optional title As String = "معلومة")
            KryptonMessageBox.Show(message, title, KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information)
        End Sub

        Public Shared Sub ShowError(message As String, Optional title As String = "خطأ")
            KryptonMessageBox.Show(message, title, KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error)
        End Sub

        Public Shared Sub ShowWarning(message As String, Optional title As String = "تحذير")
            KryptonMessageBox.Show(message, title, KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Warning)
        End Sub

        Public Shared Function AskQuestion(message As String, Optional title As String = "تأكيد") As Boolean
            Return KryptonMessageBox.Show(message, title, KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) = DialogResult.Yes
        End Function
    End Class
End Namespace
