namespace DivisorPairs.Console;

public sealed class DivisorCountCalculator
{
    public int CountPositiveDivisors(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than zero.");
        }

        var divisorCount = 0;
        var limit = (int)Math.Sqrt(number);

        for (var divisor = 1; divisor <= limit; divisor++)
        {
            if (number % divisor != 0)
            {
                continue;
            }

            divisorCount += 2;

            if (divisor * divisor == number)
            {
                divisorCount--;
            }
        }

        return divisorCount;
    }
}
