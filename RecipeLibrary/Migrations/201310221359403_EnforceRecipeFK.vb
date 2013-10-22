Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class EnforceRecipeFK
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Recipes", "Category_CategoryID", "dbo.Categories")
            DropForeignKey("dbo.Recipes", "Contributor_ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Recipes", "Serving_ServingID", "dbo.Servings")
            DropIndex("dbo.Recipes", New String() { "Category_CategoryID" })
            DropIndex("dbo.Recipes", New String() { "Contributor_ContributorID" })
            DropIndex("dbo.Recipes", New String() { "Serving_ServingID" })
            RenameColumn(table := "dbo.Recipes", name := "Category_CategoryID", newName := "CategoryID")
            RenameColumn(table := "dbo.Recipes", name := "Contributor_ContributorID", newName := "ContributorID")
            RenameColumn(table := "dbo.Recipes", name := "Serving_ServingID", newName := "ServingID")
            AlterColumn("dbo.Recipes", "CategoryID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Recipes", "ContributorID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Recipes", "ServingID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Recipes", "CategoryID")
            CreateIndex("dbo.Recipes", "ContributorID")
            CreateIndex("dbo.Recipes", "ServingID")
            AddForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete := True)
            AddForeignKey("dbo.Recipes", "ContributorID", "dbo.Contributors", "ContributorID", cascadeDelete := True)
            AddForeignKey("dbo.Recipes", "ServingID", "dbo.Servings", "ServingID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Recipes", "ServingID", "dbo.Servings")
            DropForeignKey("dbo.Recipes", "ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories")
            DropIndex("dbo.Recipes", New String() { "ServingID" })
            DropIndex("dbo.Recipes", New String() { "ContributorID" })
            DropIndex("dbo.Recipes", New String() { "CategoryID" })
            AlterColumn("dbo.Recipes", "ServingID", Function(c) c.Int())
            AlterColumn("dbo.Recipes", "ContributorID", Function(c) c.Int())
            AlterColumn("dbo.Recipes", "CategoryID", Function(c) c.Int())
            RenameColumn(table := "dbo.Recipes", name := "ServingID", newName := "Serving_ServingID")
            RenameColumn(table := "dbo.Recipes", name := "ContributorID", newName := "Contributor_ContributorID")
            RenameColumn(table := "dbo.Recipes", name := "CategoryID", newName := "Category_CategoryID")
            CreateIndex("dbo.Recipes", "Serving_ServingID")
            CreateIndex("dbo.Recipes", "Contributor_ContributorID")
            CreateIndex("dbo.Recipes", "Category_CategoryID")
            AddForeignKey("dbo.Recipes", "Serving_ServingID", "dbo.Servings", "ServingID")
            AddForeignKey("dbo.Recipes", "Contributor_ContributorID", "dbo.Contributors", "ContributorID")
            AddForeignKey("dbo.Recipes", "Category_CategoryID", "dbo.Categories", "CategoryID")
        End Sub
    End Class
End Namespace
