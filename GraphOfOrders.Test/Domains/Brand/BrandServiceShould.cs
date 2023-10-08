using Moq;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib;

public class BrandServiceShould
{
    private readonly Mock<IBrandRepository> _mockRepo;
    private readonly BrandService _service;

    public BrandServiceShould()
    {
        _mockRepo = new Mock<IBrandRepository>();
        _service = new BrandService(_mockRepo.Object);
    }

    [Fact]
    public void ReturnBrandsBasedOnProductId()
    {
        // Arrange
        var brands = new List<Brand>
        {
            new Brand { BrandId = 1, BrandName = "Brand1", ProductId = 1 },
            new Brand { BrandId = 2, BrandName = "Brand2", ProductId = 1 }
        };
        _mockRepo.Setup(repo => repo.GetBrandsByProduct(1)).Returns(brands);

        // Act
        var result = _service.GetBrandsByProduct(1);

        // Assert
        Assert.Equal(2, result.Count());
        _mockRepo.Verify(repo => repo.GetBrandsByProduct(1), Times.Once);
    }
}
