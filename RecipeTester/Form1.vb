Imports RecipeLibrary
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim theApp As RecipeLibrary.App = New RecipeLibrary.App
        Dim r As New Recipe

        theApp.Save()

    End Sub
End Class
