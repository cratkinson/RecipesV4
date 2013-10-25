Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ActivtiesTableModify
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.ActivityLogs", "ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.ActivityLogs", "RecipeID", "dbo.Recipes")
            DropIndex("dbo.ActivityLogs", New String() { "ContributorID" })
            DropIndex("dbo.ActivityLogs", New String() { "RecipeID" })
            AddColumn("dbo.ActivityLogs", "ContributorName", Function(c) c.String())
            AddColumn("dbo.ActivityLogs", "RecipeName", Function(c) c.String())
            DropColumn("dbo.ActivityLogs", "ContributorID")
            DropColumn("dbo.ActivityLogs", "RecipeID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.ActivityLogs", "RecipeID", Function(c) c.Int(nullable := False))
            AddColumn("dbo.ActivityLogs", "ContributorID", Function(c) c.Int(nullable := False))
            DropColumn("dbo.ActivityLogs", "RecipeName")
            DropColumn("dbo.ActivityLogs", "ContributorName")
            CreateIndex("dbo.ActivityLogs", "RecipeID")
            CreateIndex("dbo.ActivityLogs", "ContributorID")
            AddForeignKey("dbo.ActivityLogs", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete := True)
            AddForeignKey("dbo.ActivityLogs", "ContributorID", "dbo.Contributors", "ContributorID", cascadeDelete := True)
        End Sub
    End Class
End Namespace
