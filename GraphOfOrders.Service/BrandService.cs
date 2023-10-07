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
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categories = _brandRepository.GetCategories();
            return categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            });
        }
        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            var products = _brandRepository.GetProductsByCategory(categoryId);
            return products.Select(p => new ProductDTO
            {
                CategoryId = p.CategoryId,
                ProductId = p.ProductId,
                ProductName = p.ProductName
            });
        }
    }
}