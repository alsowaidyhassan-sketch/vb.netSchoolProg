Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Krypton.Toolkit

Namespace Controls
    ''' <summary>
    ''' بطاقة مبنية على KryptonGroup 
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernCard
        Inherits KryptonGroup

        Private _borderRadius As Integer = 12

        Public Sub New()
            MyBase.New()
            Me.Size = New Size(240, 120)
            
            Me.StateCommon.Border.Rounding = _borderRadius
            Me.StateCommon.Border.Width = 1
            Me.StateCommon.Border.Color1 = Color.FromArgb(51, 65, 85)
            Me.StateCommon.Back.Color1 = Color.FromArgb(30, 41, 59)
            Me.GroupBackStyle = PaletteBackStyle.ControlCustom1
            Me.GroupBorderStyle = PaletteBorderStyle.ControlCustom1
        End Sub

        <Category("Modern Card")>
        <Description("نصف قطر استدارة زوايا البطاقة")>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                _borderRadius = Math.Max(0, value)
                Me.StateCommon.Border.Rounding = _borderRadius
            End Set
        End Property

        <Category("Modern Card")>
        <Description("لون خلفية البطاقة الداخلي")>
        Public Property CardColor As Color
            Get
                Return Me.StateCommon.Back.Color1
            End Get
            Set(value As Color)
                Me.StateCommon.Back.Color1 = value
            End Set
        End Property

        <Category("Modern Card")>
        <Description("لون إطار البطاقة الخارجي")>
        Public Property BorderColor As Color
            Get
                Return Me.StateCommon.Border.Color1
            End Get
            Set(value As Color)
                Me.StateCommon.Border.Color1 = value
            End Set
        End Property

        <Category("Modern Card")>
        <Description("سماكة إطار البطاقة")>
        Public Property BorderWidth As Integer
            Get
                Return CInt(Me.StateCommon.Border.Width)
            End Get
            Set(value As Integer)
                Me.StateCommon.Border.Width = Math.Max(0, value)
            End Set
        End Property
    End Class
End Namespace
