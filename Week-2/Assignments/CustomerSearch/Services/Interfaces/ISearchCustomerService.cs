using CustomerSearch.Models;

namespace CustomerSearch.Services.Interfaces
{
    internal interface ISearchCustomerService
    {
        List<Customer> SearchByCountry(string country);
        List<Customer> SearchByCompanyName(string company);
        List<Customer> SearchByContact(string contact);
    }
}
