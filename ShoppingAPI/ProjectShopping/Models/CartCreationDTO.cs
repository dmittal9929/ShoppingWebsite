using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class CartCreationDTO
    {
        public Guid PID { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
