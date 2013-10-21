Imports RecipeLibrary
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim theApp As RecipeLibrary.App = New RecipeLibrary.App
        With theApp
            .Unit_Insert(New Unit With {.Description = "tbl", .ExpandedDescription = "tablespoon"})
            .Unit_Insert(New Unit With {.Description = "cup", .ExpandedDescription = ""})
            .Unit_Insert(New Unit With {.Description = "c", .ExpandedDescription = "cup"})
        End With
        theApp.Save()

    End Sub
End Class
