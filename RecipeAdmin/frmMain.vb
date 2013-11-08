﻿Imports RecipeLibrary
Public Class frmMain
    Private theApp As App = New App
    Private theUser As Contributor = theApp.Contributor_Get_By_Email("chip@atkinsons.com")

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        Dim b As New Binding("Text", bs, "Contributor.Name")
        txtContributor.DataBindings.Add(b)


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
        Dim r As Recipe = theApp.Recipe_Get_By_ID(5)

        chkFavorite.Checked = theUser.IsAFavorite(r)
        If theUser.HasANote(r) Then
            bsNote.DataSource = theUser.Notes.SingleOrDefault(Function(f) f.RecipeID = r.RecipeID)
        Else
            Debug.WriteLine("")
        End If

        bs.DataSource = r

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim r As Recipe = bs.DataSource
        ' r.AddIngredients(txtIngredients.Text)
        theApp.Recipe_Update(r)
        theApp.Save()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Delete Recipe") = MsgBoxResult.Yes Then
            Dim r As Recipe = bs.DataSource
            theApp.Recipe_Delete(r)
            theApp.Save()
            bs.DataSource = Nothing
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

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        bs.EndEdit()
        Dim r As Recipe = bs.DataSource
        If r.RecipeID = 0 Then
            theApp.Recipe_Insert(r)
        Else
            theApp.Recipe_Update(r)
        End If
        theApp.Save()

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
End Class