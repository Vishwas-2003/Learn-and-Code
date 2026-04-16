namespace DivisorPairs.Console;

public sealed class ProblemSolver
{
    private readonly ConsecutiveDivisorPairCounter _counter;

    public ProblemSolver(ConsecutiveDivisorPairCounter counter)
    {
        _counter = counter ?? throw new ArgumentNullException(nameof(counter));
    }

    public IReadOnlyList<int> Solve(IReadOnlyList<int> values)
    {
        var results = new List<int>(values.Count);

        foreach (var value in values)
        {
            results.Add(_counter.CountValidValues(value));
        }

        return results;
    }
}
