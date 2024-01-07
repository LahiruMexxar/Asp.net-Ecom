using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderBriefId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderBrief OrderBrief { get; set; }
        public Product Product { get; set; }
    }
}
