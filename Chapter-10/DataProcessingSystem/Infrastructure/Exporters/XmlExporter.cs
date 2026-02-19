using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;
using System.Xml.Serialization;

namespace DataProcessingSystem.Infrastructure.Exporters
{
    public class XmlExporter : IExporter
    {
        public void Export(IEnumerable<Record> records, string path)
        {
            var serializer = new XmlSerializer(typeof(List<Record>));

            using var writer = new StreamWriter(path);
            serializer.Serialize(writer, records.ToList());
        }
    }

}
