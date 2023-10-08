using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrandsByProduct(int productId);
    }

}
