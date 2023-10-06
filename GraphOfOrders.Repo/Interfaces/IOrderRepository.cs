using GraphOfOrders.Lib;

namespace GraphOfOrders.Interfaces.Repo
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByBrand(int brandId);
    }

}
