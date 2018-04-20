using Recipe.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services
{
    public class Ingredient
    {
        //public Ingredient()
        //{
        //    this.RecipeIngredients = new HashSet<RecipeIngredient>();
        //}

        public string IngredientName { get; set; }

        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

       /* public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; *//*}*/
    }
}
