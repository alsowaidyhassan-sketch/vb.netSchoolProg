Imports System.Drawing

Namespace Helpers
    ''' <summary>
    ''' مدير الخطوط المركزي للنظام - مع دعم خط كايرو (Cairo) مع بديل آمن (Segoe UI) لوقت التصميم
    ''' </summary>
    Public Module FontManager
        Private ReadOnly PrimaryFontFamily As String = "Cairo"
        Private ReadOnly FallbackFontFamily As String = "Segoe UI"

        Private Function GetSafeFontFamily() As String
            Try
                Dim family = New FontFamily(PrimaryFontFamily)
                Return PrimaryFontFamily
            Catch
                Return FallbackFontFamily
            End Try
        End Function

        Public ReadOnly Property DefaultFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 10.0F, FontStyle.Regular)
            End Get
        End Property

        Public ReadOnly Property TitleFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 18.0F, FontStyle.Bold)
            End Get
        End Property

        Public ReadOnly Property SectionFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 14.0F, FontStyle.Bold)
            End Get
        End Property

        Public ReadOnly Property ButtonFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 10.0F, FontStyle.Bold)
            End Get
        End Property

        Public ReadOnly Property GridFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 10.0F, FontStyle.Regular)
            End Get
        End Property

        Public ReadOnly Property SmallFont As Font
            Get
                Return New Font(GetSafeFontFamily(), 9.0F, FontStyle.Regular)
            End Get
        End Property
    End Module
End Namespace
