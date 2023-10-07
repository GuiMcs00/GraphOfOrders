using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            var products = _productRepository.GetProductsByCategory(categoryId);
            return products.Select(p => new ProductDTO
            {
                CategoryId = p.CategoryId,
                ProductId = p.ProductId,
                ProductName = p.ProductName
            });
        }
    }
}