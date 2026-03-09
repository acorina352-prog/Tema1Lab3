using System;
using System.Linq;
using ECommerceOrder.Models;
using ECommerceOrder.Services;


namespace Pentru_Corina
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new ProductCatalogService();
            var cart = new ShoppingCartService();
            var discountService = new DiscountService();
            var shippingService = new ShippingService();
            var orderService = new OrderService();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== E-Commerce Menu ===");
                Console.WriteLine("1. Vezi catalog produse");
                Console.WriteLine("2. Adauga produs in cos");
                Console.WriteLine("3. Vezi cosul");
                Console.WriteLine("4. Finalizeaza comanda");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("=== Catalog Produse ===");
                        foreach (var p in catalog.GetAll())
                            Console.WriteLine($"{p.Id}. {p.Name} - {p.Price} lei");
                        break;

                    case "2":
                        Console.Write("Introdu ID produs: ");
                        int id;
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("ID invalid.");
                            break;
                        }

                        var product = catalog.GetAll().FirstOrDefault(p => p.Id == id);
                        if (product == null)
                        {
                            Console.WriteLine("Produs invalid.");
                            break;
                        }

                        Console.Write("Cantitate: ");
                        int qty;
                        if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                        {
                            Console.WriteLine("Cantitate invalida.");
                            break;
                        }

                        cart.AddToCart(product, qty);
                        Console.WriteLine("Produs adaugat in cos.");
                        break;

                    case "3":
                        Console.WriteLine("=== Cosul tau ===");
                        foreach (var item in cart.GetItems())
                            Console.WriteLine($"{item.Product.Name} x {item.Quantity} = {item.Product.Price * item.Quantity} lei");

                        Console.WriteLine($"Total: {cart.GetTotal()} lei");
                        break;

                    case "4":
                        Console.WriteLine("=== Finalizare comanda ===");

                        decimal total = cart.GetTotal();
                        total = discountService.ApplyDiscount(total);

                        Console.WriteLine($"Total dupa reducere: {total} lei");

                        Console.WriteLine("\nAlege metoda de plata:");
                        Console.WriteLine("1. Card");
                        Console.WriteLine("2. PayPal");
                        Console.WriteLine("3. Ramburs");
                        PaymentMethod payment;
                        if (!int.TryParse(Console.ReadLine(), out int payChoice) || payChoice < 1 || payChoice > 3)
                        {
                            Console.WriteLine("Optiune plata invalida.");
                            break;
                        }
                        payment = (PaymentMethod)(payChoice - 1);

                        Console.WriteLine("\nAlege curier:");
                        Console.WriteLine("1. FanCourier");
                        Console.WriteLine("2. Cargus");
                        Console.WriteLine("3. DHL");
                        Courier courier;
                        if (!int.TryParse(Console.ReadLine(), out int courierChoice) || courierChoice < 1 || courierChoice > 3)
                        {
                            Console.WriteLine("Optiune curier invalida.");
                            break;
                        }
                        courier = (Courier)(courierChoice - 1);

                        total += shippingService.GetShippingCost(courier);

                        var order = orderService.CreateOrder(cart.GetItems(), payment, courier, total);

                        Console.WriteLine($"\nComanda plasata cu succes!");
                        Console.WriteLine($"ID Comanda: {order.Id}");
                        Console.WriteLine($"Total final: {order.Total} lei");

                        running = false;
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }
    }
}
