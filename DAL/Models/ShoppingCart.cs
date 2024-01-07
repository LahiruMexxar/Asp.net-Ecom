using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
