using System.Collections.Generic;
using ECommerceOrder.Models;

namespace ECommerceOrder.Services
{
    public class OrderService
    {
        private static int _nextId = 1;

        public Order CreateOrder(IEnumerable<CartItem> items, PaymentMethod payment, Courier courier, decimal total)
        {
            var order = new Order
            {
                Id = _nextId++,
                Items = new List<CartItem>(items),
                Total = total,
                Payment = payment,
                Courier = courier
            };

            // In a real app you'd persist the order here
            return order;
        }
    }
}
