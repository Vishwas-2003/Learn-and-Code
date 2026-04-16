using DivisorPairs.Console;

Console.WriteLine("Enter input using this format:");
Console.WriteLine("First line: number of test cases");
Console.WriteLine("Next lines: one upper bound per test case");
Console.WriteLine("Example:");
Console.WriteLine("1");
Console.WriteLine("15");
Console.WriteLine();

var inputLines = new List<string>();
var firstLine = Console.ReadLine();

if (string.IsNullOrWhiteSpace(firstLine))
{
    Console.WriteLine("Input was empty. Please provide at least one test case.");
    return;
}

inputLines.Add(firstLine.Trim());

if (!int.TryParse(firstLine, out var testCaseCount))
{
    Console.WriteLine("Invalid first line. Please enter a valid integer for test case count.");
    return;
}

if (testCaseCount < 0)
{
    Console.WriteLine("Test case count cannot be negative.");
    return;
}

for (var testCaseIndex = 0; testCaseIndex < testCaseCount; testCaseIndex++)
{
    var testCaseLine = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(testCaseLine))
    {
        Console.WriteLine("Missing test case value. Please provide one upper bound per test case.");
        return;
    }

    inputLines.Add(testCaseLine.Trim());
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
