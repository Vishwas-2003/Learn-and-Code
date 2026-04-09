namespace LocationGeocoding.Console.Domain;

public sealed record GeoLocationResult(
    string FormattedAddress,
    double Latitude,
    double Longitude);
