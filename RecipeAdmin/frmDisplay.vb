Imports RecipeLibrary

Public Class frmDisplay
    Public Property theRecipe As Recipe

    Private Sub frmDisplay_Load(sender As Object, e As EventArgs) Handles Me.Load
        wbDisplay.DocumentText = theRecipe.ToHTML

    End Sub
End Class