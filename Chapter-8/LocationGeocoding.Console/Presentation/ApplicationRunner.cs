using System.Text.Json;
using LocationGeocoding.Console.Application;
using LocationGeocoding.Console.Constants;

namespace LocationGeocoding.Console.Presentation;

public sealed class ApplicationRunner
{
    private readonly LocationLookupService _lookupService;

    public ApplicationRunner(LocationLookupService lookupService)
    {
        _lookupService = lookupService;
    }

    public async Task RunAsync()
    {
        WriteHeader();

        while (true)
        {
            System.Console.Write(AppConstants.ConsolePrompt);
            var input = System.Console.ReadLine();

            if (string.Equals(input?.Trim(), AppConstants.ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine(AppConstants.ConsoleGoodbyeMessage);
                return;
            }

            var response = await _lookupService.LookupAsync(input ?? string.Empty, CancellationToken.None);
            WriteResponse(response);
            System.Console.WriteLine();
        }
    }

    private static void WriteHeader()
    {
        System.Console.WriteLine(AppConstants.ConsoleHeaderTitle);
        System.Console.WriteLine(AppConstants.ConsoleHeaderSeparator);
    }

    private static void WriteResponse(LocationLookupResponse response)
    {
        if (!response.IsSuccess)
        {
            System.Console.WriteLine($"{AppConstants.ConsoleErrorPrefix}{response.ErrorMessage}");
            return;
        }

        var output = new
        {
            totalResults = response.Results.Count,
            locations = response.Results.Select(static x => new
            {
                address = x.FormattedAddress,
                latitude = x.Latitude,
                longitude = x.Longitude
            })
        };

        var json = JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = true });
        System.Console.WriteLine(json);
    }
}
