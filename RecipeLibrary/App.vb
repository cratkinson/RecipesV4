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
    Function Recipe_Can_Delete(aRecipe As Recipe) As Boolean

    Function Favorite_Exists(ContributorID As Integer, RecipeID As Integer) As Boolean
    Sub Favorite_Insert(theContributor As Contributor, theRecipe As Recipe)
    Sub Favorite_Delete(theContributor As Contributor, theRecipe As Recipe)

    Function Note_Get(ContributorID As Integer, RecipeID As Integer) As Note
    Sub Note_Insert(aNote As Note)
    Sub Note_Update(aNote As Note)
    Sub Note_Delete(aNote As Note)

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
    '--------------------------------------------------------------------
    ' Categories
    '--------------------------------------------------------------------
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
    '--------------------------------------------------------------------
    ' Units
    '--------------------------------------------------------------------
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

    '--------------------------------------------------------------------
    ' Contributors
    '--------------------------------------------------------------------
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
    '--------------------------------------------------------------------
    ' RECIPES
    '--------------------------------------------------------------------
    Function Recipe_Get_By_ID(ID As Integer) As Recipe Implements iApp.Recipe_Get_By_ID
        Return _db.Recipes.SingleOrDefault(Function(f) f.RecipeID = ID)
    End Function
    Public Sub Recipe_Insert(aRecipe As Recipe) Implements iApp.Recipe_Insert
        aRecipe.FirstAdded = Date.Now
        aRecipe.LastUpdated = Date.Now
        _db.Recipes.Add(aRecipe)
        PostAnActivity(aRecipe, Activities.Insert)
    End Sub
    Sub Recipe_Update(aRecipe As Recipe) Implements iApp.Recipe_Update
        aRecipe.LastUpdated = Date.Now
        PostAnActivity(aRecipe, Activities.Update)
        _db.Entry(aRecipe).State = Entity.EntityState.Modified
    End Sub
    Sub Recipe_Delete(aRecipe As Recipe) Implements iApp.Recipe_Delete
        PostAnActivity(aRecipe, Activities.Delete)
        _db.Recipes.Remove(aRecipe)
    End Sub
    Function Recipe_Can_Delete(aRecipe As Recipe) As Boolean Implements iApp.Recipe_Can_Delete
        Dim isAFavorite As Boolean = _db.Favorites.Where(Function(f) f.RecipeID = aRecipe.RecipeID).ToList.Count > 0
        Dim hasANote As Boolean = _db.Notes.Where(Function(f) f.RecipeID = aRecipe.RecipeID).ToList.Count > 0
        Return Not isAFavorite And Not hasANote
    End Function
    '--------------------------------------------------------------------
    ' Servings
    '--------------------------------------------------------------------
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
    '--------------------------------------------------------------------
    ' Favorites
    '--------------------------------------------------------------------
    Function Favorite_Exists(ContributorID As Integer, RecipeID As Integer) As Boolean Implements iApp.Favorite_Exists
        Return Not _db.Favorites.SingleOrDefault(Function(f) f.ContributorID = ContributorID And f.RecipeID = RecipeID) Is Nothing
    End Function
    Sub Favorite_Insert(theContributor As Contributor, theRecipe As Recipe) Implements iApp.Favorite_Insert
        If _db.Favorites.SingleOrDefault(Function(f) f.ContributorID = theContributor.ContributorID And f.RecipeID = theRecipe.RecipeID) Is Nothing Then
            '_db.Favorites.Add(New Favorite With {.ContributorID = ContributorID, .RecipeID = RecipeID})
            _db.Favorites.Add(New Favorite With {.Contributor = theContributor, .Recipe = theRecipe})
        End If
    End Sub
    Sub Favorite_Delete(theContributor As Contributor, theRecipe As Recipe) Implements iApp.Favorite_Delete
        Dim fav As Favorite = _db.Favorites.SingleOrDefault(Function(f) f.ContributorID = theContributor.ContributorID And f.RecipeID = theRecipe.RecipeID)
        If Not fav Is Nothing Then
            _db.Favorites.Remove(fav)
        End If
    End Sub
    Function Note_Get(ContributorID As Integer, RecipeID As Integer) As Note Implements iApp.Note_Get
        Return _db.Notes.SingleOrDefault(Function(f) f.ContributorID = ContributorID And f.RecipeID = RecipeID)

    End Function
    Sub Note_Insert(aNote As Note) Implements iApp.Note_Insert
        _db.Notes.Add(aNote)
    End Sub
    Sub Note_Update(aNote As Note) Implements iApp.Note_Update
        _db.Entry(aNote).State = Entity.EntityState.Modified
    End Sub
    Sub Note_Delete(aNote As Note) Implements iApp.Note_Delete
        _db.Notes.Remove(aNote)
    End Sub

    '--------------------------------------------------------------------
    ' Private Subs & Functions
    '--------------------------------------------------------------------
    Private Sub PostAnActivity(aRecipe As Recipe, aActivity As Activities)
        Dim a As New ActivityLog
        With a
            .Activity = aActivity
            .ActivityDate = DateTime.Now
            .ContributorName = aRecipe.Contributor.Name
            .RecipeName = aRecipe.Title
        End With
        _db.ActivityLogs.Add(a)
    End Sub
End Class
