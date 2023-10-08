using Microsoft.AspNetCore.Mvc.Testing;

public class BrandControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public BrandControllerShould(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/brand/brands-by-product?productId=11");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}