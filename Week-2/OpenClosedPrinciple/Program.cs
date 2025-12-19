using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OPEN/CLOSED PRINCIPLE (OCP)");

            var shapes = new List<IShape>
            {
                new Rectangle { Width = 5, Height = 10 },
                new Circle { Radius = 7 },
                new Triangle { Base = 6, Height = 8 }
            };

            var calculator = new AreaCalculator();

            Console.WriteLine("Calculating areas for different shapes:\n");

            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape.GetName()}: Area = {shape.CalculateArea():F2}");
            }

            Console.WriteLine($"\nTotal Area: {calculator.CalculateTotalArea(shapes):F2}");
        }
    }
}
