using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib;

public class ProductRepositoryShould
{
    private readonly OrdersContext _context;
    private readonly ProductRepository _repo;

    public ProductRepositoryShould()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "ProductTestDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new ProductRepository(_context);
    }

    [Fact]
    public void GetProductsByCategory_ReturnsProducts()
    {
        // Arrange
        var product = new Product { ProductId = 1, ProductName = "TestProduct", CategoryId = 1 };
        _context.Products.Add(product);
        _context.SaveChanges();

        // Act
        var result = _repo.GetProductsByCategory(1);

        // Assert
        Assert.Single(result);
        Assert.Equal("TestProduct", result.First().ProductName);
    }
}
