using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DI;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Brand> GetBrands(int howMany, int page)
        {
            var skip = (page - 1) * howMany;
            var data = _context.Brands.Skip(skip).Take(howMany).ToList();
            return data;
        }
        public async Task<Brand> GetBrandById(int brandId)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.BrandId == brandId);
        }
    }
}