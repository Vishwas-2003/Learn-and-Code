using DivisorPairs.Console;

namespace DivisorPairs.Tests;

public sealed class ConsecutiveDivisorPairCounterTests
{
    private readonly ConsecutiveDivisorPairCounter _counter = new(new DivisorCountCalculator());

    [Theory]
    [InlineData(2, 0)]
    [InlineData(3, 1)]
    [InlineData(15, 2)]
    public void CountValidValues_ReturnsExpectedResult(int upperBoundExclusive, int expected)
    {
        var result = _counter.CountValidValues(upperBoundExclusive);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountValidValues_Throws_WhenUpperBoundIsNonPositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _counter.CountValidValues(-5));
    }
}
