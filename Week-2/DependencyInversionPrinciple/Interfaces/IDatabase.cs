namespace DependencyInversionPrinciple.Interfaces
{
    public interface IDatabase
    {
        void Save(string data);
        string GetName();
    }
}
