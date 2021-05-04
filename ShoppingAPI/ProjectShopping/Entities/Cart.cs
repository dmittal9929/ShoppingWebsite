using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Entities
{
    public class Cart
    {
        [Key]
        public Guid CID { get; set; }
        [ForeignKey("PID")]
        public Product prduct { get; set;}
        public Guid PID { get; set; }

        [ForeignKey("UID")]
        public User user { get; set; }
        public Guid? UID { get; set; }
       
        [ForeignKey("OID")]
        [System.Text.Json.Serialization.JsonIgnore]
        public Order order { get; set; }
        public Guid OID { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

    }
}
