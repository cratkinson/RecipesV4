Imports RecipeLibrary

Public Class RecipeMain
    Inherits System.Web.UI.Page
    Private l As App = New App
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With listRecipes
            .DataSource = l.Recipe_Get_All_Titles
            .DataTextField = "Title"
            .DataValueField = "RecipeID"

        End With
    End Sub

End Class