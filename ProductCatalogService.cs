using System;

namespace Pentru_Corina
{
    public class ProductCatalogService
    {
        private List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 3500 },
        new Product { Id = 2, Name = "Mouse", Price = 80 },
        new Product { Id = 3, Name = "Monitor", Price = 900 }
    };

        public IEnumerable<Product> GetAll() => _products;
    }
}