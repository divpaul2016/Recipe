using System.Collections.Generic;
using System.Linq;
using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using Ingredient = Recipe.Services.Models.Ingredient;

namespace Recipe.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly FoodWorldContext _recipeContext;

        public RecipeService(FoodWorldContext context)
        {
            _recipeContext = context;
        }

        public int CreateRecipe(RecipeRequest recipeRequest)
        {
            return AddFoodRecipe(recipeRequest);
        }

        public FoodRecipe GetFoodRecipe(int recipeId)
        {
            return new FoodRecipe();
            //_recipeContext.FoodRecipes.FirstOrDefault(m => m.RecipeId == recipeId);
            /*SELECT * 
FROM FoodRecipes 
JOIN RecipeCookingStyle on FoodRecipes.RecipeId = RecipeCookingStyle .RecipeId
JOIN CookingStyles ON RecipeCookingStyle.CookingStyleId = CookingStyles.CookingStyleId
JOIN RecipeCuisine on FoodRecipes.RecipeId = RecipeCuisine.RecipeId
JOIN Cuisines ON RecipeCuisine.CuisineId = Cuisines.CuisineId
JOIN RecipeDirection ON FoodRecipes.RecipeId = RecipeDirection.RecipeId
JOIN RecipeDishType ON FoodRecipes.RecipeId = RecipeDishType.RecipeId
JOIN DishTypes ON RecipeDishType.DishTypeId = DishTypes.DishTypeID
JOIN RecipeIngredient ON FoodRecipes.RecipeId = RecipeIngredient.RecipeId
JOIN Ingredients ON FoodRecipes.RecipeId = Ingredients.IngredientID
JOIN RecipeMealType ON FoodRecipes.RecipeId = RecipeMealType.RecipeId
JOIN MealTypes ON RecipeMealType.MealTypeId = MealTypes.MealTypeId
Where FoodRecipes.RecipeId = 5*/


            //var dat = _recipeContext.FoodRecipes
            //    .Where(m => m.RecipeId == recipeId)
            //    .SelectMany(c => c.RecipeCookingStyles)
            //    .SelectMany(c=>c.)
            //    {
            //        RecipeId = recipeId
            //    });

            //.SelectMany(rd =>rd.);

            //    {
            //        FoodRecipe = m,
            //        RecipeCookingStyle = m.RecipeId,
            //        RecipeDirection = m.RecipeId,
            //        RecipeCuisine = m.RecipeId,
            //        RecipeDishType = m.RecipeId,
            //        RecipeIngredient = m.RecipeId,
            //        RecipeMealType = m.RecipeId
            //    }
            //).FirstOrDefault();
        }

        public int AddFoodRecipe(RecipeRequest recipeRequest)
        {
            var foodrecipeMap = GetMappingToFoodRecipe(recipeRequest);
            _recipeContext.FoodRecipes.Add(foodrecipeMap);
           
            var recipeIngredients = MapToRecipeIngredient(recipeRequest);
            if(recipeIngredients != null)
            {
                foodrecipeMap.RecipeIngredients.AddRange(recipeIngredients);
            }

            _recipeContext.SaveChanges();
            return foodrecipeMap.RecipeId;
        }

        private List<RecipeIngredient> MapToRecipeIngredient(RecipeRequest recipeRequest)
        {
            var recipeIngredients = new List<RecipeIngredient>();
            foreach (var ingredient in recipeRequest.Ingredients)
            {
                var recipeIngredient = new RecipeIngredient();
                {
                    if (ingredient.IngredientName != null && ingredient.Quantity != null)
                        recipeIngredient.Quantity = ingredient.Quantity;
                    recipeIngredient.Unit = ingredient.Unit;
                    recipeIngredient.MainIngredient = ingredient.MainIngredient;
                    if (CheckIngredient(ingredient.IngredientName))
                    {
                        var intgr = GetIngredientId(ingredient.IngredientName);
                        recipeIngredient.IngredientId = intgr.IngredientId;
                        recipeIngredient.Ingredient = new Ingredient();
                        //{
                        //    IngredientName = intgr.IngredientName,
                        //    IngredientId = intgr.IngredientId
                        //};

                    }
                    else
                    {
                        var ingredients = MapToIngredient(ingredient.IngredientName);
                        if(ingredients != null)
                        recipeIngredient.IngredientId = ingredients.IngredientId;
                    }
                }
                recipeIngredients.Add(recipeIngredient);
            }

            return recipeIngredients;
        }

        private bool CheckIngredient(string ingredientName)
        {
            var ingredient = _recipeContext.Ingredients
                .FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingredient != null && ingredient.IngredientName.Equals(ingredientName);
        }

        private Ingredient GetIngredientId(string ingredientName)
        {
            var ingreident = _recipeContext.Ingredients
                .FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingreident;
        }

        private Ingredient MapToIngredient(string ingredientName)
        {
            Ingredient intgrident = new Ingredient();
            if (!CheckIngredient(ingredientName))
            {
                if(!string.IsNullOrWhiteSpace(ingredientName))
                intgrident.IngredientName = ingredientName;
            }
            return intgrident;
        }

        private FoodRecipe GetMappingToFoodRecipe(RecipeRequest recipeRequest)
        {
            var recipe = new FoodRecipe
            {
                FoodName = recipeRequest.FoodName,
                PrepTime = recipeRequest.PrepTime,
                ReadyIn = recipeRequest.ReadyIn,
                CookingTime = recipeRequest.CookingTime,
                CreatedBy = recipeRequest.CreatedBy
            };
            return recipe;
        }

        private RecipeDirection MapRecipeDirections(Direction direction)
        {
            var dir = new RecipeDirection
            {
                StepNo = direction.Step,
                Instructions = direction.Instruction
            };
            return dir;
        }

    }
}