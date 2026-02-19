using DataProcessingSystem.Application.Parsers;
using DataProcessingSystem.Application.Services;
using DataProcessingSystem.Application.Transformers;
using DataProcessingSystem.Application.Validators;
using DataProcessingSystem.Domain.Interfaces;
using DataProcessingSystem.Infrastructure.Exporters;
using DataProcessingSystem.Infrastructure.FileSystem;
using DataProcessingSystem.Infrastructure.Logging;

namespace DataProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var inputPath = Path.Combine(basePath, "SampleData", "input.csv");
            var outputCsvPath = Path.Combine(basePath, "SampleData", "output.csv");
            var outputJsonPath = Path.Combine(basePath, "SampleData", "output.json");

            var processor = new DataProcessor(
                new CsvFileReader(),
                new CsvFileWriter(),
                new CsvRecordParser(),
                new RecordValidator(),
                new RecordTransformer(),
                new StatisticsCalculator(),
                new ConsoleLogger()
            );

            var result = processor.Process(inputPath, outputCsvPath);

            Console.WriteLine("\n=== Statistics ===");
            Console.WriteLine($"Total Records: {result.TotalRecords}");
            Console.WriteLine($"Errors: {result.ErrorCount}");
            Console.WriteLine($"Total Value: {result.TotalValue}");
            Console.WriteLine($"Average Value: {result.AverageValue}");

            IExporter jsonExporter = new JsonExporter();
            jsonExporter.Export(result.ProcessedRecords, outputJsonPath);

            Console.WriteLine("\nJSON export completed.");
        }
    }
}
