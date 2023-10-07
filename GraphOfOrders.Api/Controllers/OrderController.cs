using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GraphOfOrders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderDTO> GetOrdersByBrand(int brandId)
        {
            return _orderService.GetOrdersByBrand(brandId);
        }
    }
}