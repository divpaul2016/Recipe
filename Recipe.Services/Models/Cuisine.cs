using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("Cuisine")]
    public class Cuisine
    {
        public Cuisine()
        {
            RecipeCuisines = new HashSet<RecipeCuisine>();
        }

        public string CuisineName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuisineId { get; set; }

        public virtual ICollection<RecipeCuisine> RecipeCuisines { get; set; }
    }
}