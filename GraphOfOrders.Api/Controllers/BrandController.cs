using GraphOfOrders.Service;
using GraphOfOrders.Lib.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("brands-by-product")]
        public IEnumerable<BrandDTO> GetBrandsByProduct(int productId)
        {
            return _brandService.GetBrandsByProduct(productId);
        }

        [HttpGet("products-by-category")]
        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            return _brandService.GetProductsByCategory(categoryId);
        }

        [HttpGet("categories")]
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            return _brandService.GetAllCategories();
        }
    }
}