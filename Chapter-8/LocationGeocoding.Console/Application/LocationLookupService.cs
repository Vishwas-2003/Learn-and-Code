using LocationGeocoding.Console.Domain;
using LocationGeocoding.Console.Constants;

namespace LocationGeocoding.Console.Application;

public sealed class LocationLookupService
{
    private readonly IGeocodingGateway _gateway;

    public LocationLookupService(IGeocodingGateway gateway)
    {
        _gateway = gateway;
    }

    public async Task<LocationLookupResponse> LookupAsync(string locationInput, CancellationToken cancellationToken)
    {
        var validationError = ValidateInput(locationInput);
        if (validationError is not null)
        {
            return LocationLookupResponse.Failure(validationError);
        }

        var sanitizedInput = locationInput.Trim();
        var gatewayResult = await _gateway.GetCoordinatesAsync(sanitizedInput, cancellationToken);

        if (!gatewayResult.IsSuccess)
        {
            return LocationLookupResponse.Failure(gatewayResult.ErrorMessage ?? AppConstants.UnknownGeocodingError);
        }

        if (gatewayResult.Results.Count == 0)
        {
            return LocationLookupResponse.Failure(AppConstants.NoLocationsFoundError);
        }

        return LocationLookupResponse.Success(gatewayResult.Results);
    }

    private static string? ValidateInput(string locationInput)
    {
        if (string.IsNullOrWhiteSpace(locationInput))
        {
            return AppConstants.EmptyLocationInputError;
        }

        if (locationInput.Trim().Length < 2)
        {
            return AppConstants.ShortLocationInputError;
        }

        return null;
    }
}

public sealed record LocationLookupResponse(
    bool IsSuccess,
    string? ErrorMessage,
    IReadOnlyList<GeoLocationResult> Results)
{
    public static LocationLookupResponse Success(IReadOnlyList<GeoLocationResult> results) =>
        new(true, null, results);

    public static LocationLookupResponse Failure(string errorMessage) =>
        new(false, errorMessage, Array.Empty<GeoLocationResult>());
}
