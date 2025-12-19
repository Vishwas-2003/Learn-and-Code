using CustomerSearch.Models;

namespace CustomerSearch.Seeds
{
    public static class CustomerSeedData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Vishwas Vijayvargiya",
                    Contact = "9876543210",
                    Country = "India",
                    Company = "InTimeTec"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Ananya Rao",
                    Contact = "9123456780",
                    Country = "India",
                    Company = "Infosys Ltd"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Michael Johnson",
                    Contact = "+1 408 555 1234",
                    Country = "USA",
                    Company = "Google LLC"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Emily Clark",
                    Contact = "+44 7700 900123",
                    Country = "UK",
                    Company = "HSBC Holdings"
                },
                new Customer
                {
                    Id = 5,
                    Name = "Arjun Verma",
                    Contact = "9812345678",
                    Country = "India",
                    Company = "Google LLC"
                },
                new Customer
                {
                    Id = 6,
                    Name = "Sofia Martinez",
                    Contact = "+34 600 123 456",
                    Country = "Spain",
                    Company = "Telefonica"
                },
                new Customer
                {
                    Id = 7,
                    Name = "Daniel Kim",
                    Contact = "+82 10-2345-6789",
                    Country = "South Korea",
                    Company = "Samsung Electronics"
                },
                new Customer
                {
                    Id = 8,
                    Name = "Oliver Brown",
                    Contact = "+61 412 345 678",
                    Country = "Australia",
                    Company = "BHP Group"
                }
            };
        }
    }
}
