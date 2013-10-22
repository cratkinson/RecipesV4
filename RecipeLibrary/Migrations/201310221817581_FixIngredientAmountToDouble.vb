Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class FixIngredientAmountToDouble
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.IngredientLines", "Amount", Function(c) c.Double(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.IngredientLines", "Amount", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
        End Sub
    End Class
End Namespace
