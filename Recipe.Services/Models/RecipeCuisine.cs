using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class RecipeCuisine
    {
        [Key]
        public int RecipeCuisineId { get; set; }
        public int RecipeId { get; set; }
        public int CuisineId { get; set; }


        [ForeignKey("CuisineId")]
        public virtual Cuisine Cuisine { get; set; }

        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }
    }
}
