namespace DataProcessingSystem.Domain.Interfaces
{
    public interface IParser<T>
    {
        T Parse(string line);
    }
}
