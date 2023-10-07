using GraphOfOrders.Lib.DTOs;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProductsByCategory(int categoryId);
    }
}