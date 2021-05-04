using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Entities
{
    public class Tags
    {
        [ForeignKey("PID")]
        public Product product { get; set; }
        public Guid PID { get; set; }
        
        public string tag { get; set; }
        
    }
}
