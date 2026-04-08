using CustomerSearch.Models;

namespace CustomerSearch.Services.Interfaces
{
    public interface IPrintService
    {
        void PrintCustomerData(List<Customer> customers);
        void PrintCSV(string csv);
    }
}
