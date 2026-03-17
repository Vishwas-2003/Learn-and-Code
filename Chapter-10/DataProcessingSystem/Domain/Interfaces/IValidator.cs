namespace DataProcessingSystem.Domain.Interfaces
{
    public interface IValidator<T>
    {
        bool IsValid(T item, out string errorMessage);
    }
}
