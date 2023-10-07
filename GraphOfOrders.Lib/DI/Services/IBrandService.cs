using GraphOfOrders.Lib.DTOs;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IBrandService
    {
        IEnumerable<BrandDTO> GetBrandsByProduct(int productId);
        IEnumerable<CategoryDTO> GetAllCategories();
        IEnumerable<ProductDTO> GetProductsByCategory(int categoryId);
    }
}