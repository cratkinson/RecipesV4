Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateFavKey
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropPrimaryKey("dbo.Favorites")
            AddPrimaryKey("dbo.Favorites", New String() { "ContributorID", "RecipeID" })
            DropColumn("dbo.Favorites", "FavoriteID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Favorites", "FavoriteID", Function(c) c.Int(nullable := False, identity := True))
            DropPrimaryKey("dbo.Favorites")
            AddPrimaryKey("dbo.Favorites", "FavoriteID")
        End Sub
    End Class
End Namespace
