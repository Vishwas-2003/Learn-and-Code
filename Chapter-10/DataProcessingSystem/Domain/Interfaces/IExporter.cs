using DataProcessingSystem.Domain.Entities;

namespace DataProcessingSystem.Domain.Interfaces
{
    public interface IExporter
    {
        void Export(IEnumerable<Record> records, string path);
    }
}
