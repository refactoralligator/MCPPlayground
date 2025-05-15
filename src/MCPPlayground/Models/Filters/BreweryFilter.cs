using MCPPlayground.Utils;

namespace MCPPlayground.Models.Filters;

public class BreweryFilter
{
    [QueryName("by_name")]
    public string? Name { get; set; }
    [QueryName("by_city")]
    public string? City { get; set; }
    [QueryName("by_state")]
    public string? State { get; set; }
    [QueryName("by_type")]
    public string? Type { get; set; }
    [QueryName("by_postal")]
    public string? PostalCode { get; set; }
    [QueryName("by_country")]
    public string? Country { get; set; }
    //public double? Longitude { get; set; } //todo by_dist GET https://api.openbrewerydb.org/v1/breweries?by_dist=32.88313237,-117.1649842&per_page=3
    //public double? Latitude { get; set; } //todo
}
