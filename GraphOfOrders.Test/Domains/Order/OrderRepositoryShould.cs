using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib.Entities;

public class OrderRepositoryShould
{
    private readonly OrdersContext _context;
    private readonly OrderRepository _repo;

    public OrderRepositoryShould()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "OrderTestDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new OrderRepository(_context);
    }

    [Fact]
    public void GetOrdersByBrand_ReturnsOrders()
    {
        // Arrange
        var order = new Order { OrderId = 1, BrandId = 1, CustomerId = 1, OrderDate = DateTime.Now };
        _context.Orders.Add(order);
        _context.SaveChanges();

        // Act
        var result = _repo.GetOrdersByBrand(1);

        // Assert
        Assert.Single(result);
        Assert.Equal(1, result.First().OrderId);
    }
}
