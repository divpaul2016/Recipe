using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;

namespace Recipe.Services
{
    public interface IRecipeService
    {
        int CreateRecipe(RecipeRequest recipe);
        FoodRecipe GetFoodRecipe(int recipeId);
    }
}