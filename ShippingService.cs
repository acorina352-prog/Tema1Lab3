using System;
namespace Pentru_Corina
{
    public class ShippingService
    {
        public decimal GetShippingCost(Courier courier)
        {
            return courier switch
            {
                Courier.FanCourier => 20,
                Courier.Cargus => 18,
                Courier.DHL => 35,
                _ => 0
            };
        }
    }
}