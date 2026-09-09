Imports System.Drawing

Namespace Helpers
    Public Module ThemeManager
        Public Structure ColorPalette
            Public Shared ReadOnly PrimaryNavy As Color = Color.FromArgb(15, 23, 42)    ' Slate 900
            Public Shared ReadOnly SecondaryNavy As Color = Color.FromArgb(30, 41, 59)  ' Slate 800
            Public Shared ReadOnly AccentBlue As Color = Color.FromArgb(37, 99, 235)    ' Blue 600
            Public Shared ReadOnly BackgroundLight As Color = Color.FromArgb(248, 250, 252) ' Slate 50
            Public Shared ReadOnly CardBackground As Color = Color.White
            Public Shared ReadOnly TextPrimary As Color = Color.FromArgb(15, 23, 42)
            Public Shared ReadOnly TextSecondary As Color = Color.FromArgb(100, 116, 139)
            Public Shared ReadOnly BorderColor As Color = Color.FromArgb(226, 232, 240)
            Public Shared ReadOnly SuccessGreen As Color = Color.FromArgb(16, 185, 129)
            Public Shared ReadOnly DangerRed As Color = Color.FromArgb(239, 68, 68)
            Public Shared ReadOnly WarningOrange As Color = Color.FromArgb(245, 158, 11)
        End Structure
    End Module
End Namespace
