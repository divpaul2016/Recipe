using Recipe.Services.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Recipe.Services.Context
{
    public class FoodWorldContext :DbContext
    {
        public FoodWorldContext() : base("name=FoodWorld")
        {
            Database.SetInitializer<FoodWorldContext>(null);
        }

        public virtual DbSet<CookingStyle> CookingStyles { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<DishType> DishTypes { get; set; }
        public virtual DbSet<FoodRecipe> FoodRecipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<RecipeCookingStyle> RecipeCookingStyle { get; set; }
        public virtual DbSet<RecipeCuisine> RecipeCuisine { get; set; }
        public virtual DbSet<RecipeDirection> RecipeDirection { get; set; }
        public virtual DbSet<RecipeDishType> RecipeDishType { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual DbSet<RecipeMealType> RecipeMealType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<FoodRecipe>()
                .HasKey(c => new { c.RecipeId });

            //modelBuilder.Entity<Cuisine>()
            //    .HasKey(c => new { c.CuisineId });

            //modelBuilder.Entity<MealType>()
            //    .HasKey(c => new { c.MealTypeId });

            //modelBuilder.Entity<DishType>()
            //    .HasKey(c => new { c.DishTypeId });

            //modelBuilder.Entity<CookingStyle>()
            //    .HasKey(c => new { c.CookingStyleId });

            modelBuilder.Entity<Ingredient>()
                .HasKey(c => new {c.IngredientId});
                
            //modelBuilder.Entity<RecipeCuisine>()
            //    .HasKey(c => new { c.RecipeCuisineId });


            //modelBuilder.Entity<RecipeDirection>()
            //    .HasKey(c => new { c.RecipeDirectionId });

            //modelBuilder.Entity<RecipeCookingStyle>()
            //    .HasKey(c => new { c.RecipeCookingStyleId });

            //modelBuilder.Entity<RecipeDishType>()
            //    .HasKey(c => new { c.RecipeDishTypeId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(c => new { c.RecipeIngredientId });

            //modelBuilder.Entity<RecipeMealType>()
            //    .HasKey(c => new { c.RecipeMealTypeId });



            //modelBuilder.Entity<RecipeCookingStyle>()
            //    .HasRequired(t => t.FoodRecipe)
            //    .WithMany(t => t.RecipeCookingStyles)
            //    .HasForeignKey(t => t.RecipeId);

            //modelBuilder.Entity<RecipeCookingStyle>()
            //    .HasRequired(t => t.CookingStyle)
            //    .WithMany(t => t.RecipeCookingStyles)
            //    .HasForeignKey(t => t.CookingStyleId);

            //modelBuilder.Entity<RecipeCuisine>()
            //    .HasRequired(t => t.FoodRecipe)
            //    .WithMany(t => t.RecipeCuisines)
            //    .HasForeignKey(t => t.RecipeId);

            //modelBuilder.Entity<RecipeCuisine>()
            //    .HasRequired(t => t.Cuisine)
            //    .WithMany(t => t.RecipeCuisines)
            //    .HasForeignKey(t => t.CuisineId);


            //modelBuilder.Entity<RecipeDirection>()
            //    .HasRequired(t => t.FoodRecipe)
            //    .WithMany(t => t.RecipeDirections)
            //    .HasForeignKey(t => t.RecipeId);

            //modelBuilder.Entity<RecipeDishType>()
            //    .HasRequired(t => t.FoodRecipe)
            //    .WithMany(t => t.RecipeDishTypes)
            //    .HasForeignKey(t => t.RecipeId);

            //modelBuilder.Entity<RecipeDishType>()
            //    .HasRequired(t => t.DishType)
            //    .WithMany(t => t.RecipeDishTypes)
            //    .HasForeignKey(t => t.DishTypeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasRequired(t => t.FoodRecipe)
                .WithMany(t => t.RecipeIngredients)
                .HasForeignKey(t => t.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasRequired(i => i.Ingredient);


            //modelBuilder.Entity<RecipeMealType>()
            //    .HasRequired(t => t.FoodRecipe)
            //    .WithMany(t => t.RecipeMealTypes)
            //    .HasForeignKey(t => t.RecipeId);


            //modelBuilder.Entity<RecipeMealType>()
            //    .HasRequired(t => t.MealType)
            //    .WithMany(t => t.RecipeMealTypes)
            //    .HasForeignKey(t => t.MealTypeId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
