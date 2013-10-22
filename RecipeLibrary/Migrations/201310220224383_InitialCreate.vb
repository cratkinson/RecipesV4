Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
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
                        .Contributor_ContributorID = c.Int(),
                        .Recipe_RecipeID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.FavoriteID) _
                .ForeignKey("dbo.Contributors", Function(t) t.Contributor_ContributorID) _
                .ForeignKey("dbo.Recipes", Function(t) t.Recipe_RecipeID) _
                .Index(Function(t) t.Contributor_ContributorID) _
                .Index(Function(t) t.Recipe_RecipeID)
            
            CreateTable(
                "dbo.Recipes",
                Function(c) New With
                    {
                        .RecipeID = c.Int(nullable := False, identity := True),
                        .Title = c.String(maxLength := 50),
                        .Instructions = c.String(),
                        .PrepareTime = c.Int(nullable := False),
                        .CookTime = c.Int(nullable := False),
                        .SourceURL = c.String(),
                        .Category_CategoryID = c.Int(),
                        .Contributor_ContributorID = c.Int(),
                        .Serving_ServingID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.RecipeID) _
                .ForeignKey("dbo.Categories", Function(t) t.Category_CategoryID) _
                .ForeignKey("dbo.Contributors", Function(t) t.Contributor_ContributorID) _
                .ForeignKey("dbo.Servings", Function(t) t.Serving_ServingID) _
                .Index(Function(t) t.Category_CategoryID) _
                .Index(Function(t) t.Contributor_ContributorID) _
                .Index(Function(t) t.Serving_ServingID)
            
            CreateTable(
                "dbo.IngredientLines",
                Function(c) New With
                    {
                        .IngredientLineID = c.Int(nullable:=False, identity:=True),
                        .Amount = c.Decimal(nullable:=False, precision:=18, scale:=2),
                        .Unit = c.String(maxLength:=40),
                        .Ingredient = c.String(),
                        .Instruction = c.String(),
                        .Recipe_RecipeID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.IngredientLineID) _
                .ForeignKey("dbo.Recipes", Function(t) t.Recipe_RecipeID, True) _
                .Index(Function(t) t.Recipe_RecipeID)
            
            CreateTable(
                "dbo.Servings",
                Function(c) New With
                    {
                        .ServingID = c.Int(nullable := False, identity := True),
                        .Description = c.String(maxLength := 40),
                        .ScaleFactor = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.ServingID)
            
            CreateTable(
                "dbo.Ratings",
                Function(c) New With
                    {
                        .RatingID = c.Int(nullable := False, identity := True),
                        .RatingScore = c.Int(nullable := False),
                        .Contributor_ContributorID = c.Int(),
                        .Recipe_RecipeID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.RatingID) _
                .ForeignKey("dbo.Contributors", Function(t) t.Contributor_ContributorID) _
                .ForeignKey("dbo.Recipes", Function(t) t.Recipe_RecipeID) _
                .Index(Function(t) t.Contributor_ContributorID) _
                .Index(Function(t) t.Recipe_RecipeID)
            
            CreateTable(
                "dbo.Units",
                Function(c) New With
                    {
                        .UnitID = c.Int(nullable := False, identity := True),
                        .Description = c.String(maxLength := 40),
                        .ExpandedDescription = c.String(maxLength := 40)
                    }) _
                .PrimaryKey(Function(t) t.UnitID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Ratings", "Recipe_RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Ratings", "Contributor_ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Favorites", "Recipe_RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Recipes", "Serving_ServingID", "dbo.Servings")
            DropForeignKey("dbo.IngredientLines", "Recipe_RecipeID", "dbo.Recipes")
            DropForeignKey("dbo.Recipes", "Contributor_ContributorID", "dbo.Contributors")
            DropForeignKey("dbo.Recipes", "Category_CategoryID", "dbo.Categories")
            DropForeignKey("dbo.Favorites", "Contributor_ContributorID", "dbo.Contributors")
            DropIndex("dbo.Ratings", New String() { "Recipe_RecipeID" })
            DropIndex("dbo.Ratings", New String() { "Contributor_ContributorID" })
            DropIndex("dbo.Favorites", New String() { "Recipe_RecipeID" })
            DropIndex("dbo.Recipes", New String() { "Serving_ServingID" })
            DropIndex("dbo.IngredientLines", New String() { "Recipe_RecipeID" })
            DropIndex("dbo.Recipes", New String() { "Contributor_ContributorID" })
            DropIndex("dbo.Recipes", New String() { "Category_CategoryID" })
            DropIndex("dbo.Favorites", New String() { "Contributor_ContributorID" })
            DropTable("dbo.Units")
            DropTable("dbo.Ratings")
            DropTable("dbo.Servings")
            DropTable("dbo.IngredientLines")
            DropTable("dbo.Recipes")
            DropTable("dbo.Favorites")
            DropTable("dbo.Contributors")
            DropTable("dbo.Categories")
        End Sub
    End Class
End Namespace
