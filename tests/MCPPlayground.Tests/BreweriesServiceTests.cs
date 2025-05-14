using System.Security.Authentication.ExtendedProtection;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MCPPlayground.Tests;

[TestClass]
public sealed class BreweriesServiceTests
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task CanGetBreweries()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddHttpClient();
        var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();

        var service = new BreweriesService(factory);
        var expectedCount = 3;

        // Act
        var breweries = await service.GetBreweriesAsync();

        // Assert
        Assert.IsNotNull(breweries);
        Assert.AreEqual(expectedCount, breweries.Count);        
    }
}
