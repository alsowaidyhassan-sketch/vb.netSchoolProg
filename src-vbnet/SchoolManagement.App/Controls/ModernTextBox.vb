Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Krypton.Toolkit

Namespace Controls
    ''' <summary>
    ''' مربع نص مبني على KryptonTextBox
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernTextBox
        Inherits KryptonTextBox

        Public Sub New()
            MyBase.New()
            Me.StateCommon.Border.Rounding = 6
            Me.StateCommon.Content.Font = New Font("Segoe UI", 10.0F)
            Me.StateCommon.Back.Color1 = Color.White
            Me.StateCommon.Content.Color1 = Color.FromArgb(15, 23, 42)
        End Sub

        <Category("Modern Appearance")>
        <Description("النص التوضيحي الافتراضي للحقل")>
        Public Property PlaceholderText As String
            Get
                Return Me.CueHint.CueHintText
            End Get
            Set(value As String)
                Me.CueHint.CueHintText = value
            End Set
        End Property
    End Class
End Namespace
