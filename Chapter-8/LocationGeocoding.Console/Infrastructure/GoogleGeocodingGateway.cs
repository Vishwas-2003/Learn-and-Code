using System.Net;
using System.Text.Json;
using LocationGeocoding.Console.Application;
using LocationGeocoding.Console.Constants;
using LocationGeocoding.Console.Domain;
using LocationGeocoding.Console.Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace LocationGeocoding.Console.Infrastructure;

public sealed class GoogleGeocodingGateway : IGeocodingGateway
{
    private readonly HttpClient _httpClient;
    private readonly GeocodingApiOptions _options;

    public GoogleGeocodingGateway(HttpClient httpClient, IOptions<GeocodingApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<GeocodingGatewayResult> GetCoordinatesAsync(string locationName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            return new GeocodingGatewayResult(false, AppConstants.MissingApiKeyError, Array.Empty<GeoLocationResult>());
        }

        var requestUrl = BuildRequestUrl(locationName);
        using var response = await _httpClient.GetAsync(requestUrl, cancellationToken);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            return new GeocodingGatewayResult(false, AppConstants.RateLimitExceededError, Array.Empty<GeoLocationResult>());
        }

        if (!response.IsSuccessStatusCode)
        {
            return new GeocodingGatewayResult(
                false,
                $"Google API request failed with status code {(int)response.StatusCode}.",
                Array.Empty<GeoLocationResult>());
        }

        await using var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var apiResponse = await JsonSerializer.DeserializeAsync<GoogleGeocodeResponse>(
            contentStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
            cancellationToken);

        if (apiResponse is null)
        {
            return new GeocodingGatewayResult(false, AppConstants.ParseResponseError, Array.Empty<GeoLocationResult>());
        }

        if (!string.Equals(apiResponse.Status, AppConstants.GoogleStatusOk, StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(apiResponse.Status, AppConstants.GoogleStatusZeroResults, StringComparison.OrdinalIgnoreCase))
        {
            var errorMessage = string.IsNullOrWhiteSpace(apiResponse.ErrorMessage)
                ? $"Google API returned status '{apiResponse.Status}'."
                : apiResponse.ErrorMessage;

            return new GeocodingGatewayResult(false, errorMessage, Array.Empty<GeoLocationResult>());
        }

        var results = (apiResponse.Results ?? new List<GoogleGeocodeItem>())
            .Where(static x => x.Geometry?.Location is not null)
            .Select(static x => new GeoLocationResult(
                x.FormattedAddress ?? AppConstants.UnknownAddressLabel,
                x.Geometry!.Location!.Lat,
                x.Geometry.Location.Lng))
            .ToList();

        return new GeocodingGatewayResult(true, null, results);
    }

    private string BuildRequestUrl(string locationName)
    {
        var encodedAddress = Uri.EscapeDataString(locationName);
        return $"{_options.BaseUrl}?address={encodedAddress}&key={_options.ApiKey}";
    }
}
