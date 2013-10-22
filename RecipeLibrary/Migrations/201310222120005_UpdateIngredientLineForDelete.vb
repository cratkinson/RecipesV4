Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateIngredientLineForDelete
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.IngredientLines", "IngredientLineID", Function(c) c.Int(nullable := False))
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", New String() { "IngredientLineID", "RecipeID" })
        End Sub
        
        Public Overrides Sub Down()
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", "IngredientLineID")
            AlterColumn("dbo.IngredientLines", "IngredientLineID", Function(c) c.Int(nullable := False, identity := True))
        End Sub
    End Class
End Namespace
