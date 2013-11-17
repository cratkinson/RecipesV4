Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class RecipeDB
    Inherits DbContext

    Public Property Categories As DbSet(Of Category)
    Public Property Servings As DbSet(Of Serving)
    Public Property Recipes As DbSet(Of Recipe)
    Public Property Contributors As DbSet(Of Contributor)
    Public Property Favorites As DbSet(Of Favorite)
    Public Property Ratings As DbSet(Of Rating)
    Public Property Ingredients As DbSet(Of IngredientLine)
    Public Property Units As DbSet(Of Unit)
    Public Property ActivityLogs As DbSet(Of ActivityLog)
    Public Property Notes As DbSet(Of Note)
    Public Property RecipeImages As DbSet(Of RecipeImage)


    Public Sub New()
        MyBase.New("RecipeDB")
    End Sub
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class
