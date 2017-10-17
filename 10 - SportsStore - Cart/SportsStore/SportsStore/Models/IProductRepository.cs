using System.Linq;

namespace SportsStore.Models {

    public interface IProductRepository {

        IQueryable<Product> Products { get; }
    }
}
