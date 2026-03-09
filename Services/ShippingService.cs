using ECommerceOrder.Models;

namespace ECommerceOrder.Services
{
    public class ShippingService
    {
        public decimal GetShippingCost(Courier courier)
        {
            switch (courier)
            {
                case Courier.FanCourier: return 15m;
                case Courier.Cargus: return 20m;
                case Courier.DHL: return 35m;
                default: return 0m;
            }
        }
    }
}
