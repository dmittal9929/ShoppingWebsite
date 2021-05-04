using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Models
{
    public class UserCreationDTO
    {
        public String Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public int number { get; set; }
    }
}
