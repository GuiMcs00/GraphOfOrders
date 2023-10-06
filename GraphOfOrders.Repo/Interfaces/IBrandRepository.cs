using GraphOfOrders.Lib;

namespace GraphOfOrders.Interfaces.Repo 
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrandsByProduct(int productId);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Category> GetCategories();
    }

}
