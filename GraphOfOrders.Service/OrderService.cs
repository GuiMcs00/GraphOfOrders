using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDTO> GetOrdersByBrand(int brandId)
        {
            var orders = _orderRepository.GetOrdersByBrand(brandId);
            return orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                BrandId = o.BrandId,
                CustomerId = o.CustomerId
            });
        }
    }

}
