namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INTERFACE SEGREGATION PRINCIPLE (ISP)");

            Console.WriteLine("Human Worker Activities:");
            var human = new HumanWorker { Name = "Vishwas" };
            human.Work();
            human.Eat();
            human.Sleep();

            Console.WriteLine("\nRobot Worker Activities:");
            var robot = new RobotWorker { Name = "Chitti" };
            robot.Work();
        }
    }
}
