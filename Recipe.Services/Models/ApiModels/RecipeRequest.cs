using System.Collections.Generic;


namespace Recipe.Services.Models.ApiModels
{
    public class RecipeRequest
    {
        public string FoodName { get; set; }
        public int PrepTime { get; set; }
        public int ReadyIn { get; set; }
        public int CookingTime { get; set; }
        public string MainIngredient { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
        public List<string> MealType { get; set; }
        public List<string> DishType { get; set; }
        public List<string> CookingStyle { get; set; }
        public List<Cuisine> Cuisine { get; set; }
        public string CreatedBy { get; set; }
    }
}