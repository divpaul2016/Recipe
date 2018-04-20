using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("CookingStyle")]
    public class CookingStyle
    {
        public CookingStyle()
        {
            RecipeCookingStyles = new HashSet<RecipeCookingStyle>();
        }

        public string CookingStyleName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CookingStyleId { get; set; }

        public virtual ICollection<RecipeCookingStyle> RecipeCookingStyles { get; set; }
    }
}