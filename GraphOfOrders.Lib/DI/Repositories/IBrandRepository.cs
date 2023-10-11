using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrandsByProduct(int productId);
        IEnumerable<Brand> GetBrands(int howMany, int page);
        Task<Brand> GetBrandById(int brandId);
    }

}
