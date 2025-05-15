using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
}
