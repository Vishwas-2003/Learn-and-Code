using CustomerSearch.Models;
using CustomerSearch.Services.Interfaces;

namespace CustomerSearch.Services
{
    public class PrintService : IPrintService
    {
        public void PrintCSV(string csv)
        {
            Console.WriteLine(csv);
        }

        public void PrintCustomerData(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"ID: {customer.Id}, Name: {customer.Name}, Contact: {customer.Contact}, Country: {customer.Country}, Company: {customer.Company}"
                );
            }
            Console.WriteLine();
        }
    }
}
