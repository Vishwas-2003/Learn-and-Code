using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class HumanWorker : IWorkable, IEatable, ISleepable
    {
        public string? Name { get; set; }
        public void Work()
        {
            Console.WriteLine($"{Name} is working on tasks");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating lunch");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }
    }
}
