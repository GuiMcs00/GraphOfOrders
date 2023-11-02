using Moq;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.Entities;
using AutoMapper;
using GraphOfOrders.Lib.DTOs;

public class BrandServiceShould
{
    private readonly Mock<IBrandRepository> _mockRepo;
    private readonly Mock<IMapper> _mapper;
    private readonly BrandService _service;

    public BrandServiceShould()
    {
        _mockRepo = new Mock<IBrandRepository>();
        _mapper = new Mock<IMapper>();
        _service = new BrandService(_mockRepo.Object, _mapper.Object);
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

    [Fact]
    public async Task ReturnBrandById()
    {
        // Arrange
        var brand = new Brand { BrandId = 1, BrandName = "Brand1", ProductId = 1 };
        var brandDTO = new BrandDTO { BrandId = 1, BrandName = "Brand1", ProductId = 1 };
        _mockRepo.Setup(repo => repo.GetBrandById(1)).ReturnsAsync(brand);
        _mapper.Setup(m => m.Map<BrandDTO>(brand)).Returns(brandDTO);

        // Act
        var result = await _service.GetBrandById(1);

        // Assert
        Assert.Equal(brandDTO, result);
        _mockRepo.Verify(repo => repo.GetBrandById(1), Times.Once);
        _mapper.Verify(m => m.Map<BrandDTO>(brand), Times.Once);
    }

    [Fact]
    public void ReturnBrands()
    {
        // Arrange
        var brands = new List<Brand>
        {
            new Brand { BrandId = 1, BrandName = "Brand1", ProductId = 1 },
            new Brand { BrandId = 2, BrandName = "Brand2", ProductId = 1 }
        };
        var expectedBrandDTOs = brands.Select(b => new BrandDTO
        {
            BrandId = b.BrandId,
            BrandName = b.BrandName,
            ProductId = b.ProductId
        }).ToList();
        _mockRepo.Setup(repo => repo.GetBrands(2, 1)).Returns(brands);
        _mapper.Setup(m => m.Map<IEnumerable<BrandDTO>>(brands)).Returns(expectedBrandDTOs);

        // Act
        var result = _service.GetBrands(2, 1).ToList();

        // Assert
        for (int i = 0; i < expectedBrandDTOs.Count; i++)
        {
            Assert.Equal(expectedBrandDTOs[i].BrandId, result[i].BrandId);
            Assert.Equal(expectedBrandDTOs[i].BrandName, result[i].BrandName);
            Assert.Equal(expectedBrandDTOs[i].ProductId, result[i].ProductId);
        }
        _mockRepo.Verify(repo => repo.GetBrands(2, 1), Times.Once);
        _mapper.Verify(m => m.Map<IEnumerable<BrandDTO>>(brands), Times.Once);
    }

    [Fact]
    public void ReturnBrandsWithCorrectPaginationAndItemsPerPage()
    {
        // Arrange
        var itemsPerPage = 2;
        var page = 1;
        var brands = new List<Brand>
        {
            new Brand { BrandId = 1, BrandName = "Brand1", ProductId = 1 },
            new Brand { BrandId = 2, BrandName = "Brand2", ProductId = 1 },
            new Brand { BrandId = 3, BrandName = "Brand3", ProductId = 1 },
        };
        var pagedBrands = brands.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        var expectedBrandDTOs = pagedBrands.Select(b => new BrandDTO
        {
            BrandId = b.BrandId,
            BrandName = b.BrandName,
            ProductId = b.ProductId
        }).ToList();

        _mockRepo.Setup(repo => repo.GetBrands(itemsPerPage, page)).Returns(pagedBrands);
        _mapper.Setup(m => m.Map<IEnumerable<BrandDTO>>(pagedBrands)).Returns(expectedBrandDTOs);

        // Act
        var result = _service.GetBrands(itemsPerPage, page).ToList();

        // Assert
        for(var i = 0; i < expectedBrandDTOs.Count; i++)
        {
            Assert.Equal(expectedBrandDTOs[i].BrandId, result[i].BrandId);
            Assert.Equal(expectedBrandDTOs[i].BrandName, result[i].BrandName);
            Assert.Equal(expectedBrandDTOs[i].ProductId, result[i].ProductId);
        }
        Assert.Equal(expectedBrandDTOs, result);
        Assert.Equal(itemsPerPage, result.Count());
        _mockRepo.Verify(repo => repo.GetBrands(itemsPerPage, page), Times.Once);
        _mapper.Verify(m => m.Map<IEnumerable<BrandDTO>>(pagedBrands), Times.Once);
    }

}
