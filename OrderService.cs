using System;
namespace Pentru_Corina
{
    public class OrderService
    {
        public Order CreateOrder(
            IEnumerable<CartItem> items,
            PaymentMethod payment,
            Courier courier,
            decimal total)
        {
            return new Order
            {
                Id = new Random().Next(1000, 9999),
                Items = items.ToList(),
                Payment = payment,
                Courier = courier,
                Total = total
            };
        }
    }
}