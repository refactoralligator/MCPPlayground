using System.Text.Json.Serialization;
using MCPPlayground.Models;

namespace MCPPlayground.Serialization;

[JsonSerializable(typeof(List<Brewery>))]
public partial class BreweryContext : JsonSerializerContext { }
