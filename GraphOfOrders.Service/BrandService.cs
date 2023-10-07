using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IEnumerable<BrandDTO> GetBrandsByProduct(int productId)
        {
            var brands = _brandRepository.GetBrandsByProduct(productId);
            return brands.Select(b => new BrandDTO
            {
                BrandId = b.BrandId,
                BrandName = b.BrandName,
                ProductId = b.ProductId
            });
        }
    }
}