Imports System.ComponentModel.DataAnnotations

Public Class Favorite
    <Key, Schema.Column(order:=1)> _
    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor

    <Key, Schema.Column(Order:=2)> _
    Public Property RecipeID As Integer
    Public Overridable Property Recipe As Recipe
End Class
