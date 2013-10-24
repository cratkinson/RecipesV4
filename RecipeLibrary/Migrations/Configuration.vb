Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of RecipeDB)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As RecipeDB)
            context.Categories.AddOrUpdate( _
                Function(f) f.Description, _
                New Category With {.Description = "Soup"},
                New Category With {.Description = "Dessert"})

            context.Units.AddOrUpdate( _
                Function(f) f.Description, _
                New Unit With {.Description = "cup"},
                New Unit With {.Description = "tbl", .ExpandedDescription = "tablespoon"}
                )

            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})
        End Sub

    End Class

End Namespace
