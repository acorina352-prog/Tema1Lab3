namespace ECommerceOrder.Services
{
    public class DiscountService
    {
        public decimal ApplyDiscount(decimal total)
        {
            // Simple discount rule: 10% off for orders over 1000
            if (total > 1000m)
                return total * 0.9m;

            return total;
        }
    }
}
