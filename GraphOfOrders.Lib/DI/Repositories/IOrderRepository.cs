using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByBrand(int brandId);
    }

}
