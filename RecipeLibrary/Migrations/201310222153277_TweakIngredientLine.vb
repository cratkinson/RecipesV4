Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class TweakIngredientLine
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.IngredientLines", "IngredientLineID", Function(c) c.Int(nullable := False, identity := True))
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", "IngredientLineID")
        End Sub
        
        Public Overrides Sub Down()
            DropPrimaryKey("dbo.IngredientLines")
            AddPrimaryKey("dbo.IngredientLines", New String() { "IngredientLineID", "RecipeID" })
            AlterColumn("dbo.IngredientLines", "IngredientLineID", Function(c) c.Int(nullable := False))
        End Sub
    End Class
End Namespace
