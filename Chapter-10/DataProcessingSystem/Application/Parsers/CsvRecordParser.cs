using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;

namespace DataProcessingSystem.Application.Parsers
{
    public class CsvRecordParser : IParser<Record>
    {
        public Record Parse(string line)
        {
            var parts = line.Split(',');

            if (parts.Length < 3)
                throw new FormatException("Invalid CSV format");

            var id = parts[0].Trim();
            var name = parts[1].Trim();
            var value = double.Parse(parts[2].Trim());

            DateTime? date = null;
            if (parts.Length >= 4 && DateTime.TryParse(parts[3], out var parsedDate))
            {
                date = parsedDate;
            }

            return new Record(id, name, value, date);
        }
    }

}
