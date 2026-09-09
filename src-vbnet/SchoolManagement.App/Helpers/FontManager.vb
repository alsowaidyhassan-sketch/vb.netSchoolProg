Imports System.Drawing

Namespace Helpers
    ''' <summary>
    ''' مدير الخطوط المركزي للنظام - مع دعم خط كايرو (Cairo) مع بديل آمن (Segoe UI) لوقت التصميم
    ''' </summary>
    Public NotInheritable Class FontManager
        Private Sub New()
        End Sub

        Private Shared ReadOnly PrimaryFontFamilyName As String = "Cairo"
        Private Shared ReadOnly FallbackFontFamilyName As String = "Segoe UI"

        Private Shared _cachedFamily As FontFamily = Nothing

        Private Shared Function GetSafeFontFamily() As FontFamily
            If _cachedFamily IsNot Nothing Then Return _cachedFamily
            Try
                _cachedFamily = New FontFamily(PrimaryFontFamilyName)
            Catch
                Try
                    _cachedFamily = New FontFamily(FallbackFontFamilyName)
                Catch
                    _cachedFamily = FontFamily.GenericSansSerif
                End Try
            End Try
            Return _cachedFamily
        End Function

        Private Shared ReadOnly _defaultFont As New Font(GetSafeFontFamily(), 10.0F, FontStyle.Regular)
        Private Shared ReadOnly _titleFont As New Font(GetSafeFontFamily(), 18.0F, FontStyle.Bold)
        Private Shared ReadOnly _sectionFont As New Font(GetSafeFontFamily(), 14.0F, FontStyle.Bold)
        Private Shared ReadOnly _buttonFont As New Font(GetSafeFontFamily(), 10.0F, FontStyle.Bold)
        Private Shared ReadOnly _gridFont As New Font(GetSafeFontFamily(), 10.0F, FontStyle.Regular)
        Private Shared ReadOnly _smallFont As New Font(GetSafeFontFamily(), 9.0F, FontStyle.Regular)

        Public Shared ReadOnly Property DefaultFont As Font
            Get
                Return _defaultFont
            End Get
        End Property

        Public Shared ReadOnly Property TitleFont As Font
            Get
                Return _titleFont
            End Get
        End Property

        Public Shared ReadOnly Property SectionFont As Font
            Get
                Return _sectionFont
            End Get
        End Property

        Public Shared ReadOnly Property ButtonFont As Font
            Get
                Return _buttonFont
            End Get
        End Property

        Public Shared ReadOnly Property GridFont As Font
            Get
                Return _gridFont
            End Get
        End Property

        Public Shared ReadOnly Property SmallFont As Font
            Get
                Return _smallFont
            End Get
        End Property
    End Class
End Namespace
