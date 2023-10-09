using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DI;

namespace GraphOfOrders.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OrdersContext _context;

        public CategoryRepository(OrdersContext context)
        {
            _context = context;
        }
                
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}