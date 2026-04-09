using LocationGeocoding.Console.Constants;

namespace LocationGeocoding.Console.Infrastructure;

public sealed class GeocodingApiOptions
{
    public const string SectionName = AppConstants.GoogleGeocodingSectionName;

    public string BaseUrl { get; init; } = AppConstants.GoogleGeocodeBaseUrl;

    public string ApiKey { get; init; } = string.Empty;
}
