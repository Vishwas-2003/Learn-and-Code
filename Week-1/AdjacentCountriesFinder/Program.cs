namespace CountryCodeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Country Code to Adjacent Countries\n");

            while (true)
            {
                Console.Write("Enter a country code (e.g., IN, CN, PK) or 'EXIT' to quit: ");
                string input = Console.ReadLine()?.ToUpper().Trim();

                if (input == "EXIT")
                {
                    Console.WriteLine("EXITED...");
                    break;
                }

                if (ValidateInput(input))
                {
                    PrintAdjacentCountries(input);
                }
            }
        }

        private static bool ValidateInput(string countryCode)
        {
            if (countryCode.Length != 2)
            {
                Console.WriteLine("Invalid input! Country code must be exactly 2 characters.\n");
                return false;
            }

            if (!IsOnlyLetters(countryCode))
            {
                Console.WriteLine("Invalid input! Country code must contain only letters (A-Z).\n");
                return false;
            }

            return true;
        }

        private static bool IsOnlyLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        private static void PrintAdjacentCountries(string countryCode)
        {
            var countries = GetCountriesData();

            if (!countries.ContainsKey(countryCode))
            {
                Console.WriteLine($"Country code '{countryCode}' not found.\n");
                return;
            }

            var countryData = countries[countryCode];

            Console.WriteLine($"\nCountry : {countryData.CountryName}");
            Console.WriteLine("Adjacent Countries:");

            if (countryData.AdjacentCountries.Count == 0)
            {
                Console.WriteLine("No adjacent country found\n");
            }
            else
            {
                foreach (var country in countryData.AdjacentCountries)
                    Console.WriteLine($"{country}");
                Console.WriteLine();
            }
        }

        private static Dictionary<string, CountryInfo> GetCountriesData()
        {
            return new Dictionary<string, CountryInfo>
            {
                { "IN", new CountryInfo {
                        CountryName = "India",
                        AdjacentCountries = new List<string> { "Pakistan", "China", "Nepal", "Bangladesh" }
                }},
                { "PK", new CountryInfo {
                        CountryName = "Pakistan",
                        AdjacentCountries = new List<string> { "India", "China" }
                }},
                { "CN", new CountryInfo {
                        CountryName = "China",
                        AdjacentCountries = new List<string> { "India", "Pakistan", "Nepal", "Mongolia" }
                }},
                { "NP", new CountryInfo {
                        CountryName = "Nepal",
                        AdjacentCountries = new List<string> { "India", "China" }
                }},
                { "BD", new CountryInfo {
                        CountryName = "Bangladesh",
                        AdjacentCountries = new List<string> { "India", "Myanmar" }
                }},
                { "MM", new CountryInfo {
                        CountryName = "Myanmar",
                        AdjacentCountries = new List<string> { "Bangladesh", "India", "China" }
                }},
                { "RU", new CountryInfo {
                        CountryName = "Russia",
                        AdjacentCountries = new List<string> { "China", "Mongolia" }
                }},
                { "MN", new CountryInfo {
                        CountryName = "Mongolia",
                        AdjacentCountries = new List<string> { "China", "Russia" }
                }},
                { "US", new CountryInfo {
                        CountryName = "United States",
                        AdjacentCountries = new List<string> { "Canada", "Mexico" }
                }},
                { "CA", new CountryInfo {
                        CountryName = "Canada",
                        AdjacentCountries = new List<string> { "United States" }
                }}
            };
        }
    }
}
