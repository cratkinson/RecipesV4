Imports RecipeLibrary
Public Class frmMain
    Private theApp As App = New App
    Private theUser As Contributor = theApp.Contributor_Get_By_Email("chip@atkinsons.com")
    Private hasChanges As Boolean = False
    Private isLoading As Boolean = False
    Private isStarting As Boolean = False
    Private EmptyRecipe As Recipe = New Recipe

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        isStarting = True

        AddHandler txtURL.KeyPress, AddressOf aKeyPressEvent
        AddHandler txtInstructions.KeyPress, AddressOf aKeyPressEvent
        AddHandler txtTitle.KeyPress, AddressOf aKeyPressEvent
        AddHandler txtIngredients.KeyPress, AddressOf aKeyPressEvent
        AddHandler txtPrepTime.KeyPress, AddressOf aKeyPressEvent
        AddHandler txtCookTime.KeyPress, AddressOf aKeyPressEvent

        With cbCategory
            .DataSource = theApp.Category_Get_All
            .DisplayMember = "Description"
            .ValueMember = "CategoryID"
            .SelectedIndex = 0
        End With

        With cbServing
            .DataSource = theApp.Serving_Get_All
            .DisplayMember = "Description"
            .ValueMember = "ServingID"
            .SelectedIndex = 0
        End With

        With cbContributors
            .DataSource = theApp.Contributor_Get_All
            .DisplayMember = "Name"
            .ValueMember = "ContributorID"
            .SelectedIndex = 0
        End With

        With cbRecipes
            .DataSource = theApp.Recipe_Get_All
            .DisplayMember = "Title"
            .ValueMember = "RecipeID"
            .SelectedIndex = -1
        End With

        Dim b As New Binding("Text", bs, "Contributor.Name")
        lblContributor.DataBindings.Add(b)
        'b = New Binding("Image", bs, "RecipeImage.PhotoAsImage")
        'pb.DataBindings.Add(b)

        AddHandler cbCategory.SelectedIndexChanged, AddressOf aComboBoxIndexChanged
        AddHandler cbServing.SelectedIndexChanged, AddressOf aComboBoxIndexChanged

        isStarting = False
        tmrWatch.Start()
        EmptyRecipe = bs.DataSource

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim r As New Recipe
        With r
            .AddIngredients(txtIngredients.Text)
            .Title = txtTitle.Text
            .PrepareTime = IIf(txtPrepTime.Text = String.Empty, "0", txtPrepTime.Text)
            .CookTime = IIf(txtCookTime.Text = String.Empty, "0", txtCookTime.Text)
            .ContributorID = theUser.ContributorID
            .CategoryID = cbCategory.SelectedValue
            .ServingID = cbServing.SelectedValue
            .Instructions = txtInstructions.Text

        End With
        theApp.Recipe_Insert(r)
        theApp.Save()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        isLoading = True
        Dim r As Recipe = theApp.Recipe_Get_By_ID(5) '2

        chkFavorite.Checked = theUser.IsAFavorite(r)
        If theUser.HasANote(r) Then
            bsNote.DataSource = theUser.Notes.SingleOrDefault(Function(f) f.RecipeID = r.RecipeID)
        End If

        bs.DataSource = r
        isLoading = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim r As Recipe = bs.DataSource
        ' r.AddIngredients(txtIngredients.Text)
        theApp.Recipe_Update(r)
        theApp.Save()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim r As Recipe = bs.DataSource
        If theApp.Recipe_Can_Delete(r) Then
            If MsgBox("Are you sure?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Delete Recipe") = MsgBoxResult.Yes Then
                theApp.Recipe_Delete(r)
                theApp.Save()
                bs.DataSource = New Recipe
            End If
        Else
            MsgBox("This recipe is a favorite or has a note from others. Can't be deleted.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Delete Recipe")
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub bs_BindingComplete(sender As Object, e As BindingCompleteEventArgs) Handles bs.BindingComplete
        Debug.WriteLine("bs_BindingComplete")
    End Sub

    Private Sub bs_CurrentChanged(sender As Object, e As EventArgs) Handles bs.CurrentChanged
        Debug.WriteLine("bs_CurrentChanged")
    End Sub

    Private Sub bs_CurrentItemChanged(sender As Object, e As EventArgs) Handles bs.CurrentItemChanged
        Debug.WriteLine("bs_CurrentItemChanged")
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim r As New Recipe
        r.Contributor = theUser
        r.CategoryID = cbCategory.SelectedValue
        r.ServingID = cbServing.SelectedValue

        bs.DataSource = r
        chkFavorite.Checked = theUser.IsAFavorite(r)
        If theUser.HasANote(r) Then
            bsNote.DataSource = theUser.Notes.SingleOrDefault(Function(f) f.RecipeID = r.RecipeID)
        Else
            bsNote.DataSource = New Note
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        bs.EndEdit()
        bsNote.EndEdit()
        Dim r As Recipe = bs.DataSource
        If r.RecipeID = 0 Then
            theApp.Recipe_Insert(r)
        Else
            theApp.Recipe_Update(r)
        End If
        theApp.Contributor_Update(theUser)
        theApp.Save()
        ResetControls()
        hasChanges = False
    End Sub

    Private Sub chkFavorite_CheckedChanged(sender As Object, e As EventArgs) Handles chkFavorite.CheckedChanged

    End Sub

    Private Sub chkFavorite_Click(sender As Object, e As EventArgs) Handles chkFavorite.Click
        Dim r As Recipe = bs.DataSource
        If r.RecipeID <> 0 Then
            If chkFavorite.Checked = True Then
                theUser.Favorites.Add(New Favorite With {.Recipe = r})
            Else
                Dim theFav As Favorite = theUser.Favorites.SingleOrDefault(Function(f) f.RecipeID = r.RecipeID)
                If Not theFav Is Nothing Then
                    theUser.Favorites.Remove(theFav)
                End If
            End If
            theApp.Contributor_Update(theUser)
            theApp.Save()
        End If
    End Sub

    Private Sub txtNotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNotes.KeyPress
        txtNotes.BackColor = Color.BlanchedAlmond
        hasChanges = True
        If bsNote.Count = 0 Then
            Dim theNote As New Note With {.Recipe = bs.DataSource}
            theUser.Notes.Add(theNote)
            bsNote.DataSource = theNote
        End If
    End Sub
    Private Sub aKeyPressEvent(sender As Object, e As KeyPressEventArgs)
        Dim theTB As TextBox = sender
        theTB.BackColor = Color.BlanchedAlmond
        hasChanges = True


        Debug.WriteLine("")
    End Sub

    Private Sub tmrWatch_Tick(sender As Object, e As EventArgs) Handles tmrWatch.Tick
        SaveToolStripMenuItem.Enabled = hasChanges
    End Sub
    Private Sub ResetControls()
        txtTitle.BackColor = System.Drawing.SystemColors.Window
        txtCookTime.BackColor = System.Drawing.SystemColors.Window
        txtPrepTime.BackColor = System.Drawing.SystemColors.Window
        txtIngredients.BackColor = System.Drawing.SystemColors.Window
        txtInstructions.BackColor = System.Drawing.SystemColors.Window
        txtNotes.BackColor = System.Drawing.SystemColors.Window
        txtURL.BackColor = System.Drawing.SystemColors.Window
        cbCategory.BackColor = System.Drawing.SystemColors.Window
        cbServing.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub aComboBoxIndexChanged(sender As Object, e As EventArgs)
        If Not isLoading Then
            hasChanges = True
            CType(sender, ComboBox).BackColor = Color.BlanchedAlmond
        End If

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

    End Sub

    Private Sub PrintToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem1.Click
        Using f As frmAdmin = New frmAdmin
            f.ShowDialog()
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using f As frmDisplay = New frmDisplay
            f.theRecipe = bs.DataSource
            f.ShowDialog()

        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim l = theApp.Recipe_Search("sesame oil")
    End Sub

    Private Sub cbRecipes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRecipes.SelectedIndexChanged
        If Not isStarting Then
            GetData(cbRecipes.SelectedValue)
        End If
    End Sub
    Private Sub GetData(rID As Integer)
        isLoading = True
        Dim r As Recipe = theApp.Recipe_Get_By_ID(rID)

        chkFavorite.Checked = theUser.IsAFavorite(r)
        If theUser.HasANote(r) Then
            bsNote.DataSource = theUser.Notes.SingleOrDefault(Function(f) f.RecipeID = r.RecipeID)
        Else
            bsNote.DataSource = New Note
        End If

        bs.DataSource = r
        isLoading = False

    End Sub
End Class