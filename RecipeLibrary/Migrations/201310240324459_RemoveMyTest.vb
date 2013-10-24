Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class RemoveMyTest
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropTable("dbo.MyTests")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.MyTests",
                Function(c) New With
                    {
                        .Col1ID = c.Int(nullable := False),
                        .Col2ID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.Col1ID, t.Col2ID })
            
        End Sub
    End Class
End Namespace
