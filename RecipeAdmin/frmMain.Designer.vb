﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.bs = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbServing = New System.Windows.Forms.ComboBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrepTime = New System.Windows.Forms.TextBox()
        Me.txtCookTime = New System.Windows.Forms.TextBox()
        Me.txtIngredients = New System.Windows.Forms.TextBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbContributors = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.myMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.chkFavorite = New System.Windows.Forms.CheckBox()
        Me.txtContributor = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.bsNote = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.tmrWatch = New System.Windows.Forms.Timer(Me.components)
        CType(Me.bs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.myMenu.SuspendLayout()
        CType(Me.bsNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCategory
        '
        Me.cbCategory.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bs, "CategoryID", True))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(20, 92)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(121, 21)
        Me.cbCategory.TabIndex = 0
        '
        'bs
        '
        Me.bs.DataSource = GetType(RecipeLibrary.Recipe)
        '
        'cbServing
        '
        Me.cbServing.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bs, "ServingID", True))
        Me.cbServing.FormattingEnabled = True
        Me.cbServing.Location = New System.Drawing.Point(147, 92)
        Me.cbServing.Name = "cbServing"
        Me.cbServing.Size = New System.Drawing.Size(121, 21)
        Me.cbServing.TabIndex = 1
        '
        'txtTitle
        '
        Me.txtTitle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "Title", True))
        Me.txtTitle.Location = New System.Drawing.Point(20, 54)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(248, 20)
        Me.txtTitle.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(151, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Servings"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(422, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cook Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Preparation Time"
        '
        'txtPrepTime
        '
        Me.txtPrepTime.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "PrepareTime", True))
        Me.txtPrepTime.Location = New System.Drawing.Point(291, 93)
        Me.txtPrepTime.Name = "txtPrepTime"
        Me.txtPrepTime.Size = New System.Drawing.Size(121, 20)
        Me.txtPrepTime.TabIndex = 8
        Me.txtPrepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCookTime
        '
        Me.txtCookTime.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "CookTime", True))
        Me.txtCookTime.Location = New System.Drawing.Point(418, 93)
        Me.txtCookTime.Name = "txtCookTime"
        Me.txtCookTime.Size = New System.Drawing.Size(121, 20)
        Me.txtCookTime.TabIndex = 9
        Me.txtCookTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIngredients
        '
        Me.txtIngredients.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "IngredientsBlock", True))
        Me.txtIngredients.Location = New System.Drawing.Point(12, 172)
        Me.txtIngredients.Multiline = True
        Me.txtIngredients.Name = "txtIngredients"
        Me.txtIngredients.Size = New System.Drawing.Size(256, 207)
        Me.txtIngredients.TabIndex = 10
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Location = New System.Drawing.Point(372, 155)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(61, 13)
        Me.lblInstructions.TabIndex = 13
        Me.lblInstructions.Text = "Instructions"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(117, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Ingredients"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(579, 57)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Insert"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(579, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Get"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbContributors
        '
        Me.cbContributors.FormattingEnabled = True
        Me.cbContributors.Location = New System.Drawing.Point(303, 30)
        Me.cbContributors.Name = "cbContributors"
        Me.cbContributors.Size = New System.Drawing.Size(143, 21)
        Me.cbContributors.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(579, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(579, 86)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'myMenu
        '
        Me.myMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.PrintToolStripMenuItem, Me.PrintToolStripMenuItem1})
        Me.myMenu.Location = New System.Drawing.Point(0, 0)
        Me.myMenu.Name = "myMenu"
        Me.myMenu.Size = New System.Drawing.Size(675, 24)
        Me.myMenu.TabIndex = 20
        Me.myMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.PrintToolStripMenuItem.Text = "&Edit"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'PrintToolStripMenuItem1
        '
        Me.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        Me.PrintToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem1.Text = "&Print"
        '
        'txtInstructions
        '
        Me.txtInstructions.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "Instructions", True))
        Me.txtInstructions.Location = New System.Drawing.Point(303, 172)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(241, 207)
        Me.txtInstructions.TabIndex = 21
        '
        'chkFavorite
        '
        Me.chkFavorite.AutoSize = True
        Me.chkFavorite.Location = New System.Drawing.Point(452, 56)
        Me.chkFavorite.Name = "chkFavorite"
        Me.chkFavorite.Size = New System.Drawing.Size(64, 17)
        Me.chkFavorite.TabIndex = 22
        Me.chkFavorite.Text = "Favorite"
        Me.chkFavorite.UseVisualStyleBackColor = True
        '
        'txtContributor
        '
        Me.txtContributor.Location = New System.Drawing.Point(303, 54)
        Me.txtContributor.Name = "txtContributor"
        Me.txtContributor.Size = New System.Drawing.Size(143, 20)
        Me.txtContributor.TabIndex = 23
        '
        'txtNotes
        '
        Me.txtNotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsNote, "Notes", True))
        Me.txtNotes.Location = New System.Drawing.Point(12, 399)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(532, 85)
        Me.txtNotes.TabIndex = 24
        '
        'bsNote
        '
        Me.bsNote.DataSource = GetType(RecipeLibrary.Note)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 383)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Notes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Web Inspiration"
        '
        'txtURL
        '
        Me.txtURL.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bs, "SourceURL", True))
        Me.txtURL.Location = New System.Drawing.Point(20, 131)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(519, 20)
        Me.txtURL.TabIndex = 27
        '
        'tmrWatch
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 496)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtContributor)
        Me.Controls.Add(Me.chkFavorite)
        Me.Controls.Add(Me.txtInstructions)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbContributors)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIngredients)
        Me.Controls.Add(Me.txtCookTime)
        Me.Controls.Add(Me.txtPrepTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.cbServing)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.myMenu)
        Me.MainMenuStrip = Me.myMenu
        Me.Name = "frmMain"
        Me.Text = "Recipe Console"
        CType(Me.bs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.myMenu.ResumeLayout(False)
        Me.myMenu.PerformLayout()
        CType(Me.bsNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cbServing As System.Windows.Forms.ComboBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrepTime As System.Windows.Forms.TextBox
    Friend WithEvents txtCookTime As System.Windows.Forms.TextBox
    Friend WithEvents txtIngredients As System.Windows.Forms.TextBox
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bs As System.Windows.Forms.BindingSource
    Friend WithEvents cbContributors As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents myMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
    Friend WithEvents chkFavorite As System.Windows.Forms.CheckBox
    Friend WithEvents txtContributor As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bsNote As System.Windows.Forms.BindingSource
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents tmrWatch As System.Windows.Forms.Timer
End Class
