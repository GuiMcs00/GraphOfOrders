using Xunit;
using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib.Entities;

public class CustomerRepositoryTests : IDisposable
{
    private readonly OrdersContext _context;
    private readonly CustomerRepository _repo;

    public CustomerRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "TestCustomerDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new CustomerRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted(); // Delete the in-memory database after test
        _context.Dispose(); // Dispose of the context
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

    [Fact]
    public async Task UpdateCustomer_ShouldUpdateCustomer_WhenCustomerExists()
    {
        // Arrange
        var existingCustomer = new Customer { CustomerId = 1, Name = "OriginalName", Email = "original@example.com" };
        _context.Customers.Add(existingCustomer);
        await _context.SaveChangesAsync();

        var updatedCustomer = new Customer { Name = "UpdatedName", Email = "updated@example.com" };

        // Act
        var result = await _repo.UpdateCustomer(1, updatedCustomer);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("UpdatedName", result.Name);
        Assert.Equal("updated@example.com", result.Email);
    }

    [Fact]
    public async Task UpdateCustomer_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
        // Arrange
        var updatedCustomer = new Customer { Name = "UpdatedName", Email = "updated@example.com" };

        // Act
        var result = await _repo.UpdateCustomer(9999, updatedCustomer);

        // Assert
        Assert.Null(result);
    }

}
