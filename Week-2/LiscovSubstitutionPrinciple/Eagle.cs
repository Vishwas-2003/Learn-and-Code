using LiscovSubstitutionPrinciple.Interfaces;

namespace LiscovSubstitutionPrinciple
{
    public class Eagle : IBird
    {
        public string? Name { get; set; }
        public void Move()
        {
            Console.WriteLine($"{Name} is soaring high in the sky");
        }
    }
}
