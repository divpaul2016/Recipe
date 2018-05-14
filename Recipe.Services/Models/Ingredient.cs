using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
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
