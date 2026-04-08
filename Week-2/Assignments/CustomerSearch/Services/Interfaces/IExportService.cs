using CustomerSearch.Models;

namespace CustomerSearch.Services.Interfaces
{
    internal interface IExportService
    {
        string ExportToCSV(List<Customer> customers);
    }
}
