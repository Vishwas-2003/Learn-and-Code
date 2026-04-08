using CustomerSearch.Models;
using CustomerSearch.Services.Interfaces;
using System.Text;

namespace CustomerSearch.Services
{
    public class ExportService : IExportService
    {
        public string ExportToCSV(List<Customer> customers)
        {
            StringBuilder csv = new StringBuilder();

            foreach (var customer in customers)
            {
                csv.AppendFormat(
                    "{0}, {1}, {2}, {3}",
                    customer.Id,
                    customer.Name,
                    customer.Contact,
                    customer.Country
                );

                csv.AppendLine();
            }

            return csv.ToString();
        }
    }
}
