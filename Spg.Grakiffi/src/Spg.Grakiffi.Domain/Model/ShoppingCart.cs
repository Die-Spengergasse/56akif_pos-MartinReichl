using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public enum ShoppingCartStates { Active = 0, Sent = 1, Unknown = 99 }

    public class ShoppingCart 
    {
        private List<ShoppingCartItem> _shoppingCartItems = new();

        public int Id { get; }
        public int ItemsCount { get; }
        public string Name { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public ShoppingCartStates ShoppingCartState { get; set; }
        public DateTime CreationDate { get; set; }
        public Customer CustomerNavigation { get; set; } = default!;
        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;
    }
}
