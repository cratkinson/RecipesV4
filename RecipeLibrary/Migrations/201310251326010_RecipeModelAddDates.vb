Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class RecipeModelAddDates
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Recipes", "FirstAdded", Function(c) c.DateTime(nullable:=True))
            AddColumn("dbo.Recipes", "LastUpdated", Function(c) c.DateTime(nullable:=True))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Recipes", "LastUpdated")
            DropColumn("dbo.Recipes", "FirstAdded")
        End Sub
    End Class
End Namespace
