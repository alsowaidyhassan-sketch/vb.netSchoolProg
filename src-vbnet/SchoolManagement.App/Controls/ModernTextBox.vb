Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    ''' <summary>
    ''' مربع نص عصري يدعم الألوان الداكنة والنص التوضيحي (Placeholder) ومتوافق مع Visual Studio Designer
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernTextBox
        Inherits TextBox

        Private _placeholderText As String = String.Empty

        Public Sub New()
            MyBase.New()
            Me.BackColor = Color.FromArgb(15, 23, 42)
            Me.ForeColor = Color.White
            Me.BorderStyle = BorderStyle.FixedSingle
            Me.Font = New Font("Segoe UI", 10.0F)
        End Sub

        <Category("Modern Appearance")>
        <Description("النص التوضيحي الافتراضي للحقل")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Shadows Property PlaceholderText As String
            Get
                Return MyBase.PlaceholderText
            End Get
            Set(value As String)
                MyBase.PlaceholderText = value
            End Set
        End Property
    End Class
End Namespace
