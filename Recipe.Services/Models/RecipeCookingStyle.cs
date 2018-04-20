using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
    public class RecipeCookingStyle
    {
        [Key,Column(Order = 0)]
        public int RecipeCookingStyleId { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }

        [Key, Column(Order = 2)]
        public int CookingStyleId { get; set; }

        [ForeignKey("CookingStyleId")]
        public virtual CookingStyle CookingStyle { get; set; }

        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }
    }
}
