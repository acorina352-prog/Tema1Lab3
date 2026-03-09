using System.Collections.Generic;
using System.Linq;
using ECommerceOrder.Models;

namespace ECommerceOrder.Services
{
    public class ShoppingCartService
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public void AddToCart(Product product, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public IEnumerable<CartItem> GetItems() => _items;

        public decimal GetTotal() => _items.Sum(i => i.Product.Price * i.Quantity);
    }
}
