using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using GraphOfOrders.Lib.DTOs;

public class CustomerControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public CustomerControllerShould(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnSuccessStatusCode_WhenCreatingCustomer()
    {
        // Arrange
        var customer = new CreateCustomerDTO { Name = "Test", Email = "test@example.com" };

        // Act
        var response = await _client.PostAsJsonAsync("/customer", customer);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var createdCustomer = await response.Content.ReadFromJsonAsync<CustomerDTO>();
        Assert.NotNull(createdCustomer);
        Assert.Equal("Test", createdCustomer.Name);
        Assert.Equal("test@example.com", createdCustomer.Email);
    }

    [Fact]
    public async Task ReturnNotFound_WhenGettingNonExistentCustomer()
    {
        // Act
        var response = await _client.GetAsync("/customer/9999");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    // Add more tests as needed for other scenarios and edge cases
}
