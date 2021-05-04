using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Entities
{
    public class Order
    {
        [Key]
        public Guid OID { get; set; }

        [ForeignKey("UID")]
        public User user { get; set; }
        public Guid UID { get; set; }
        public string status { get; set; }
        public string dAddress { get; set; }
        public double total { get; set; }
        public DateTime oDate { get; set; }

        public ICollection<Cart> CartItems { get; set; } = new List<Cart>();
    }
}
