namespace DataProcessingSystem.Infrastructure.FileSystem
{
    public interface IFileReader
    {
        IEnumerable<string> Read(string path);
    }
}
