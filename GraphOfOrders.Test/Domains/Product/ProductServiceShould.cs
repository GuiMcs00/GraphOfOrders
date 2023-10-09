using Moq;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.Entities;

public class ProductServiceShould
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceShould()
    {
        _mockRepo = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public void GetProductsByCategory_ReturnsProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product1", CategoryId = 1 },
            new Product { ProductId = 2, ProductName = "Product2", CategoryId = 1 }
        };
        _mockRepo.Setup(repo => repo.GetProductsByCategory(1)).Returns(products);

        // Act
        var result = _service.GetProductsByCategory(1);

        // Assert
        Assert.Equal(2, result.Count());
        _mockRepo.Verify(repo => repo.GetProductsByCategory(1), Times.Once);
    }
}
