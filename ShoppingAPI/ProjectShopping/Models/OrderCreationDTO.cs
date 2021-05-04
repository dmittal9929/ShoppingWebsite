using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class OrderCreationDTO
    {
        public string dAddress { get; set; }
        public ICollection<CartCreationDTO> CartItems { get; set; } = new List<CartCreationDTO>();
    }
}
