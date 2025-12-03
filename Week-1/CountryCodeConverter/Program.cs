using System;
using System.Collections.Generic;

namespace CountryCodeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Country Code to Name Converter\n");

            while (true)
            {
                Console.Write("Enter a country code (e.g., IN, US, NZ) or 'EXIT' to quit: ");
                string input = Console.ReadLine()?.ToUpper().Trim();

                if (input == "EXIT")
                {
                    Console.WriteLine("EXITED...");
                    break;
                }

                if (!string.IsNullOrEmpty(input) && input.Length == 2)
                {
                    string countryName = GetCountryName(input);

                    if (countryName == null)
                    {
                        Console.WriteLine($"Country code '{input}' not found.\n");
                    }
                    else
                    {
                        Console.WriteLine($"{input} -> {countryName}\n");
                    }
                }
                else
                {
                    Console.WriteLine($"'{input}' is not a valid country code.\n");
                }
            }
        }

        private static Dictionary<string, string> GetCountriesData()
        {
            return new Dictionary<string, string>
            {
                {"IN", "India"},
                {"US", "United States"},
                {"NZ", "New Zealand"},
                {"CN", "China"},
                {"PK", "Pakistan"},
                {"BD", "Bangladesh"},
                {"NP", "Nepal"},
                {"BT", "Bhutan"},
                {"MM", "Myanmar"},
                {"AF", "Afghanistan"},
                {"CA", "Canada"},
                {"MX", "Mexico"},
                {"FR", "France"},
                {"DE", "Germany"},
                {"IT", "Italy"},
                {"ES", "Spain"},
                {"PT", "Portugal"},
                {"CH", "Switzerland"},
                {"AT", "Austria"},
                {"BE", "Belgium"},
                {"NL", "Netherlands"},
                {"PL", "Poland"},
                {"CZ", "Czech Republic"},
                {"GB", "United Kingdom"},
                {"AU", "Australia"},
                {"BR", "Brazil"},
                {"AR", "Argentina"},
                {"CL", "Chile"},
                {"PE", "Peru"},
                {"BO", "Bolivia"},
                {"PY", "Paraguay"},
                {"UY", "Uruguay"},
                {"CO", "Colombia"},
                {"VE", "Venezuela"},
                {"EC", "Ecuador"},
                {"GY", "Guyana"},
                {"SR", "Suriname"},
                {"LK", "Sri Lanka"},
                {"TH", "Thailand"},
                {"LA", "Laos"},
                {"KH", "Cambodia"},
                {"VN", "Vietnam"},
                {"RU", "Russia"},
                {"KZ", "Kazakhstan"},
                {"MN", "Mongolia"},
                {"KG", "Kyrgyzstan"},
                {"TJ", "Tajikistan"},
                {"UZ", "Uzbekistan"},
                {"TM", "Turkmenistan"}
            };
        }

        private static string GetCountryName(string code)
        {
            var countryNames = GetCountriesData();
            return countryNames.ContainsKey(code) ? countryNames[code] : null;
        }
    }
}
