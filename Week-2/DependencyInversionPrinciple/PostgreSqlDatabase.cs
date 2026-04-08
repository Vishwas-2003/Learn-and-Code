using DependencyInversionPrinciple.Interfaces;

namespace DependencyInversionPrinciple
{
    public class PostgreSqlDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to PostgreSQL: {data}");
        }

        public string GetName()
        {
            return "PostgreSQL Database";
        }
    }
}
