using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class RobotWorker : IWorkable
    {
        public string? Name { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working 24/7 without breaks");
        }
    }
}
