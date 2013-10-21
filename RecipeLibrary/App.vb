﻿Public Interface iApp
    'Function GetRecipeByAll() As List(Of Recipe)
    'Function GetRecipeByID(ID As Integer) As Recipe
    'Function GetRecipeByCategory(CategoryID As Integer) As List(Of Recipe)
    'Function GetRecipeByContributor(ContributorID As Integer) As List(Of Recipe)

    Function Category_Get_All() As List(Of Category)
    Function Category_Get_ByID(ID As Integer) As Category
    Sub Category_Insert(aCategory As Category)
    Sub Category_Update(aCategory As Category)
    Sub Category_Delete(aCategory As Category)

    Function Unit_Get_All() As List(Of Unit)
    Function Unit_Get_For_Parser() As List(Of String)
    Sub Unit_Insert(aUnit As Unit)
    Sub Unit_Update(aUnit As Unit)
    Sub Unit_Delete(aUnit As Unit)

    Sub Recipe_Insert(aRecipe As Recipe)

    Sub Save()


End Interface
Public Class App
    Implements iApp

    Private _db As RecipeDB = New RecipeDB

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
        Return _db.Categories.ToList()

    End Function

    Public Function Category_Get_ByID(ID As Integer) As Category Implements iApp.Category_Get_ByID
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

    End Sub
End Class