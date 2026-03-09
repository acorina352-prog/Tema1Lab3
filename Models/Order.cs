using System.Collections.Generic;

namespace ECommerceOrder.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }
        public PaymentMethod Payment { get; set; }
        public Courier Courier { get; set; }
    }
}
