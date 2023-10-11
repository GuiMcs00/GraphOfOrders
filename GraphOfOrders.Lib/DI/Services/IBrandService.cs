using GraphOfOrders.Lib.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphOfOrders.Lib.DI
{
    public interface IBrandService
    {
        IEnumerable<BrandDTO> GetBrandsByProduct(int productId);
        Task<BrandDTO> GetBrandById(int brandId);
        IEnumerable<BrandDTO> GetBrands(int howMany, int page);
    }
}