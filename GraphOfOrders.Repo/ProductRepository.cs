using GraphOfOrders.Lib;
using GraphOfOrders.Lib.DI;

namespace GraphOfOrders.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersContext _context;

        public ProductRepository(OrdersContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}