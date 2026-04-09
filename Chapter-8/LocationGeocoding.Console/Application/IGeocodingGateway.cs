using LocationGeocoding.Console.Domain;

namespace LocationGeocoding.Console.Application;

public interface IGeocodingGateway
{
    Task<GeocodingGatewayResult> GetCoordinatesAsync(string locationName, CancellationToken cancellationToken);
}

public sealed record GeocodingGatewayResult(
    bool IsSuccess,
    string? ErrorMessage,
    IReadOnlyList<GeoLocationResult> Results);
