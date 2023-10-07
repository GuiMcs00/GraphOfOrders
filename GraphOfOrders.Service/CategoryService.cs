using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            });
        }
    }
}