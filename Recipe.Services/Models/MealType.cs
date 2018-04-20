using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
    public class MealType
    {
        public MealType()
        {
            this.RecipeMealTypes = new HashSet<RecipeMealType>();
        }
        public string MealTypeName { get; set; }

        [Key]
        [ForeignKey("RecipeMealTypes")]
        public int MealTypeId { get; set; }

        public virtual ICollection<RecipeMealType> RecipeMealTypes { get; set; }
    }
}
