using DependencyInversionPrinciple.Interfaces;

namespace DependencyInversionPrinciple
{
    public class DataService
    {
        private readonly IDatabase _database;

        public DataService(IDatabase database)
        {
            _database = database;
        }

        public void SaveData(string data)
        {
            Console.WriteLine($"Using {_database.GetName()}");
            _database.Save(data);
        }
    }
}
