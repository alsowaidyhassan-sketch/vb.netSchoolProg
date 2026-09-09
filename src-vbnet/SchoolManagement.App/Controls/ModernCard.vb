Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls
    ''' <summary>
    ''' بطاقة عصرية بتصميم مسطح وحواف مستديرة لعرض الإحصائيات أو تجميع الحقول
    ''' قابلة للفتح والتعديل من Visual Studio Designer
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernCard
        Inherits Panel

        Private _borderRadius As Integer = 12
        Private _cardColor As Color = Color.FromArgb(30, 41, 59)
        Private _borderColor As Color = Color.FromArgb(51, 65, 85)
        Private _borderWidth As Integer = 1

        Public Sub New()
            MyBase.New()
            Me.DoubleBuffered = True
            Me.BackColor = Color.Transparent
            Me.Padding = New Padding(12)
            Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            Me.ForeColor = Color.FromArgb(241, 245, 249)
            Me.Size = New Size(240, 120)
        End Sub

        <Category("Modern Card")>
        <Description("نصف قطر استدارة زوايا البطاقة")>
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

        <Category("Modern Card")>
        <Description("لون خلفية البطاقة الداخلي")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property CardColor As Color
            Get
                Return _cardColor
            End Get
            Set(value As Color)
                _cardColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Modern Card")>
        <Description("لون إطار البطاقة الخارجي")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                _borderColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Modern Card")>
        <Description("سماكة إطار البطاقة")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property BorderWidth As Integer
            Get
                Return _borderWidth
            End Get
            Set(value As Integer)
                _borderWidth = Math.Max(0, value)
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
            Using path = CreateRoundedRectangle(rect, _borderRadius)
                Using brush As New SolidBrush(_cardColor)
                    g.FillPath(brush, path)
                End Using

                If _borderWidth > 0 Then
                    Using pen As New Pen(_borderColor, _borderWidth)
                        g.DrawPath(pen, path)
                    End Using
                End If
            End Using
        End Sub

        Private Function CreateRoundedRectangle(rect As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()
            If radius <= 0 Then
                path.AddRectangle(rect)
                Return path
            End If

            Dim diameter = radius * 2
            Dim arc = New Rectangle(rect.X, rect.Y, diameter, diameter)

            path.AddArc(arc, 180, 90)
            arc.X = rect.Right - diameter
            path.AddArc(arc, 270, 90)
            arc.Y = rect.Bottom - diameter
            path.AddArc(arc, 0, 90)
            arc.X = rect.Left
            path.AddArc(arc, 90, 90)
            path.CloseFigure()
            Return path
        End Function
    End Class
End Namespace
