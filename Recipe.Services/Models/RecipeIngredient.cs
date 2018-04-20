using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace Recipe.Services.Models
{
    public class RecipeIngredient
    {
        public RecipeIngredient()
        {
            Ingredient = new Ingredient();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeIngredientId { get; set; }

        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }

        public bool MainIngredient { get; set; }

        [ForeignKey("RecipeId")]
        [Column(Order = 0)]
        public FoodRecipe FoodRecipe { get; set; }

        [ForeignKey("IngredientId")]
        [Column(Order = 1)]
        public Ingredient Ingredient { get; set; }
    }
}