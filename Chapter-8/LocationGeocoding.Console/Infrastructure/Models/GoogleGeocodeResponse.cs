using System.Text.Json.Serialization;

namespace LocationGeocoding.Console.Infrastructure.Models;

public sealed class GoogleGeocodeResponse
{
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; init; }

    [JsonPropertyName("results")]
    public List<GoogleGeocodeItem>? Results { get; init; }
}