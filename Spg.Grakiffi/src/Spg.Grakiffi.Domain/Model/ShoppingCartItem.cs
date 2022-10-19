using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    internal class ShoppingCartItem
    {
        public int Id { get; set; }

        public decimal Price
        {
            get => default;
            set
            {
            }
        }
    }
}
