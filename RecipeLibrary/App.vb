Public Interface iApp
    'Function GetRecipeByAll() As List(Of Recipe)
    'Function GetRecipeByID(ID As Integer) As Recipe
    'Function GetRecipeByCategory(CategoryID As Integer) As List(Of Recipe)
    'Function GetRecipeByContributor(ContributorID As Integer) As List(Of Recipe)

    Function Category_Get_All() As List(Of Category)
    Function Category_Get_By_ID(ID As Integer) As Category
    Sub Category_Insert(aCategory As Category)
    Sub Category_Update(aCategory As Category)
    Sub Category_Delete(aCategory As Category)

    Function Unit_Get_All() As List(Of Unit)
    Function Unit_Get_For_Parser() As List(Of String)
    Sub Unit_Insert(aUnit As Unit)
    Sub Unit_Update(aUnit As Unit)
    Sub Unit_Delete(aUnit As Unit)

    Function Contributor_Get_All() As List(Of Contributor)
    Function Contributor_Get_By_Email(email As String) As Contributor
    Sub Contributor_Insert(aContributor As Contributor)
    Sub Contributor_Update(aContributor As Contributor)
    Sub Contributor_Delete(aContributor As Contributor)

    Function Serving_Get_All() As List(Of Serving)
    Function Serving_Get_By_ID(ID As Integer) As Serving
    Sub Serving_Insert(aServing As Serving)
    Sub Serving_Update(aServing As Serving)
    Sub Serving_Delete(aServing As Serving)


    Function Recipe_Get_By_ID(ID As Integer) As Recipe
    Sub Recipe_Insert(aRecipe As Recipe)
    Sub Recipe_Update(aRecipe As Recipe)
    Sub Recipe_Delete(aRecipe As Recipe)

    Sub Save()


End Interface
Public Class App
    Implements iApp

    Private _db As RecipeDB = New RecipeDB
    Public Sub New()
    End Sub
    Public Sub Save() Implements iApp.Save
        Try
            _db.SaveChanges()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Category_Insert(aCategory As Category) Implements iApp.Category_Insert
        _db.Categories.Add(aCategory)
    End Sub

    Public Sub Category_Delete(aCategory As Category) Implements iApp.Category_Delete
        _db.Categories.Remove(aCategory)
    End Sub

    Public Function Category_Get_All() As List(Of Category) Implements iApp.Category_Get_All
        Return _db.Categories.ToList

    End Function

    Public Function Category_Get_By_ID(ID As Integer) As Category Implements iApp.Category_Get_By_ID
        Return _db.Categories.SingleOrDefault(Function(f) f.CategoryID = ID)

    End Function

    Public Sub Category_Update(aCategory As Category) Implements iApp.Category_Update
        _db.Entry(aCategory).State = Entity.EntityState.Modified
    End Sub

    Public Function Unit_Get_All() As List(Of Unit) Implements iApp.Unit_Get_All
        Return _db.Units.ToList

    End Function

    Public Function Unit_Get_For_Parser() As List(Of String) Implements iApp.Unit_Get_For_Parser
        Return _db.Units.Select(Function(f) f.Description).ToList()
    End Function
    Public Sub Unit_Insert(aUnit As Unit) Implements iApp.Unit_Insert
        _db.Units.Add(aUnit)
    End Sub
    Public Sub Unit_Update(aUnit As Unit) Implements iApp.Unit_Update
        _db.Entry(aUnit).State = Entity.EntityState.Modified
    End Sub
    Public Sub Unit_Delete(aUnit As Unit) Implements iApp.Unit_Delete
        _db.Units.Remove(aUnit)
    End Sub
    Public Sub Recipe_Insert(aRecipe As Recipe) Implements iApp.Recipe_Insert
        _db.Recipes.Add(aRecipe)
    End Sub

    Function Contributor_Get_All() As List(Of Contributor) Implements iApp.Contributor_Get_All
        Return _db.Contributors.ToList
    End Function
    Function Contributor_Get_By_Email(email As String) As Contributor Implements iApp.Contributor_Get_By_Email
        Return _db.Contributors.SingleOrDefault(Function(f) f.EmailAddress = email)
    End Function
    Sub Contributor_Insert(aContributor As Contributor) Implements iApp.Contributor_Insert
        _db.Contributors.Add(aContributor)
    End Sub
    Sub Contributor_Update(aContributor As Contributor) Implements iApp.Contributor_Update
        _db.Entry(aContributor).State = Entity.EntityState.Modified
    End Sub
    Sub Contributor_Delete(aContributor As Contributor) Implements iApp.Contributor_Delete
        _db.Contributors.Remove(aContributor)
    End Sub
    Function Recipe_Get_By_ID(ID As Integer) As Recipe Implements iApp.Recipe_Get_By_ID
        Return _db.Recipes.SingleOrDefault(Function(f) f.RecipeID = ID)
    End Function
    Sub Recipe_Update(aRecipe As Recipe) Implements iApp.Recipe_Update
        _db.Entry(aRecipe).State = Entity.EntityState.Modified
    End Sub
    Sub Recipe_Delete(aRecipe As Recipe) Implements iApp.Recipe_Delete
        _db.Recipes.Remove(aRecipe)
    End Sub

    Function Serving_Get_All() As List(Of Serving) Implements iApp.Serving_Get_All
        Return _db.Servings.ToList
    End Function
    Function Serving_Get_By_ID(ID As Integer) As Serving Implements iApp.Serving_Get_By_ID
        Return _db.Servings.SingleOrDefault(Function(f) f.ServingID = ID)
    End Function

    Sub Serving_Insert(aServing As Serving) Implements iApp.Serving_Insert
        _db.Servings.Add(aServing)
    End Sub
    Sub Serving_Update(aServing As Serving) Implements iApp.Serving_Update
        _db.Entry(aServing).State = Entity.EntityState.Modified
    End Sub
    Sub Serving_Delete(aServing As Serving) Implements iApp.Serving_Delete
        _db.Servings.Remove(aServing)
    End Sub

End Class
