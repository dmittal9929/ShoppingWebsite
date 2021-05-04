using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Entities
{
    public class Stock
    {
        [ForeignKey("PID")]
        [System.Text.Json.Serialization.JsonIgnore]
        public Product product { get; set; }
        public Guid PID { get; set; }

        public string size { get; set; }
        public string color { get; set; }
        public int quantity { get; set; }
     }
}
