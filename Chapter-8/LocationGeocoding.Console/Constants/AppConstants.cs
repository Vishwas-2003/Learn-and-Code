namespace LocationGeocoding.Console.Constants;

public static class AppConstants
{
    public const string GoogleGeocodingSectionName = "GoogleGeocoding";
    public const string GoogleGeocodeBaseUrl = "https://maps.googleapis.com/maps/api/geocode/json";
    public const string GoogleStatusOk = "OK";
    public const string GoogleStatusZeroResults = "ZERO_RESULTS";

    public const string ExitCommand = "exit";
    public const string ConsolePrompt = "Enter location name (or type 'exit'): ";
    public const string ConsoleGoodbyeMessage = "Goodbye.";
    public const string ConsoleHeaderTitle = "Google Geocoding Lookup";
    public const string ConsoleHeaderSeparator = "-----------------------";
    public const string ConsoleErrorPrefix = "Error: ";

    public const string MissingApiKeyError = "Missing Google Geocoding API key in configuration.";
    public const string RateLimitExceededError = "Rate limit exceeded. Please try again later.";
    public const string ParseResponseError = "Unable to parse geocoding response.";
    public const string UnknownAddressLabel = "Unknown";
    public const string UnknownGeocodingError = "Unknown geocoding error.";
    public const string NoLocationsFoundError = "No locations found for the given input.";
    public const string EmptyLocationInputError = "Location name cannot be empty.";
    public const string ShortLocationInputError = "Location name must contain at least 2 characters.";
}
