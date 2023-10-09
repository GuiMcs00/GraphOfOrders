using Xunit;
using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib.Entities;

public class CustomerRepositoryTests
{
    private readonly OrdersContext _context;
    private readonly CustomerRepository _repo;

    public CustomerRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new CustomerRepository(_context);
    }

    [Fact]
    public async Task CreateCustomer_ShouldReturnCustomerDTO()
    {
        // Arrange
        var customer = new Customer { CustomerId = 1, Name = "Test", Email = "test@example.com" };

        // Act
        var result = await _repo.CreateCustomer(customer);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
    }
}
