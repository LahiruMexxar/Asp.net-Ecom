using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderBrief
    {
        public int OrderBriefId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
