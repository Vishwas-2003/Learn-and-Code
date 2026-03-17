using DataProcessingSystem.Domain.Entities;

namespace DataProcessingSystem.Infrastructure.FileSystem
{
    public interface IFileWriter
    {
        void Write(string path, IEnumerable<Record> records);
    }
}
