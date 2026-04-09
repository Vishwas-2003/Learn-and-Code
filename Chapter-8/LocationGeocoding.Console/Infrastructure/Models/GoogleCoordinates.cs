using System.Text.Json.Serialization;

namespace LocationGeocoding.Console.Infrastructure.Models;

public sealed class GoogleCoordinates
{
    [JsonPropertyName("lat")]
    public double Lat { get; init; }

    [JsonPropertyName("lng")]
    public double Lng { get; init; }
}