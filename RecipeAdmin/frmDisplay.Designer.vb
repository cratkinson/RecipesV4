<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pDisplay = New System.Windows.Forms.Panel()
        Me.wbDisplay = New System.Windows.Forms.WebBrowser()
        Me.pDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'pDisplay
        '
        Me.pDisplay.Controls.Add(Me.wbDisplay)
        Me.pDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pDisplay.Location = New System.Drawing.Point(0, 0)
        Me.pDisplay.Name = "pDisplay"
        Me.pDisplay.Size = New System.Drawing.Size(558, 486)
        Me.pDisplay.TabIndex = 0
        '
        'wbDisplay
        '
        Me.wbDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbDisplay.Location = New System.Drawing.Point(0, 0)
        Me.wbDisplay.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDisplay.Name = "wbDisplay"
        Me.wbDisplay.Size = New System.Drawing.Size(558, 486)
        Me.wbDisplay.TabIndex = 0
        '
        'frmDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 486)
        Me.Controls.Add(Me.pDisplay)
        Me.Name = "frmDisplay"
        Me.Text = "frmDisplay"
        Me.pDisplay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pDisplay As System.Windows.Forms.Panel
    Friend WithEvents wbDisplay As System.Windows.Forms.WebBrowser
End Class
