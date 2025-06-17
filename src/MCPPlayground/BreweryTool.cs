using System.ComponentModel;
using System.Text.Json;
using MCPPlayground.Models.Filters;
using ModelContextProtocol.Server;

namespace MCPPlayground;

[McpServerToolType]
public static class BreweryTool
{
    [McpServerTool, Description("Get a number of breweries. Default is 3")]
    public static async Task<string> GetBreweries(BreweriesService breweriesService, 
        int numberOfBreweries = 3)
    {
        var breweries = await breweriesService.GetBreweriesAsync(numberOfBreweries);
        return JsonSerializer.Serialize(breweries);
    }

    [McpServerTool, Description("Get a number of breweries in a specified city.")]
    public static async Task<string> GetBreweriesInCity(BreweriesService breweriesService,
        string city, int numberOfBreweries = 3)
    {
        var breweries = await breweriesService.GetBreweriesInCityAsync(city, numberOfBreweries);
        return JsonSerializer.Serialize(breweries);
    }

    [McpServerTool, Description("Get a number of breweries, based on properties")]
    public static async Task<string> GetBreweriesWithFilter(BreweriesService breweriesService,
        BreweryFilter filter)
    {
        var breweries = await breweriesService.GetBreweriesWithFilterAsync(filter);
        return JsonSerializer.Serialize(breweries);
    }
}
