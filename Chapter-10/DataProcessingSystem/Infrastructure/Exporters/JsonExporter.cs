using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;

namespace DataProcessingSystem.Infrastructure.Exporters
{
    public class JsonExporter : IExporter
    {
        public void Export(IEnumerable<Record> records, string path)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(records,
                new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(path, json);
        }
    }

}
