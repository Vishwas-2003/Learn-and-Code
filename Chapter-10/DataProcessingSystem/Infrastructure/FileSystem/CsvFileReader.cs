namespace DataProcessingSystem.Infrastructure.FileSystem
{
    public class CsvFileReader : IFileReader
    {
        public IEnumerable<string> Read(string path)
        {
            return File.ReadLines(path);
        }
    }

}
