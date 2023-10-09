using Moq;
using AutoMapper;
using GraphOfOrders.Service;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.Entities;

public class CustomerServiceShould
{
    private readonly Mock<ICustomerRepository> _mockRepo;
    private readonly CustomerService _service;
    private readonly Mock<IMapper> _mockMapper;

    public CustomerServiceShould()
    {
        _mockRepo = new Mock<ICustomerRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockMapper.Setup(m => m.Map<Customer>(It.IsAny<CreateCustomerDTO>()))
                    .Returns((CreateCustomerDTO source) => new Customer
                    {
                        CustomerId = 1, // You might want to set this to a specific value for testing
                        Name = source.Name,
                        Email = source.Email
                    });

        _mockMapper.Setup(m => m.Map<CustomerDTO>(It.IsAny<Customer>()))
                    .Returns((Customer source) => new CustomerDTO
                    {
                        CustomerId = source.CustomerId,
                        Name = source.Name,
                        Email = source.Email
                    });
        _service = new CustomerService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task ReturnCustomerDTO_WhenCreatingCustomer()
    {
        // Arrange
        var customer = new Customer { CustomerId = 1, Name = "Test", Email = "test@example.com" };
        var createCustomer = new CreateCustomerDTO { Name = "Test", Email = "test@example.com" };
        var expected = new CustomerDTO { CustomerId = 1, Name = "Test", Email = "test@example.com" };

        _mockRepo.Setup(repo => repo.CreateCustomer(It.IsAny<Customer>())).ReturnsAsync(customer);

        // Act
        var result = await _service.CreateCustomer(createCustomer);

        // Assert
        Assert.Equal(expected.CustomerId, result.CustomerId);
        Assert.Equal(expected.Name, result.Name);
        Assert.Equal(expected.Email, result.Email);
        _mockRepo.Verify(repo => repo.CreateCustomer(It.IsAny<Customer>()), Times.Once);
    }

}
