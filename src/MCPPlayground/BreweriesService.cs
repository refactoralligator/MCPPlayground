using System.Net.Http.Json;
using System.Text.Json.Serialization;

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
}


public partial class Brewery
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("brewery_type")]
    public string BreweryType { get; set; }
    [JsonPropertyName("address_1")]
    public string Address { get; set; }
    [JsonPropertyName("city")]
    public string City { get; set; }
    [JsonPropertyName("state_province")]
    public string StateProvince { get; set; }
    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    [JsonPropertyName("website_url")]
    public string WebsiteUrl { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; }
    [JsonPropertyName("street")]
    public string Street { get; set; }
}

[JsonSerializable(typeof(List<Brewery>))]
public partial class BreweryContext : JsonSerializerContext { }
