using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Repo;
using GraphOfOrders.Lib.Entities;

public class CategoryRepositoryShould
{
    private readonly OrdersContext _context;
    private readonly CategoryRepository _repo;

    public CategoryRepositoryShould()
    {
        var options = new DbContextOptionsBuilder<OrdersContext>()
            .UseInMemoryDatabase(databaseName: "CategoryTestDatabase")
            .Options;

        _context = new OrdersContext(options);
        _repo = new CategoryRepository(_context);
    }

    [Fact]
    public void GetCategories_ReturnsCategories()
    {
        // Arrange
        var category = new Category { CategoryId = 1, CategoryName = "TestCategory" };
        _context.Categories.Add(category);
        _context.SaveChanges();

        // Act
        var result = _repo.GetCategories();

        // Assert
        Assert.Single(result);
        Assert.Equal("TestCategory", result.First().CategoryName);
    }
}
