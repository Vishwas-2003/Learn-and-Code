using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;
using DataProcessingSystem.Infrastructure.FileSystem;
using DataProcessingSystem.Infrastructure.Logging;

namespace DataProcessingSystem.Application.Services
{
    public class DataProcessor
    {
        private readonly IFileReader _reader;
        private readonly IFileWriter _writer;
        private readonly IParser<Record> _parser;
        private readonly IValidator<Record> _validator;
        private readonly ITransformer<Record> _transformer;
        private readonly StatisticsCalculator _statistics;
        private readonly ILogger _logger;

        public DataProcessor(
            IFileReader reader,
            IFileWriter writer,
            IParser<Record> parser,
            IValidator<Record> validator,
            ITransformer<Record> transformer,
            StatisticsCalculator statistics,
            ILogger logger)
        {
            _reader = reader;
            _writer = writer;
            _parser = parser;
            _validator = validator;
            _transformer = transformer;
            _statistics = statistics;
            _logger = logger;
        }

        public ProcessingStatistics Process(string inputPath, string outputPath)
        {
            _logger.Log("Processing started");

            var validRecords = new List<Record>();
            int errorCount = 0;

            foreach (var line in _reader.Read(inputPath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    var record = _parser.Parse(line);

                    if (_validator.IsValid(record, out var error))
                    {
                        record = _transformer.Transform(record);
                        validRecords.Add(record);
                    }
                    else
                    {
                        errorCount++;
                        _logger.Log(error);
                    }
                }
                catch (Exception ex)
                {
                    errorCount++;
                    _logger.Log(ex.Message);
                }
            }

            _writer.Write(outputPath, validRecords);

            var stats = _statistics.Calculate(validRecords, errorCount);
            stats.ProcessedRecords = validRecords;

            _logger.Log("Processing completed");

            return stats;
        }
    }

}
