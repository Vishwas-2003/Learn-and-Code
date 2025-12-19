using LiscovSubstitutionPrinciple.Interfaces;

namespace LiscovSubstitutionPrinciple
{
    public class Sparrow : IBird
    {
        public string? Name { get; set; }
        public void Move()
        {
            Console.WriteLine($"{Name} is flying through the air");
        }
    }
}
