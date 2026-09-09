Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Krypton.Toolkit

Namespace Controls
    ''' <summary>
    ''' جدول بيانات مبني على KryptonDataGridView
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernDataGrid
        Inherits KryptonDataGridView

        Public Sub New()
            MyBase.New()
            Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.ReadOnly = True
            Me.AllowUserToAddRows = False
            Me.AllowUserToDeleteRows = False
            Me.RowHeadersVisible = False
            Me.RowTemplate.Height = 42

            ' Header style (Krypton uses StateCommon for cells)
            Me.StateCommon.HeaderColumn.Content.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            Me.ColumnHeadersHeight = 44

            ' Row style
            Me.StateCommon.DataCell.Content.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        End Sub
    End Class
End Namespace
