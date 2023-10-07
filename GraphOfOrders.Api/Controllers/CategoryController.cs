using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.DI;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
    }
}