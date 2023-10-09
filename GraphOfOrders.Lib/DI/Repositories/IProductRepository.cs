using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }

}
