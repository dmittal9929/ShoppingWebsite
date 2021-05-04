using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class OrderReturnDTO
    {
        public Guid OID { get; set; }
        public string status { get; set; }
        public string dAddress { get; set; }
        public double total { get; set; }
        public DateTime oDate { get; set; }

        public ICollection<CartCreationDTO> CartItems { get; set; } = new List<CartCreationDTO>();
    }
}
