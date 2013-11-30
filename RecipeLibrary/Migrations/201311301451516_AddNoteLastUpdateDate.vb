Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddNoteLastUpdateDate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Notes", "LastUpdate", Function(c) c.DateTime())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Notes", "LastUpdate")
        End Sub
    End Class
End Namespace
