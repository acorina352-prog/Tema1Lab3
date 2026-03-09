using System.Collections.Generic;
using ECommerceOrder.Models;

namespace ECommerceOrder.Services
{
    public class ProductCatalogService
    {
        private readonly List<Product> _products;

        public ProductCatalogService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 3000m },
                new Product { Id = 2, Name = "Mouse", Price = 50m },
                new Product { Id = 3, Name = "Tastatura", Price = 120m }
            };
        }

        public IEnumerable<Product> GetAll() => _products;
    }
}
