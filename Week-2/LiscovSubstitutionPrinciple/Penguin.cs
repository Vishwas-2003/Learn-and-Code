using LiscovSubstitutionPrinciple.Interfaces;

namespace LiscovSubstitutionPrinciple
{
    public class Penguin : IBird
    {
        public string? Name { get; set; }
        public void Move()
        {
            Console.WriteLine($"{Name} is swimming in the water");
        }
    }
}
