using GraphOfOrders.Lib;
using GraphOfOrders.Lib.DI;

namespace GraphOfOrders.Repo {
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;

        public OrderRepository(OrdersContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrdersByBrand(int brandId)
        {
            return _context.Orders.Where(o => o.BrandId == brandId).ToList();
        }
    }
}
