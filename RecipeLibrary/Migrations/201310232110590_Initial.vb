Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Categories",
                Function(c) New With
                    {
                        .CategoryID = c.Int(nullable := False, identity := True),
                        .Description = c.String(maxLength := 40)
                    }) _
                .PrimaryKey(Function(t) t.CategoryID)
            
            CreateTable(
                "dbo.Contributors",
                Function(c) New With
                    {
                        .ContributorID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 40),
                        .EmailAddress = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ContributorID)
            
            CreateTable(
                "dbo.Favorites",
                Function(c) New With
                    {
                        .FavoriteID = c.Int(nullable := False, identity := True),
                        .ContributorID = c.Int(nullable := False),
                        .RecipeID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.FavoriteID) _
                .ForeignKey("dbo.Contributors", Function(t) t.ContributorID, cascadeDelete := True) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete := True) _
                .Index(Function(t) t.ContributorID) _
                .Index(Function(t) t.RecipeID)
            
            CreateTable(
                "dbo.Recipes",
                Function(c) New With
                    {
                        .RecipeID = c.Int(nullable:=False, identity:=True),
                        .Title = c.String(maxLength:=50),
                        .Instructions = c.String(),
                        .PrepareTime = c.Int(nullable:=False),
                        .CookTime = c.Int(nullable:=False),
                        .SourceURL = c.String(),
                        .CategoryID = c.Int(nullable:=False),
                        .ServingID = c.Int(nullable:=False),
                        .ContributorID = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.RecipeID) _
                .ForeignKey("dbo.Categories", Function(t) t.CategoryID, cascadeDelete:=False) _
                .ForeignKey("dbo.Contributors", Function(t) t.ContributorID, cascadeDelete:=False) _
                .ForeignKey("dbo.Servings", Function(t) t.ServingID, cascadeDelete:=False) _
                .Index(Function(t) t.CategoryID) _
                .Index(Function(t) t.ContributorID) _
                .Index(Function(t) t.ServingID)
            
            CreateTable(
                "dbo.IngredientLines",
                Function(c) New With
                    {
                        .IngredientLineID = c.Int(nullable:=False, identity:=True),
                        .Amount = c.Double(nullable:=False),
                        .Unit = c.String(maxLength:=40),
                        .Ingredient = c.String(),
                        .Instruction = c.String(),
                        .RecipeID = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) New With {t.IngredientLineID, t.RecipeID}) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete:=True) _
                .Index(Function(t) t.RecipeID)

            CreateTable(
                "dbo.Servings",
                Function(c) New With
                    {
                        .ServingID = c.Int(nullable:=False, identity:=True),
                        .Description = c.String(maxLength:=40),
                        .ScaleFactor = c.Decimal(nullable:=False, precision:=18, scale:=2)
                    }) _
                .PrimaryKey(Function(t) t.ServingID)

            CreateTable(
                "dbo.MyTests",
                Function(c) New With
                    {
                        .Col1ID = c.Int(nullable:=False),
                        .Col2ID = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) New With {t.Col1ID, t.Col2ID})

            CreateTable(
                "dbo.Ratings",
                Function(c) New With
                    {
                        .RatingID = c.Int(nullable:=False, identity:=True),
                        .RatingScore = c.Int(nullable:=False),
                        .RecipeID = c.Int(nullable:=False),
                        .ContributorID = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.RatingID) _
                .ForeignKey("dbo.Contributors", Function(t) t.ContributorID, cascadeDelete:=True) _
                .ForeignKey("dbo.Recipes", Function(t) t.RecipeID, cascadeDelete:=True) _
                .Index(Function(t) t.ContributorID) _
                .Index(Function(t) t.RecipeID)

            CreateTable(
                "dbo.Units",
                Function(c) New With
                    {
                        .UnitID = c.Int(nullable:=False, identity:=True),
                        .Description = c.String(maxLength:=40),
                        .ExpandedDescription = c.String(maxLength:=40)
                    }) _
                .PrimaryKey(Function(t) t.UnitID)

        End Sub

        Public Overrides Sub Down()
            DropForeignKey("dbo.Ratings", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Ratings", "ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Favorites", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Recipes", "ServingID", "dbo.Servings")
            DropForeignKey("dbo.IngredientLines", "RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Recipes", "ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories")
            DropForeignKey("dbo.Favorites", "ContributorID", "dbo.Contributors")
            DropIndex("dbo.Ratings", New String() {"RecipeID"})
            DropIndex("dbo.Ratings", New String() {"ContributorID"})
            DropIndex("dbo.Favorites", New String() {"RecipeID"})
            DropIndex("dbo.Recipes", New String() {"ServingID"})
            DropIndex("dbo.IngredientLines", New String() {"RecipeID"})
            DropIndex("dbo.Recipes", New String() {"ContributorID"})
            DropIndex("dbo.Recipes", New String() {"CategoryID"})
            DropIndex("dbo.Favorites", New String() {"ContributorID"})
            DropTable("dbo.Units")
            DropTable("dbo.Ratings")
            DropTable("dbo.MyTests")
            DropTable("dbo.Servings")
            DropTable("dbo.IngredientLines")
            DropTable("dbo.Recipes")
            DropTable("dbo.Favorites")
            DropTable("dbo.Contributors")
            DropTable("dbo.Categories")
        End Sub
    End Class
End Namespace
