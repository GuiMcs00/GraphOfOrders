using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrandsByProduct(int productId);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Category> GetCategories();
    }

}
