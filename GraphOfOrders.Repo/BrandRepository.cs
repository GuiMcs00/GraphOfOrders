using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DI;

namespace GraphOfOrders.Repo
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OrdersContext _context;

        public BrandRepository(OrdersContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrandsByProduct(int productId)
        {
            return _context.Brands.Where(b => b.ProductId == productId).ToList();
        }
    }
}