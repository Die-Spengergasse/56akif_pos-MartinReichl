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

        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public ShoppingCartStates ShoppingCartState { get; set; }
        public DateTime CreationDate { get; private set; }
        public int ItemsCount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int CustomerNavigationId { get; set; }
        public Customer CustomerNavigation { get; set; } = default!;
        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;

        public ShoppingCart(string name, ShoppingCartStates shoppingCartState, DateTime creationDate)
        {
            Name = name;
            ShoppingCartState = shoppingCartState;
            CreationDate = creationDate;
        }

        protected ShoppingCart()
        { }
    }
}
