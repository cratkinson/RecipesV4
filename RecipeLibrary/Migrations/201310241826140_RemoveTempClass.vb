Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class RemoveTempClass
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropTable("dbo.Temps")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.Temps",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
    End Class
End Namespace
