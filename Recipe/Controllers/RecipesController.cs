using Microsoft.Ajax.Utilities;
using Recipe.Services;
using Recipe.Services.Models;
using System;
using System.Web.Http;
using Newtonsoft.Json;
using Recipe.Services.Models.ApiModels;

namespace Recipes.Controllers
{
    public class RecipesController : ApiController
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService service)
        {
            _recipeService = service;
        }

        //GET: api/Recipes/5
        public IHttpActionResult GetRecipeByRecipeId(int id)
        {
            var recipe = _recipeService.GetFoodRecipe(id);
            var outPut = JsonConvert.SerializeObject(recipe);
            return Ok(outPut);
        }

        ///PUT: api/Recipes/5
        [HttpPut]
        public IHttpActionResult GetAllRecipe([FromBody]RecipeIdRequest recipeIdRequest)
        {
            var recipe = _recipeService.GetFoodRecipe(recipeIdRequest.RecipeId);
            var outPut = JsonConvert.SerializeObject(recipe);
            return Ok(outPut);
        }

        // POST: api/Recipes
        [HttpPost]
        public IHttpActionResult CreateRecipe([FromBody]RecipeRequest recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest();
                }

                if (recipe.FoodName.IsNullOrWhiteSpace())
                {
                    return BadRequest();
                }

                var recipeId = _recipeService.CreateRecipe(recipe);

                return Ok(new Response { RecipeId = recipeId });
            }
            catch (ArgumentException exception)
            {
                return BadRequest();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
