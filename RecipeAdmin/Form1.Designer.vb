<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnCategories = New System.Windows.Forms.Button()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.btnUnits = New System.Windows.Forms.Button()
        Me.btnServings = New System.Windows.Forms.Button()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCategories
        '
        Me.btnCategories.Location = New System.Drawing.Point(12, 12)
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(75, 23)
        Me.btnCategories.TabIndex = 0
        Me.btnCategories.Text = "Categories"
        Me.btnCategories.UseVisualStyleBackColor = True
        '
        'gv
        '
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Location = New System.Drawing.Point(12, 41)
        Me.gv.Name = "gv"
        Me.gv.Size = New System.Drawing.Size(459, 339)
        Me.gv.TabIndex = 1
        '
        'btnUnits
        '
        Me.btnUnits.Location = New System.Drawing.Point(93, 12)
        Me.btnUnits.Name = "btnUnits"
        Me.btnUnits.Size = New System.Drawing.Size(75, 23)
        Me.btnUnits.TabIndex = 2
        Me.btnUnits.Text = "Units"
        Me.btnUnits.UseVisualStyleBackColor = True
        '
        'btnServings
        '
        Me.btnServings.Location = New System.Drawing.Point(174, 12)
        Me.btnServings.Name = "btnServings"
        Me.btnServings.Size = New System.Drawing.Size(75, 23)
        Me.btnServings.TabIndex = 3
        Me.btnServings.Text = "Servings"
        Me.btnServings.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 392)
        Me.Controls.Add(Me.btnServings)
        Me.Controls.Add(Me.btnUnits)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.btnCategories)
        Me.Name = "Form1"
        Me.Text = "Recipe Administration"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCategories As System.Windows.Forms.Button
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents btnUnits As System.Windows.Forms.Button
    Friend WithEvents btnServings As System.Windows.Forms.Button

End Class
