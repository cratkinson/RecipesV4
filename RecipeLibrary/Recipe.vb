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

    Public Property CategoryID As Integer
    Public Overridable Property Category As Category

    Public Property ServingID As Integer
    Public Overridable Property Serving As Serving

    Public Property ContributorID As Integer
    Public Overridable Property Contributor As Contributor

    Public Overridable Property Ingredients As ICollection(Of IngredientLine) = New HashSet(Of IngredientLine)
    Public Sub AddIngredients(aBlock As String)
        Dim p As IngredientParser = New IngredientParser
        Me.Ingredients = p.ParseBlock(aBlock)
    End Sub
    Public Function IngredientsAsString() As String
        Dim theString As String = String.Empty
        For Each i In Me.Ingredients
            theString += i.ToString + vbCrLf
        Next
        Return theString.Substring(0, theString.Length - 2)
    End Function
End Class
