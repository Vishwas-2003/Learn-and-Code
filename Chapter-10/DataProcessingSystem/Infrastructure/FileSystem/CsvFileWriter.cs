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

            foreach (var r in records)
            {
                lines.Add($"{r.Id},{r.Name},{r.Value},{r.Date:yyyy-MM-dd},{r.DoubledValue},{r.SquaredValue}");
            }

            File.WriteAllLines(path, lines);
        }
    }

}
