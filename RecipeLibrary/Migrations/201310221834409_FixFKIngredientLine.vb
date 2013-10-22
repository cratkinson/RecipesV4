Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class FixFKIngredientLine
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.IngredientLines", "Recipe_RecipeID", "dbo.Recipes")
            DropIndex("dbo.IngredientLines", New String() { "Recipe_RecipeID" })
            RenameColumn(table := "dbo.IngredientLines", name := "Recipe_RecipeID", newName := "RecipeID")
            AlterColumn("dbo.IngredientLines", "RecipeID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.IngredientLines", "RecipeID")
            AddForeignKey("dbo.IngredientLines", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.IngredientLines", "RecipeID", "dbo.Recipes")
            DropIndex("dbo.IngredientLines", New String() { "RecipeID" })
            AlterColumn("dbo.IngredientLines", "RecipeID", Function(c) c.Int())
            RenameColumn(table := "dbo.IngredientLines", name := "RecipeID", newName := "Recipe_RecipeID")
            CreateIndex("dbo.IngredientLines", "Recipe_RecipeID")
            AddForeignKey("dbo.IngredientLines", "Recipe_RecipeID", "dbo.Recipes", "RecipeID")
        End Sub
    End Class
End Namespace
