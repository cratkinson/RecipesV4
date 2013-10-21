Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Public Class Recipe
    Public Property RecipeID As Integer
    <StringLength(50)> _
    Public Property Title As String
    Public Property Instructions As String
    Public Property PrepareTime As Integer
    Public Property CookTime As Integer
    Public Property SourceURL As String

    Public Overridable Property Category As Category
    Public Overridable Property Serving As Serving
    Public Overridable Property Contributor As Contributor

    Public Overridable Property Ingredients As ICollection(Of IngredientLine) = New HashSet(Of IngredientLine)

End Class
