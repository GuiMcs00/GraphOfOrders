using Microsoft.AspNetCore.Mvc.Testing;

public class CategoryControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public CategoryControllerShould(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/category/categories");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}