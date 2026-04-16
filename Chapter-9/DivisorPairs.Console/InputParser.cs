namespace DivisorPairs.Console;

public sealed class InputParser
{
    public IReadOnlyList<int> Parse(IReadOnlyList<string> lines)
    {
        if (lines.Count == 0)
        {
            throw new ArgumentException("Input is empty.", nameof(lines));
        }

        if (!int.TryParse(lines[0], out var testCaseCount))
        {
            throw new FormatException("The first line must be an integer.");
        }

        if (testCaseCount < 0)
        {
            throw new FormatException("The number of test cases cannot be negative.");
        }

        if (lines.Count != testCaseCount + 1)
        {
            throw new FormatException("The number of upper bound values does not match the test case count.");
        }

        var upperBoundValues = new List<int>(testCaseCount);

        for (var index = 1; index <= testCaseCount; index++)
        {
            if (!int.TryParse(lines[index], out var upperBoundExclusive))
            {
                throw new FormatException($"Invalid integer at line {index + 1}.");
            }

            upperBoundValues.Add(upperBoundExclusive);
        }

        return upperBoundValues;
    }
}
