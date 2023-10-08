using Microsoft.AspNetCore.Mvc.Testing;

public class ProductControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ProductControllerShould(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/Product/products-by-category?categoryId=6");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}