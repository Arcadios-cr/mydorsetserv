using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    public class Food
    {
        

        [Key]
        public int barcode { get; set; }
        public string expiring_date { get; set; }
        public int price { get; set; }
        public int weight { get; set; }
    }
}
