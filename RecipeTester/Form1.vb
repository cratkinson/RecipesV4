Imports RecipeLibrary
Imports RecipeLibrary.App

Public Class Form1
    Private theApp As App = New App

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim theApp As RecipeLibrary.App = New RecipeLibrary.App
        Dim r As New Recipe
        With r
            .Title = "My First Recipe"
            .Category = theApp.Category_Get_ByID(1)
            .Contributor = theApp.Contributor_Get_By_Email("chip@atkinsons.com")
            .Instructions = "Chop carrot and add to broth."
            .AddIngredients("1/2 c carrots, chopped" + vbCrLf + "1 c broth")
        End With
        theApp.Recipe_Insert(r)

        'theApp.Category_Insert(New Category With {.Description = "Soups"})
        'theApp.Category_Insert(New Category With {.Description = "Desserts"})
        'theApp.Unit_Insert(New Unit With {.Description = "tbl", .ExpandedDescription = "tablespoon"})
        'theApp.Unit_Insert(New Unit With {.Description = "cup"})
        'theApp.Contributor_Insert(New Contributor With {.Name = "Chip Atkinson", .EmailAddress = "chip@atkinsons.com"})

        theApp.Save()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
