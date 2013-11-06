Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddNotes
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Notes",
                Function(c) New With
                    {
                        .ContributorID = c.Int(nullable := False),
                        .RecipeID = c.Int(nullable := False),
                        .Notes = c.String()
                    }) _
                .PrimaryKey(Function(t) New With { t.ContributorID, t.RecipeID }) _
                .ForeignKey("dbo.Contributors", Function(t) t.ContributorID, cascadeDelete := True) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete := True) _
                .Index(Function(t) t.ContributorID) _
                .Index(Function(t) t.RecipeID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Notes", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Notes", "ContributorID", "dbo.Contributors")
            DropIndex("dbo.Notes", New String() { "RecipeID" })
            DropIndex("dbo.Notes", New String() { "ContributorID" })
            DropTable("dbo.Notes")
        End Sub
    End Class
End Namespace
