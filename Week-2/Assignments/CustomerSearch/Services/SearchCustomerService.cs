using CustomerSearch.Models;
using CustomerSearch.Services.Interfaces;

namespace CustomerSearch.Services
{
    public class SearchCustomerService : ISearchCustomerService
    {
        private readonly List<Customer> _customers;
        public SearchCustomerService(List<Customer> customers)
        {
            _customers = customers;
        }

        public List<Customer> SearchByCountry(string country)
        {
            var query =
                from customer in _customers
                where customer.Country.Equals(country)
                orderby customer.Id ascending
                select customer;

            return query.ToList();
        }

        public List<Customer> SearchByCompanyName(string company)
        {
            var query =
                from customer in _customers
                where customer.Company.Equals(company)
                orderby customer.Id ascending
                select customer;

            return query.ToList();
        }

        public List<Customer> SearchByContact(string contact)
        {
            var query =
                from customer in _customers
                where customer.Contact.Equals(contact)
                orderby customer.Id ascending
                select customer;

            return query.ToList();
        }
    }
}
