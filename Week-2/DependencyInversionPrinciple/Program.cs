namespace DependencyInversionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DEPENDENCY INVERSION PRINCIPLE (DIP)");

            Console.WriteLine("Switching databases without changing DataService:\n");

            var mysqlService = new DataService(new MySqlDatabase());
            mysqlService.SaveData("User Registration Data");

            Console.WriteLine();

            var postgresService = new DataService(new PostgreSqlDatabase());
            postgresService.SaveData("Order Transaction Data");

            Console.WriteLine();

            var mongoService = new DataService(new MongoDatabase());
            mongoService.SaveData("Application Log Data");
        }
    }
}