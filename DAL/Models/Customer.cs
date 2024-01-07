using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<OrderBrief> Orders { get; set; }

    }
}
