using Xunit;
using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib;

public class BrandRepositoryTests
{
    private readonly OrdersContext _context;
    private readonly BrandRepository _repo;

    public BrandRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new BrandRepository(_context);
    }

    [Fact]
    public void GetBrandsByProduct_ReturnsBrands()
    {
        // Arrange
        var brand = new Brand { BrandId = 1, BrandName = "TestBrand", ProductId = 1 };
        _context.Brands.Add(brand);
        _context.SaveChanges();

        // Act
        var result = _repo.GetBrandsByProduct(1);

        // Assert
        Assert.Single(result);
        Assert.Equal("TestBrand", result.First().BrandName);
    }
}
