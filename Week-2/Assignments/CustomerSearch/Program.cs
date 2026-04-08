using CustomerSearch.Seeds;
using CustomerSearch.Services;
using CustomerSearch.Services.Interfaces;

namespace CustomerSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customerData = CustomerSeedData.GetCustomers();

            ISearchCustomerService searchService = new SearchCustomerService(customerData);
            IExportService exportService = new ExportService();
            IPrintService printService = new PrintService();

            var searchResultForCountry = searchService.SearchByCountry("India");
            var searchResultForCompany = searchService.SearchByCompanyName("Google LLC");
            var searchResultForContact = searchService.SearchByContact("9876543210");

            var csvForCustomer = exportService.ExportToCSV(customerData);

            Console.WriteLine("Search Results (For Country):");
            printService.PrintCustomerData(searchResultForCountry);

            Console.WriteLine("Search Results (For Company):");
            printService.PrintCustomerData(searchResultForCompany);

            Console.WriteLine("Search Results (For Contact):");
            printService.PrintCustomerData(searchResultForContact);

            Console.WriteLine("CSV Export:");
            printService.PrintCSV(csvForCustomer);
        }
    }
}