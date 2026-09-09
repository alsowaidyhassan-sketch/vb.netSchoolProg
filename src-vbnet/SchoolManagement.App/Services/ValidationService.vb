Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Krypton.Toolkit

Namespace Services
    Public Class ValidationService
        Public Shared Function ValidateRequired(text As String, fieldName As String) As Boolean
            If String.IsNullOrWhiteSpace(text) Then
                DialogService.ShowError($"حقل {fieldName} مطلوب ولا يمكن تركه فارغاً.", "تحقق من الإدخال")
                Return False
            End If
            Return True
        End Function
        
        Public Shared Function ValidateEmail(email As String) As Boolean
            If Not String.IsNullOrWhiteSpace(email) Then
                Dim emailPattern = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
                If Not Regex.IsMatch(email, emailPattern) Then
                    DialogService.ShowError("صيغة البريد الإلكتروني غير صحيحة.", "تحقق من الإدخال")
                    Return False
                End If
            End If
            Return True
        End Function
        
        Public Shared Function ValidateNumber(text As String, fieldName As String, ByRef outNumber As Integer) As Boolean
            If Not Integer.TryParse(text, outNumber) Then
                DialogService.ShowError($"يجب أن يحتوي حقل {fieldName} على أرقام فقط.", "تحقق من الإدخال")
                Return False
            End If
            Return True
        End Function
    End Class
End Namespace
