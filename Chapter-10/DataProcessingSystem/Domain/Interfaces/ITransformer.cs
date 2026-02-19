namespace DataProcessingSystem.Domain.Interfaces
{
    public interface ITransformer<T>
    {
        T Transform(T item);
    }
}
