using Moq;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib;

public class CategoryServiceShould
{
    private readonly Mock<ICategoryRepository> _mockRepo;
    private readonly CategoryService _service;

    public CategoryServiceShould()
    {
        _mockRepo = new Mock<ICategoryRepository>();
        _service = new CategoryService(_mockRepo.Object);
    }

    [Fact]
    public void ReturnAllCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Clothing" }
        };
        _mockRepo.Setup(repo => repo.GetCategories()).Returns(categories);

        // Act
        var result = _service.GetAllCategories();

        // Assert
        Assert.Equal(2, result.Count());
        _mockRepo.Verify(repo => repo.GetCategories(), Times.Once);
    }
}
