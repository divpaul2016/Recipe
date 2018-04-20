using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
    public class RecipeDishType
    {
        public int RecipeDishTypeId { get; set; }
        public int RecipeId { get; set; }
        public int DishTypeId { get; set; }

        [ForeignKey("DishTypeId")]
        public virtual DishType DishType { get; set; }
        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }
    }

}
