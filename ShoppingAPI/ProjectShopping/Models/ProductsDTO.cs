using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class ProductsDTO
    {
        public Guid PID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public int Price { get; set; }
        public string Gender { get; set; }
        public string MainCategory { get; set; }
        public ICollection<StockProductionDTO> Inventory { get; set; } = new List<StockProductionDTO>();
    }
}
