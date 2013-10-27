Imports RecipeLibrary
Public Class frmMain
    Private theApp As App = New App

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

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim r As New Recipe
        With r
            .AddIngredients(txtIngredients.Text)
            .Title = txtTitle.Text
            .PrepareTime = IIf(txtPrepTime.Text = String.Empty, "0", txtPrepTime.Text)
            .CookTime = IIf(txtCookTime.Text = String.Empty, "0", txtCookTime.Text)
            .ContributorID = cbContributors.SelectedValue
            .CategoryID = cbCategory.SelectedValue
            .ServingID = cbServing.SelectedValue
            .Instructions = txtInstructions.Text

        End With
        theApp.Recipe_Insert(r)
        theApp.Save()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As Recipe = theApp.Recipe_Get_By_ID(6)
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
End Class