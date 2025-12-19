using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple
{
    public class AreaCalculator
    {
        public double CalculateTotalArea(List<IShape> shapes)
        {
            double total = 0;
            foreach (var shape in shapes)
            {
                total += shape.CalculateArea();
            }
            return total;
        }
    }
}
