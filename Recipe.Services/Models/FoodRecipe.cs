using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("FoodRecipe")]
    public class FoodRecipe
    {
        public FoodRecipe()
        {
            //RecipeCookingStyles = new HashSet<RecipeCookingStyle>();
            //RecipeCuisines = new HashSet<RecipeCuisine>();
            //RecipeDirections = new HashSet<RecipeDirection>();
            //RecipeDishTypes = new HashSet<RecipeDishType>();
            RecipeIngredients = new List<RecipeIngredient>();
            //RecipeMealTypes = new HashSet<RecipeMealType>();
        }

        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        public string FoodName { get; set; }
        public int PrepTime { get; set; }
        public int ReadyIn { get; set; }
        public int CookingTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int MainIngredientId { get; set; }

        //public virtual ICollection<RecipeCookingStyle> RecipeCookingStyles { get; set; }
        //public virtual ICollection<RecipeCuisine> RecipeCuisines { get; set; }
        //public virtual ICollection<RecipeDirection> RecipeDirections { get; set; }
        //public virtual ICollection<RecipeDishType> RecipeDishTypes { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        //public virtual ICollection<RecipeMealType> RecipeMealTypes { get; set; }
    }
}