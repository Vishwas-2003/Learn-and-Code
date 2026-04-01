using System;
using System.IO;

Console.WriteLine("Try-Finally without Catch example");

var temporaryFilePath = Path.Combine(
    Path.GetTempPath(),
    $"sample-log-{Guid.NewGuid():N}.txt");

Console.WriteLine($"Temporary file: {temporaryFilePath}");

WriteLogEntryAndAlwaysCleanup(temporaryFilePath);

static void WriteLogEntryAndAlwaysCleanup(string filePath)
{
    StreamWriter? logWriter = null;

    try
    {
        logWriter = new StreamWriter(filePath);
        logWriter.WriteLine("Application started.");

        throw new InvalidOperationException("Simulated write failure.");
    }
    finally
    {
        logWriter?.Dispose();
        SafeDeleteFile(filePath);
        Console.WriteLine("Cleanup completed in finally block.");
    }
}

static void SafeDeleteFile(string filePath)
{
    if (!File.Exists(filePath))
    {
        return;
    }

    File.Delete(filePath);
}
