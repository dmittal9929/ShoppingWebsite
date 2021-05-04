using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Entities
{
    public class User
    {
        [Key]
        public Guid UID { get; set; }
        public String Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public Double number { get; set; }
        public char role { get; set; }
        public ICollection<Order> OrderHistory { get; set; } = new List<Order>();
        public ICollection<Cart> CartItems { get; set; } = new List<Cart>();
    }
}
