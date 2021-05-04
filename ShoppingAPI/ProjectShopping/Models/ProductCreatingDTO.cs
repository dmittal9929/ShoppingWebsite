using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class ProductCreatingDTO
    {
        // pid is not there 
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public String Image { get; set; }
        public string Gender { get; set; }
        public string MainCategory { get; set; }

        //tagProductionDTo instead of Tag entity class 
        public ICollection<TagProductionDTO> TagList{ get; set; } = new List<TagProductionDTO>();
        public ICollection<StockProductionDTO> Inventory { get; set; } = new List<StockProductionDTO>();
    }
}
