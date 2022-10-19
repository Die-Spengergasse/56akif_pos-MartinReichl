using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    internal class ShoppingCart
    {
        public int Id { get; set; }

        public int ItemsCount { get; }
        public decimal PriceTotal { get; set; }

        public Customer CustomerNavigation { get; set; } = default!;

        public List<ShoppingCart> ShoppingCartItems { get; set; } = new();
    }
}
