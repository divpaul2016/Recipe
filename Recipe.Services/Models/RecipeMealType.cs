using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
    public  class RecipeMealType
    {
        public int RecipeMealTypeId { get; set; }
        public int RecipeId { get; set; }
        public int MealTypeId { get; set; }


        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }

        [ForeignKey("MealTypeId")]
        public virtual MealType MealType { get; set; }
    }
}
