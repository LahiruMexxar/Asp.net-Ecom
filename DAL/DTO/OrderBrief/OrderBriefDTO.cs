using DAL.DTO.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.OrderBrief
{
    public class OrderBriefDTO
    {
        public int OrderBriefId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
