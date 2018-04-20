using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
   public class RecipeDirection
    {
        [Key]
        public int RecipeDirectionId { get; set; }
        public int RecipeId { get; set; }
        public int StepNo { get; set; }
        public string Instructions { get; set; }

        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }
    }
}
