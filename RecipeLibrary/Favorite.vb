Imports System.ComponentModel.DataAnnotations

Public Class Favorite
    Public Property FavoriteID As Integer

    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor

    Public Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
End Class
