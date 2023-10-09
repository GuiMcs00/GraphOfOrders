using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.Exceptions;
using Newtonsoft.Json;
using System.Text;

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
        var customer = new CustomerInputDTO { Name = "Test", Email = "test@example.com" };

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

    [Fact]
    public async Task Put_UpdateCustomer_ReturnsOkResult_WithUpdatedCustomer()
    {
        // Arrange
        var customerId = 1;
        var updateCustomerDto = new CustomerInputDTO { Name = "UpdatedName", Email = "updated@example.com" };
        var content = new StringContent(JsonConvert.SerializeObject(updateCustomerDto), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/customer/{customerId}", content);

        // Assert
        response.EnsureSuccessStatusCode();
        var returnedCustomer = JsonConvert.DeserializeObject<CustomerDTO>(await response.Content.ReadAsStringAsync());
        Assert.Equal("UpdatedName", returnedCustomer.Name);
        Assert.Equal("updated@example.com", returnedCustomer.Email);
    }

    [Fact]
    public async Task Put_UpdateCustomer_ReturnsNotFound_ForNonExistentCustomer()
    {
        // Arrange
        var nonExistentCustomerId = 9999;
        var updateCustomerDto = new CustomerInputDTO { Name = "UpdatedName", Email = "updated@example.com" };
        var content = new StringContent(JsonConvert.SerializeObject(updateCustomerDto), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/customer/{nonExistentCustomerId}", content);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }


}
