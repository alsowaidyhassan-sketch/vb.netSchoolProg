Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls
    ''' <summary>
    ''' زر عصري بتصميم مسطح وحواف مستديرة ودعم كامل لـ Visual Studio Designer
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernButton
        Inherits Button

        Private _borderRadius As Integer = 8
        Private _hoverColor As Color = Color.FromArgb(59, 130, 246)
        Private _baseBackColor As Color = Color.FromArgb(37, 99, 235)
        Private _isHovered As Boolean = False

        Public Sub New()
            MyBase.New()
            Me.FlatStyle = FlatStyle.Flat
            Me.FlatAppearance.BorderSize = 0
            Me.BackColor = _baseBackColor
            Me.ForeColor = Color.White
            Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
            Me.Size = New Size(140, 38)
            Me.Cursor = Cursors.Hand
            Me.DoubleBuffered = True
        End Sub

        <Category("Modern Appearance")>
        <Description("نصف قطر استدارة الحواف")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                _borderRadius = Math.Max(0, value)
                Me.Invalidate()
            End Set
        End Property

        <Category("Modern Appearance")>
        <Description("لون الخلفية عند تمرير الفأرة")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property HoverColor As Color
            Get
                Return _hoverColor
            End Get
            Set(value As Color)
                _hoverColor = value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            _isHovered = True
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _isHovered = False
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            MyBase.OnPaint(pevent)
            Dim g = pevent.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim currentBg = If(_isHovered, _hoverColor, Me.BackColor)

            Using brush As New SolidBrush(currentBg)
                Using path = CreateRoundedRectangle(Me.ClientRectangle, _borderRadius)
                    Me.Region = New Region(path)
                    g.FillPath(brush, path)
                End Using
            End Using

            ' رسم النص
            TextRenderer.DrawText(
                g,
                Me.Text,
                Me.Font,
                Me.ClientRectangle,
                Me.ForeColor,
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.SingleLine
            )
        End Sub

        Private Function CreateRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            Dim diameter = radius * 2
            Dim arc = New Rectangle(rect.X, rect.Y, diameter, diameter)

            ' الزاوية العلوية اليسرى
            path.AddArc(arc, 180, 90)

            ' الزاوية العلوية اليمنى
            arc.X = rect.Right - diameter
            path.AddArc(arc, 270, 90)

            ' الزاوية السفلية اليمنى
            arc.Y = rect.Bottom - diameter
            path.AddArc(arc, 0, 90)

            ' الزاوية السفلية اليسرى
            arc.X = rect.Left
            path.AddArc(arc, 90, 90)

            path.CloseFigure()
            Return path
        End Function
    End Class
End Namespace
