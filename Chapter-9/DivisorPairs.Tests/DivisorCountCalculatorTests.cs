using DivisorPairs.Console;

namespace DivisorPairs.Tests;

public sealed class DivisorCountCalculatorTests
{
    private readonly DivisorCountCalculator _calculator = new();

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(14, 4)]
    [InlineData(16, 5)]
    public void CountPositiveDivisors_ReturnsExpectedCount(int number, int expected)
    {
        var result = _calculator.CountPositiveDivisors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountPositiveDivisors_Throws_WhenNumberIsNonPositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CountPositiveDivisors(0));
    }
}
