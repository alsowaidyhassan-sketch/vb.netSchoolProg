Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Krypton.Toolkit

Namespace Controls
    ''' <summary>
    ''' زر مبني على KryptonButton يوفر توافقية مع خصائص ModernButton القديمة
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernButton
        Inherits KryptonButton

        Private _borderRadius As Integer = 8
        Private _hoverColor As Color = Color.FromArgb(59, 130, 246)

        Public Sub New()
            MyBase.New()
            Me.Size = New Size(140, 38)
            Me.Cursor = Cursors.Hand
            
            ' Configure Krypton styling
            Me.StateCommon.Border.Rounding = _borderRadius
            Me.StateCommon.Content.ShortText.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
            Me.OverrideDefault.Back.Color1 = Color.FromArgb(37, 99, 235)
            Me.StateCommon.Back.Color1 = Color.FromArgb(37, 99, 235)
            Me.StateCommon.Content.ShortText.Color1 = Color.White
            
            Me.StateTracking.Back.Color1 = _hoverColor
            Me.StatePressed.Back.Color1 = Color.FromArgb(30, 64, 175)
        End Sub

        <Category("Modern Appearance")>
        <Description("نصف قطر استدارة الحواف")>
        Public Property BorderRadius As Integer
            Get
                Return _borderRadius
            End Get
            Set(value As Integer)
                _borderRadius = Math.Max(0, value)
                Me.StateCommon.Border.Rounding = _borderRadius
            End Set
        End Property

        <Category("Modern Appearance")>
        <Description("لون الخلفية عند تمرير الفأرة")>
        Public Property HoverColor As Color
            Get
                Return _hoverColor
            End Get
            Set(value As Color)
                _hoverColor = value
                Me.StateTracking.Back.Color1 = _hoverColor
            End Set
        End Property
    End Class
End Namespace
