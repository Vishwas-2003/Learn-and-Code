using DivisorPairs.Console;

var inputLines = new List<string>();
string? line;

while ((line = Console.ReadLine()) is not null)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        continue;
    }

    inputLines.Add(line.Trim());
}

if (inputLines.Count == 0)
{
    return;
}

var parser = new InputParser();
var values = parser.Parse(inputLines);

var calculator = new DivisorCountCalculator();
var counter = new ConsecutiveDivisorPairCounter(calculator);
var solver = new ProblemSolver(counter);
var results = solver.Solve(values);

foreach (var result in results)
{
    Console.WriteLine(result);
}
