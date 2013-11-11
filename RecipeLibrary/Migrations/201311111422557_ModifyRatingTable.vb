Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ModifyRatingTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropPrimaryKey("dbo.Ratings")
            AddPrimaryKey("dbo.Ratings", New String() { "RecipeID", "ContributorID" })
            DropColumn("dbo.Ratings", "RatingID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Ratings", "RatingID", Function(c) c.Int(nullable := False, identity := True))
            DropPrimaryKey("dbo.Ratings")
            AddPrimaryKey("dbo.Ratings", "RatingID")
        End Sub
    End Class
End Namespace
