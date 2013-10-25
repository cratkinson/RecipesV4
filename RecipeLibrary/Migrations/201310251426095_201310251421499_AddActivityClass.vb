Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _201310251421499_AddActivityClass
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ActivityLogs",
                Function(c) New With
                    {
                        .ActivityLogID = c.Int(nullable := False, identity := True),
                        .Activity = c.Int(nullable := False),
                        .ActivityDate = c.DateTime(),
                        .ContributorID = c.Int(nullable := False),
                        .RecipeID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ActivityLogID) _
                .ForeignKey("dbo.Contributors", Function(t) t.ContributorID, cascadeDelete := True) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete := True) _
                .Index(Function(t) t.ContributorID) _
                .Index(Function(t) t.RecipeID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ActivityLogs", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.ActivityLogs", "ContributorID", "dbo.Contributors")
            DropIndex("dbo.ActivityLogs", New String() { "RecipeID" })
            DropIndex("dbo.ActivityLogs", New String() { "ContributorID" })
            DropTable("dbo.ActivityLogs")
        End Sub
    End Class
End Namespace
