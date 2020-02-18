using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone.Models
{
    public class Phone1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
