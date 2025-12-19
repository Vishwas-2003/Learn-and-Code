using DependencyInversionPrinciple.Interfaces;

namespace DependencyInversionPrinciple
{
    public class MySqlDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to MySQL: {data}");
        }

        public string GetName()
        {
            return "MySQL Database";
        }
    }
}
