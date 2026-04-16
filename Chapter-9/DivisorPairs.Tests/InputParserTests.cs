using DivisorPairs.Console;

namespace DivisorPairs.Tests;

public sealed class InputParserTests
{
    private readonly InputParser _parser = new();

    [Fact]
    public void Parse_ReturnsAllKValues()
    {
        var lines = new List<string> { "3", "15", "3", "20" };

        var result = _parser.Parse(lines);

        Assert.Equal(new[] { 15, 3, 20 }, result);
    }

    [Fact]
    public void Parse_Throws_WhenLineCountDoesNotMatchTestCases()
    {
        var lines = new List<string> { "2", "10" };

        Assert.Throws<FormatException>(() => _parser.Parse(lines));
    }

    [Fact]
    public void Parse_Throws_WhenInputContainsInvalidInteger()
    {
        var lines = new List<string> { "1", "abc" };

        Assert.Throws<FormatException>(() => _parser.Parse(lines));
    }

    [Fact]
    public void Parse_Throws_WhenTestCaseCountIsNegative()
    {
        var lines = new List<string> { "-1" };

        Assert.Throws<FormatException>(() => _parser.Parse(lines));
    }
}
