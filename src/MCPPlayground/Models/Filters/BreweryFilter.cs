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
}
