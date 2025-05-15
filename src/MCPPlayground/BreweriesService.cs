using System.Net.Http.Json;
using MCPPlayground.Models;
using MCPPlayground.Serialization;

namespace MCPPlayground;

public class BreweriesService
{
    private readonly HttpClient httpClient;
    public BreweriesService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    public async Task<List<Brewery>> GetBreweriesAsync(int numberOfBreweries)
    {
        var response = await httpClient.GetAsync($"https://api.openbrewerydb.org/v1/breweries?per_page={numberOfBreweries}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to fetch breweries");
        }

        List<Brewery> breweries = await response.Content.ReadFromJsonAsync(BreweryContext.Default.ListBrewery) ?? [];

        return breweries;
    }

    public async Task<List<Brewery>> GetBreweriesInCityAsync(string city, int numberOfBreweries)
    {
        var response = await httpClient.GetAsync($"https://api.openbrewerydb.org/v1/breweries?by_city={city}&per_page={numberOfBreweries}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to fetch breweries");
        }

        List<Brewery> breweries = await response.Content.ReadFromJsonAsync(BreweryContext.Default.ListBrewery) ?? [];

        return breweries;
    }



