using System.Text.Json.Serialization;

namespace LocationGeocoding.Console.Infrastructure.Models;

public sealed class GoogleGeocodeItem
{
    [JsonPropertyName("formatted_address")]
    public string? FormattedAddress { get; init; }

    [JsonPropertyName("geometry")]
    public GoogleGeometry? Geometry { get; init; }
}