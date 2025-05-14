using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ModelContextProtocol.Server;

namespace MCPPlayground;

[McpServerToolType]
public static class BreweryTool
{
    [McpServerTool, Description("Get 3 breweries")]
    public static async Task<string> GetBreweries(BreweriesService breweriesService)
    {
        var breweries = await breweriesService.GetBreweriesAsync();
        return JsonSerializer.Serialize(breweries);
    }
}
