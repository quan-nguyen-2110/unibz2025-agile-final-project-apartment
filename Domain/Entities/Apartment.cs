using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Address { get; set; } = default!;
        public int Floor { get; set; }
        public double Area { get; set; } // m2
        public decimal Price { get; set; }
    }
}
