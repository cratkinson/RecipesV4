Imports System.ComponentModel.DataAnnotations
Public Class Rating
    <Key, Schema.Column(order:=1)> _
    Public Property RecipeID As Integer
    <Key, Schema.Column(Order:=2)> _
    Public Property ContributorID As Integer
    Public Property RatingScore As Integer

    Public Overridable Property Recipe As Recipe
    Public Overridable Property Contributor As Contributor
End Class
