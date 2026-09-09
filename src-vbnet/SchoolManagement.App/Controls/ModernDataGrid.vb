Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    ''' <summary>
    ''' جدول بيانات عصري مضبوط افتراضياً بالثيم الداكن والتنسيق الراقي
    ''' </summary>
    <ToolboxItem(True)>
    Public Class ModernDataGrid
        Inherits DataGridView

        Public Sub New()
            MyBase.New()
            Me.BackgroundColor = Color.FromArgb(15, 23, 42)
            Me.BorderStyle = BorderStyle.None
            Me.EnableHeadersVisualStyles = False
            Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.ReadOnly = True
            Me.AllowUserToAddRows = False
            Me.AllowUserToDeleteRows = False
            Me.RowHeadersVisible = False
            Me.RowTemplate.Height = 42

            ' Header style
            Me.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            Me.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.ColumnHeadersHeight = 44

            ' Row style
            Me.RowsDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
            Me.RowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
            Me.RowsDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            Me.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.RowsDefaultCellStyle.SelectionForeColor = Color.White

            ' Alternating row style
            Me.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50)
            Me.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240)
            Me.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White
        End Sub
    End Class
End Namespace
