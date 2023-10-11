using AutoMapper;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
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
        public async Task<BrandDTO> GetBrandById(int brandId)
        {
            var brand = await _brandRepository.GetBrandById(brandId);
            return _mapper.Map<BrandDTO>(brand);
        }
        public IEnumerable<BrandDTO> GetBrands(int itemsPerPage, int page)
        {
            var brands = _brandRepository.GetBrands(itemsPerPage, page);
            var brandDTOs = _mapper.Map<IEnumerable<BrandDTO>>(brands);
            return brandDTOs;
        }
    }
}