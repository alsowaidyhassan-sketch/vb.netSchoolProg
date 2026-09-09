Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms

Namespace Services
    Public Class IconService
        Private Shared ReadOnly _iconFont As Font
        
        Shared Sub New()
            ' Initialize font logic here if you want to use a specific font for icons.
            ' Example: Load an embedded TTF like FontAwesome or MaterialIcons.
            ' For now, we fallback to Segoe UI Symbol
            _iconFont = New Font("Segoe UI Symbol", 16, FontStyle.Regular)
        End Sub
        
        Public Shared Function GetIcon(iconChar As String, size As Integer, color As Color) As Image
            Dim bmp As New Bitmap(size, size)
            Using g = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                
                Using brush = New SolidBrush(color)
                    Dim font As New Font(_iconFont.FontFamily, size * 0.7F, FontStyle.Regular)
                    Dim format As New StringFormat() With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(iconChar, font, brush, New RectangleF(0, 0, size, size), format)
                End Using
            End Using
            Return bmp
        End Function
    End Class
End Namespace
