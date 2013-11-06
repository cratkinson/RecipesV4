Imports System.ComponentModel.DataAnnotations
Public Class Contributor
    Public Property ContributorID As Integer
    <StringLength(40)> _
    Public Property Name As String
    <EmailAddress> _
    Public Property EmailAddress As String

    Public Overridable Property Favorites As ICollection(Of Favorite) = New HashSet(Of Favorite)
    Public Overridable Property Notes As ICollection(Of Note) = New HashSet(Of Note)
    Public Overridable Property Ratings As ICollection(Of Rating) = New HashSet(Of Rating)

    Public ReadOnly Property IsAFavorite(aRecipe As Recipe) As Boolean
        Get
            Dim q = Me.Favorites.Where(Function(f) f.RecipeID = aRecipe.RecipeID).ToList
            Return q.Count > 0
        End Get
    End Property
End Class
