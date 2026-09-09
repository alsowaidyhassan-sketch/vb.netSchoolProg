Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace Helpers
    ''' <summary>
    ''' مساعد لفحص وضع التصميم ومنع أي اتصال بقاعدة البيانات أثناء فتح النماذج في Visual Studio Designer
    ''' </summary>
    Public Module DesignModeHelper
        Public Function IsInDesignMode(Optional ctrl As Control = Nothing) As Boolean
            If ctrl IsNot Nothing AndAlso ctrl.DesignMode Then
                Return True
            End If

            If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
                Return True
            End If

            Try
                Dim procName = Process.GetCurrentProcess().ProcessName
                If procName.IndexOf("devenv", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                   procName.IndexOf("designertools", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                   procName.IndexOf("blend", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return True
                End If
            Catch
                ' تجاهل الأخطاء في البيئات المقيدة
            End Try

            Return False
        End Function
    End Module
End Namespace
