namespace Recipe.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CookingStyle",
                c => new
                    {
                        CookingStyleId = c.Int(nullable: false, identity: true),
                        CookingStyleName = c.String(),
                    })
                .PrimaryKey(t => t.CookingStyleId);
            
            CreateTable(
                "dbo.RecipeCookingStyle",
                c => new
                    {
                        RecipeCookingStyleId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        CookingStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeCookingStyleId, t.RecipeId, t.CookingStyleId })
                .ForeignKey("dbo.CookingStyle", t => t.CookingStyleId, cascadeDelete: true)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.CookingStyleId);
            
            CreateTable(
                "dbo.FoodRecipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        PrepTime = c.Int(nullable: false),
                        ReadyIn = c.Int(nullable: false),
                        CookingTime = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        MainIngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.RecipeCuisine",
                c => new
                    {
                        RecipeCuisineId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        CuisineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeCuisineId)
                .ForeignKey("dbo.Cuisine", t => t.CuisineId, cascadeDelete: true)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.CuisineId);
            
            CreateTable(
                "dbo.Cuisine",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        CuisineName = c.String(),
                    })
                .PrimaryKey(t => t.CuisineId);
            
            CreateTable(
                "dbo.RecipeDirection",
                c => new
                    {
                        RecipeDirectionId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        StepNo = c.Int(nullable: false),
                        Instructions = c.String(),
                    })
                .PrimaryKey(t => t.RecipeDirectionId)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.RecipeDishType",
                c => new
                    {
                        RecipeDishTypeId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        DishTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeDishTypeId)
                .ForeignKey("dbo.DishType", t => t.DishTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.DishTypeId);
            
            CreateTable(
                "dbo.DishType",
                c => new
                    {
                        DishTypeId = c.Int(nullable: false, identity: true),
                        DishTypeName = c.String(),
                    })
                .PrimaryKey(t => t.DishTypeId);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        RecipeIngredientId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Unit = c.String(),
                        Quantity = c.String(),
                    })
                .PrimaryKey(t => t.RecipeIngredientId)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.RecipeMealType",
                c => new
                    {
                        RecipeMealTypeId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        MealTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeMealTypeId)
                .ForeignKey("dbo.FoodRecipe", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.MealType", t => t.MealTypeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.MealTypeId);
            
            CreateTable(
                "dbo.MealType",
                c => new
                    {
                        MealTypeId = c.Int(nullable: false, identity: true),
                        MealTypeName = c.String(),
                    })
                .PrimaryKey(t => t.MealTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeMealType", "MealTypeId", "dbo.MealType");
            DropForeignKey("dbo.RecipeMealType", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeIngredient", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.RecipeIngredient", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeDishType", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeDishType", "DishTypeId", "dbo.DishType");
            DropForeignKey("dbo.RecipeDirection", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeCuisine", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeCuisine", "CuisineId", "dbo.Cuisine");
            DropForeignKey("dbo.RecipeCookingStyle", "RecipeId", "dbo.FoodRecipe");
            DropForeignKey("dbo.RecipeCookingStyle", "CookingStyleId", "dbo.CookingStyle");
            DropIndex("dbo.RecipeMealType", new[] { "MealTypeId" });
            DropIndex("dbo.RecipeMealType", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientId" });
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeId" });
            DropIndex("dbo.RecipeDishType", new[] { "DishTypeId" });
            DropIndex("dbo.RecipeDishType", new[] { "RecipeId" });
            DropIndex("dbo.RecipeDirection", new[] { "RecipeId" });
            DropIndex("dbo.RecipeCuisine", new[] { "CuisineId" });
            DropIndex("dbo.RecipeCuisine", new[] { "RecipeId" });
            DropIndex("dbo.RecipeCookingStyle", new[] { "CookingStyleId" });
            DropIndex("dbo.RecipeCookingStyle", new[] { "RecipeId" });
            DropTable("dbo.MealType");
            DropTable("dbo.RecipeMealType");
            DropTable("dbo.Ingredient");
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.DishType");
            DropTable("dbo.RecipeDishType");
            DropTable("dbo.RecipeDirection");
            DropTable("dbo.Cuisine");
            DropTable("dbo.RecipeCuisine");
            DropTable("dbo.FoodRecipe");
            DropTable("dbo.RecipeCookingStyle");
            DropTable("dbo.CookingStyle");
        }
    }
}
