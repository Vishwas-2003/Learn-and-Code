namespace DivisorPairs.Console;

public sealed class ConsecutiveDivisorPairCounter
{
    private readonly DivisorCountCalculator _divisorCountCalculator;

    public ConsecutiveDivisorPairCounter(DivisorCountCalculator divisorCountCalculator)
    {
        _divisorCountCalculator = divisorCountCalculator ?? throw new ArgumentNullException(nameof(divisorCountCalculator));
    }

    public int CountValidValues(int upperBoundExclusive)
    {
        if (upperBoundExclusive <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(upperBoundExclusive), "Upper bound must be greater than zero.");
        }

        if (upperBoundExclusive <= 2)
        {
            return 0;
        }

        var validCount = 0;

        for (var candidateNumber = 2; candidateNumber < upperBoundExclusive; candidateNumber++)
        {
            var currentDivisorCount = _divisorCountCalculator.CountPositiveDivisors(candidateNumber);
            var nextDivisorCount = _divisorCountCalculator.CountPositiveDivisors(candidateNumber + 1);

            if (currentDivisorCount == nextDivisorCount)
            {
                validCount++;
            }
        }

        return validCount;
    }
}
