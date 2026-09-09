Imports System.Drawing
Imports Krypton.Toolkit

Namespace Helpers
    Public Module ThemeManager
        Private ReadOnly _globalPalette As New KryptonPalette()
        Private ReadOnly _kryptonManager As New KryptonManager()

        Public Sub InitializeTheme()
            _globalPalette.BasePaletteMode = PaletteMode.Office365Blue
            _kryptonManager.GlobalPalette = _globalPalette
            
            ' Add custom colors if needed on top of the base palette
            _globalPalette.Common.StateCommon.Back.Color1 = Color.FromArgb(248, 250, 252) ' BackgroundLight
        End Sub

        Public Sub SetTheme(themeMode As PaletteMode)
            _globalPalette.BasePaletteMode = themeMode
            _kryptonManager.GlobalPalette = _globalPalette
        End Sub

        Public Structure ColorPalette
            Public Shared ReadOnly PrimaryNavy As Color = Color.FromArgb(15, 23, 42)
            Public Shared ReadOnly SecondaryNavy As Color = Color.FromArgb(30, 41, 59)
            Public Shared ReadOnly AccentBlue As Color = Color.FromArgb(37, 99, 235)
            Public Shared ReadOnly BackgroundLight As Color = Color.FromArgb(248, 250, 252)
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
