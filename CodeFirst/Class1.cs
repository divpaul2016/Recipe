using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Myrecicpe
    {

        public int Recipeid { get; set; }
        public string Name { get; set; }

        public System.DateTime DateTime CreatedOn { get; set; }
        public Cuisine Cuisine { get; set; }

        public DishType DishType { get; set; }
    }

    public class Cuisine
    {
        public int CuisineId { get; set; }
        public string CuisineName { get; set; }
    }

    public class DishType
    {
        public int dishId { get; set; }
        public  int dishname { get; set; }

    }
}
