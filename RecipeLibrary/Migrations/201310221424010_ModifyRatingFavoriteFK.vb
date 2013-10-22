Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ModifyRatingFavoriteFK
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Favorites", "Contributor_ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Favorites", "Recipe_RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Ratings", "Contributor_ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Ratings", "Recipe_RecipeID", "dbo.Recipes")
            DropIndex("dbo.Favorites", New String() { "Contributor_ContributorID" })
            DropIndex("dbo.Favorites", New String() { "Recipe_RecipeID" })
            DropIndex("dbo.Ratings", New String() { "Contributor_ContributorID" })
            DropIndex("dbo.Ratings", New String() { "Recipe_RecipeID" })
            RenameColumn(table := "dbo.Favorites", name := "Contributor_ContributorID", newName := "ContributorID")
            RenameColumn(table := "dbo.Favorites", name := "Recipe_RecipeID", newName := "RecipeID")
            RenameColumn(table := "dbo.Ratings", name := "Contributor_ContributorID", newName := "ContributorID")
            RenameColumn(table := "dbo.Ratings", name := "Recipe_RecipeID", newName := "RecipeID")
            AlterColumn("dbo.Favorites", "ContributorID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Favorites", "RecipeID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Ratings", "ContributorID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Ratings", "RecipeID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Favorites", "ContributorID")
            CreateIndex("dbo.Favorites", "RecipeID")
            CreateIndex("dbo.Ratings", "ContributorID")
            CreateIndex("dbo.Ratings", "RecipeID")
            AddForeignKey("dbo.Favorites", "ContributorID", "dbo.Contributors", "ContributorID", cascadeDelete:=False)
            AddForeignKey("dbo.Favorites", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete:=False)
            AddForeignKey("dbo.Ratings", "ContributorID", "dbo.Contributors", "ContributorID", cascadeDelete:=False)
            AddForeignKey("dbo.Ratings", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete:=False)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Ratings", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Ratings", "ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Favorites", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Favorites", "ContributorID", "dbo.Contributors")
            DropIndex("dbo.Ratings", New String() { "RecipeID" })
            DropIndex("dbo.Ratings", New String() { "ContributorID" })
            DropIndex("dbo.Favorites", New String() { "RecipeID" })
            DropIndex("dbo.Favorites", New String() { "ContributorID" })
            AlterColumn("dbo.Ratings", "RecipeID", Function(c) c.Int())
            AlterColumn("dbo.Ratings", "ContributorID", Function(c) c.Int())
            AlterColumn("dbo.Favorites", "RecipeID", Function(c) c.Int())
            AlterColumn("dbo.Favorites", "ContributorID", Function(c) c.Int())
            RenameColumn(table := "dbo.Ratings", name := "RecipeID", newName := "Recipe_RecipeID")
            RenameColumn(table := "dbo.Ratings", name := "ContributorID", newName := "Contributor_ContributorID")
            RenameColumn(table := "dbo.Favorites", name := "RecipeID", newName := "Recipe_RecipeID")
            RenameColumn(table := "dbo.Favorites", name := "ContributorID", newName := "Contributor_ContributorID")
            CreateIndex("dbo.Ratings", "Recipe_RecipeID")
            CreateIndex("dbo.Ratings", "Contributor_ContributorID")
            CreateIndex("dbo.Favorites", "Recipe_RecipeID")
            CreateIndex("dbo.Favorites", "Contributor_ContributorID")
            AddForeignKey("dbo.Ratings", "Recipe_RecipeID", "dbo.Recipes", "RecipeID")
            AddForeignKey("dbo.Ratings", "Contributor_ContributorID", "dbo.Contributors", "ContributorID")
            AddForeignKey("dbo.Favorites", "Recipe_RecipeID", "dbo.Recipes", "RecipeID")
            AddForeignKey("dbo.Favorites", "Contributor_ContributorID", "dbo.Contributors", "ContributorID")
        End Sub
    End Class
End Namespace
