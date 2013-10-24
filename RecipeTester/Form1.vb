Imports RecipeLibrary
Imports RecipeLibrary.App

Public Class Form1
    Private theApp As App = New App
    Private theRecipe As Recipe

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim r As New Recipe
        With r
            .Title = "My First Recipe"
            .Category = theApp.Category_Get_By_ID(1)
            .Serving = theApp.Serving_Get_By_ID(1)
            .Contributor = theApp.Contributor_Get_By_Email("chip@atkinsons.com")
            .Instructions = "Chop carrot and add to broth."
            .AddIngredients(TextBox1.Text)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With theApp
            .Category_Insert(New Category With {.Description = "Soups"})
            .Category_Insert(New Category With {.Description = "Desserts"})
            .Unit_Insert(New Unit With {.Description = "tbl", .ExpandedDescription = "tablespoon"})
            .Unit_Insert(New Unit With {.Description = "cup"})
            .Serving_Insert(New Serving With {.Description = "1", .ScaleFactor = 1})
            .Contributor_Insert(New Contributor With {.Name = "Chip Atkinson", .EmailAddress = "chip@atkinsons.com"})
            .Save()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim theR As Recipe = theApp.Recipe_Get_By_ID(2)
        theApp.Recipe_Delete(theR)
        theApp.Save()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        theRecipe = theApp.Recipe_Get_By_ID(2)
        TextBox2.Text = theRecipe.IngredientsAsString

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        theRecipe.AddIngredients(TextBox2.Text)
        theApp.Recipe_Update(theRecipe)
        theApp.Save()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Using db As RecipeDB = New RecipeDB
            Dim r As Recipe = db.Recipes.First()
            Dim i As IngredientLine = r.Ingredients.First()
            r.Ingredients.Remove(i)
            db.SaveChanges()


        End Using
    End Sub
End Class
