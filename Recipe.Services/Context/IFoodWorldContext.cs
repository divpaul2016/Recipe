using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Services.Models;

namespace Recipe.Services.Context
{
    public interface IFoodWorldContext
    {
       DbSet<CookingStyle> CookingStyles { get; set; }
       DbSet<Cuisine> Cuisines { get; set; }
       DbSet<DishType> DishTypes { get; set; }
       DbSet<FoodRecipe> FoodRecipes { get; set; }
       DbSet<Ingredient> Ingredients { get; set; }
       DbSet<MealType> MealTypes { get; set; }
       DbSet<RecipeCookingStyle> RecipeCookingStyle { get; set; }
       DbSet<RecipeCuisine> RecipeCuisine { get; set; }
       DbSet<RecipeDirection> RecipeDirection { get; set; }
       DbSet<RecipeDishType> RecipeDishType { get; set; }
       DbSet<RecipeIngredient> RecipeIngredient { get; set; }
       DbSet<RecipeMealType> RecipeMealType { get; set; }
    }
}
