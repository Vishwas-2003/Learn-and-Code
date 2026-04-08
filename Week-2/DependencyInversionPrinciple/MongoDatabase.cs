using DependencyInversionPrinciple.Interfaces;

namespace DependencyInversionPrinciple
{
    public class MongoDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to MongoDB: {data}");
        }

        public string GetName()
        {
            return "MongoDB Database";
        }
    }
}
