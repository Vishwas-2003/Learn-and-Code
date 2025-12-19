namespace GuessNumber{
    class Program
    {        
        private const int MinValue = 1;
        private const int MaxValue = 100;
        static void Main()
        {
            int targetNumber = GenerateRandomNumber();
            int guessCount = 0;

            Console.Write($"Guess a number between {MinValue} and {MaxValue}: ");
            string input = Console.ReadLine();

            while (true)
            {
                if (!IsValidGuess(input, out int guess))
                {
                    Console.Write($"Invalid input. Please enter a number between {MinValue} and {MaxValue}: ");
                    input = Console.ReadLine();
                    continue;
                }

                guessCount++;

                if (guess == targetNumber)
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                    break;
                }

                input = PromptNextGuess(guess, targetNumber);
            }
        }
        private static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(MinValue, MaxValue + 1);
        }

        private static bool IsValidGuess(string input, out int guess)
        {
            if (int.TryParse(input, out guess))
            {
                return guess >= MinValue && guess <= MaxValue;
            }
            return false;
        }

        private static string PromptNextGuess(int guess, int target)
        {
            if (guess < target)
            {
                Console.Write("Too low. Guess again: ");
            }
            else
            {
                Console.Write("Too high. Guess again: ");
            }

            return Console.ReadLine();
        }
    }
}
