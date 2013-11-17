Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddImageTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.RecipeImages",
                Function(c) New With
                    {
                        .ImageID = c.Int(nullable := False, identity := True),
                        .RecipeID = c.Int(nullable := False),
                        .Image = c.Binary()
                    }) _
                .PrimaryKey(Function(t) New With { t.ImageID, t.RecipeID }) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete := True) _
                .Index(Function(t) t.RecipeID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RecipeImages", "RecipeID", "dbo.Recipes")
            DropIndex("dbo.RecipeImages", New String() { "RecipeID" })
            DropTable("dbo.RecipeImages")
        End Sub
    End Class
End Namespace
