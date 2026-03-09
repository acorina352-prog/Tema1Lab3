using System;
namespace Pentru_Corina
{
    public class ShoppingCartService
    {
        private List<CartItem> _items = new();

        public void AddToCart(Product product, int qty)
        {
            _items.Add(new CartItem { Product = product, Quantity = qty });
        }

        public IEnumerable<CartItem> GetItems() => _items;

        public decimal GetTotal() =>
            _items.Sum(i => i.Product.Price * i.Quantity);
    }
}