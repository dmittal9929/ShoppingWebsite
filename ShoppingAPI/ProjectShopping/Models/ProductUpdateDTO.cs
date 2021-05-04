using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class ProductUpdateDTO
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public String Image { get; set; }
        public string Gender { get; set; }
        public string MainCategory { get; set; }

    }
}
