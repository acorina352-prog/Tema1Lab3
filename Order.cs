using System;
namespace Pentru_Corina
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
        public PaymentMethod Payment { get; set; }
        public Courier Courier { get; set; }
        public decimal Total { get; set; }
    }
}