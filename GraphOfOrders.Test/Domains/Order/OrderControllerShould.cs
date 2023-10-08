using Microsoft.AspNetCore.Mvc.Testing;

public class OrderControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public OrderControllerShould(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/Order?brandId=77");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}