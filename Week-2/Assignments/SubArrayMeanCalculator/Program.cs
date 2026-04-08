namespace SubArrayMeanCalculator{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size and number of queries:\n");
            var input = Console.ReadLine()?.Split(' ')
                                          .Select(int.Parse)
                                          .ToArray();

            int arraySize = input[0];
            int queryCount = input[1];

            Console.WriteLine("Enter numbers:\n");
            long[]? numbers = Console.ReadLine()?
                             .Split(' ')
                             .Select(long.Parse)
                             .ToArray();

            long[] prefixSum = BuildPrefixSum(numbers);

            ProcessQueries(queryCount, prefixSum);
        }

        private static long[] BuildPrefixSum(long[]? numbers)
        {
            int arrayLength = numbers.Length;
            long[] prefixSum = new long[arrayLength + 1];
            prefixSum[0] = 0;

            for (int index = 1; index <= arrayLength; index++)
            {
                prefixSum[index] = prefixSum[index - 1] + numbers[index - 1];
            }

            return prefixSum;
        }

        private static void ProcessQueries(int queryCount, long[] prefixSum)
        {
            for (int query = 0; query < queryCount; query++)
            {
                Console.WriteLine("Enter query range (left right):");
                var range = Console.ReadLine()?.Split(' ')
                                               .Select(int.Parse)
                                               .ToArray();

                int left = range[0];
                int right = range[1];

                long average = CalculateRangeAverage(prefixSum, left, right);
                Console.WriteLine(average);
            }
        }

        private static long CalculateRangeAverage(long[] prefixSum, int left, int right)
        {
            long rangeSum = prefixSum[right] - prefixSum[left - 1];
            int rangeLength = right - left + 1;

            return rangeSum / rangeLength;
        }
    }
}
