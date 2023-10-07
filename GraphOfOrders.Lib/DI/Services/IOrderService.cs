using GraphOfOrders.Lib.DTOs;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrdersByBrand(int brandId);
    }
}