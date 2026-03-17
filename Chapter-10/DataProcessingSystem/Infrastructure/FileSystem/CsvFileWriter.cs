using DataProcessingSystem.Domain.Entities;

namespace DataProcessingSystem.Infrastructure.FileSystem
{
    public class CsvFileWriter : IFileWriter
    {
        public void Write(string path, IEnumerable<Record> records)
        {
            var lines = new List<string>
            {
                "ID,NAME,VALUE,DATE,DOUBLED_VALUE,SQUARED_VALUE"
            };

            foreach (var record in records)
            {
                lines.Add($"{record.Id},{record.Name},{record.Value},{record.Date:yyyy-MM-dd},{record.DoubledValue},{record.SquaredValue}");
            }

            File.WriteAllLines(path, lines);
        }
    }

}
