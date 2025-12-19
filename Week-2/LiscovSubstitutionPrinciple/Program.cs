using LiscovSubstitutionPrinciple.Interfaces;

namespace LiscovSubstitutionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LISKOV SUBSTITUTION PRINCIPLE (LSP)");

            List<IBird> IBirds = new List<IBird>
            {
                new Sparrow { Name = "Sparrow" },
                new Penguin { Name = "Penguin" },
                new Eagle { Name = "Eagle" }
            };

            Console.WriteLine("All Birds can move:\n");

            foreach (var IBird in IBirds)
            {
                IBird.Move();
            }
        }
    }
}
