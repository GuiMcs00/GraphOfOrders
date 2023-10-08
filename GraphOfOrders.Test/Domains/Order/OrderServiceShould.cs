using Moq;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib;

public class OrderServiceShould
{
    private readonly Mock<IOrderRepository> _mockRepo;
    private readonly OrderService _service;

    public OrderServiceShould()
    {
        _mockRepo = new Mock<IOrderRepository>();
        _service = new OrderService(_mockRepo.Object);
    }

    [Fact]
    public void GetOrdersByBrand_ReturnsOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { OrderId = 1, BrandId = 1, OrderDate = DateTime.Now }
        };
        _mockRepo.Setup(repo => repo.GetOrdersByBrand(1)).Returns(orders);

        // Act
        var result = _service.GetOrdersByBrand(1);

        // Assert
        Assert.Single(result);
        Assert.Equal(1, result.First().OrderId);
        _mockRepo.Verify(repo => repo.GetOrdersByBrand(1), Times.Once);
    }
}
