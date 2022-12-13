using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public class Product
    {
        private List<ShoppingCartItem> _shoppingCartItems = new();

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public string Ean { get; set; } = string.Empty;
        public string? Material { get; set; } = string.Empty;
        //public DateTime? ExpiryDate { get; set; }
        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;
        
        public Product(string name, decimal price, int tax, string ean)
        {
            Name = name;
            Price = price;
            Tax = tax;
            Ean = ean;
        }
    }
}
