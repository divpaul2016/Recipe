using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Services.Models
{
    [Table("DishType")]
    public class DishType
    {
        public DishType()
        {
            this.RecipeDishTypes = new HashSet<RecipeDishType>();
        }
        public string DishTypeName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishTypeId { get; set; }

        public virtual ICollection<RecipeDishType> RecipeDishTypes { get; set; }
    }
}
