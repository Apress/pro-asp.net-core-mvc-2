using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models {

    public interface IRepository {

        IEnumerable<Product> Products { get; }
        void AddProduct(Product p);
    }
}
