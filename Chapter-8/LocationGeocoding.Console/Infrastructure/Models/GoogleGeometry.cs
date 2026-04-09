using System.Text.Json.Serialization;

namespace LocationGeocoding.Console.Infrastructure.Models;

public sealed class GoogleGeometry
{
    [JsonPropertyName("location")]
    public GoogleCoordinates? Location { get; init; }
}