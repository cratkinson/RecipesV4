Imports System.ComponentModel.DataAnnotations
Public Class Rating
    Public Property RatingID As Integer
    Public Property RatingScore As Integer

    Public Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe

    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor
End Class
