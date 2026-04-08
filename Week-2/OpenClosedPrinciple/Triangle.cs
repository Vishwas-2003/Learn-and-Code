using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }

        public string GetName()
        {
            return $"Triangle (base={Base}, height={Height})";
        }
    }
}
