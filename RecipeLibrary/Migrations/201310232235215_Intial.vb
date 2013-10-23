Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Intial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", New String() { "IngredientLineID", "RecipeID" })
        End Sub
        
        Public Overrides Sub Down()
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", "IngredientLineID")
        End Sub
    End Class
End Namespace
