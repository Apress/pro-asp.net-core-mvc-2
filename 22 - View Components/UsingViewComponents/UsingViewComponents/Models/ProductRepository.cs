using System.Collections.Generic;

namespace UsingViewComponents.Models {

    public interface IProductRepository {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product newProduct);
    }

    public class MemoryProductRepository : IProductRepository {
        private List<Product> products = new List<Product> {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M }
        };

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product newProduct) {
            products.Add(newProduct);
        }
    }
}
