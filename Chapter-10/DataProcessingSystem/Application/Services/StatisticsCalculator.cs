using DataProcessingSystem.Domain.Entities;

namespace DataProcessingSystem.Application.Services
{
    public class StatisticsCalculator
    {
        public ProcessingStatistics Calculate(IEnumerable<Record> records, int errorCount)
        {
            var list = records.ToList();

            return new ProcessingStatistics
            {
                TotalRecords = list.Count,
                ErrorCount = errorCount,
                TotalValue = list.Sum(r => r.Value),
                AverageValue = list.Any() ? list.Average(r => r.Value) : 0
            };
        }
    }

}
