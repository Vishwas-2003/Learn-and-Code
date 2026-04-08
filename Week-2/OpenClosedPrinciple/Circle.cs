using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public string GetName()
        {
            return $"Circle (radius={Radius})";
        }
    }
}
