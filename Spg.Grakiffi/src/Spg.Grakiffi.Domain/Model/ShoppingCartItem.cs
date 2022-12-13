using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public class ShoppingCartItem
    {
        public int Id { get; }
        public decimal Price { get; set; }
        public ShoppingCart ShoppingCartNavigation { get; set; } = default!;
        public Product ProductNavigation { get; set; } = default!;
    }
}
