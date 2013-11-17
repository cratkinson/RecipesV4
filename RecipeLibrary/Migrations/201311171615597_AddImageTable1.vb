Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddImageTable1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.RecipeImages", "PhotoAdded", Function(c) c.DateTime())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.RecipeImages", "PhotoAdded")
        End Sub
    End Class
End Namespace
