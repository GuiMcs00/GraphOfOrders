using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.DI;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products-by-category")]
        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            return _productService.GetProductsByCategory(categoryId);
        }
    }
}