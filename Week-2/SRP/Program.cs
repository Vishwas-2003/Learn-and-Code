using SRP.Model;
using SRP.Repository;
using SRP.Service;
using SRP.Utility;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SINGLE RESPONSIBILITY PRINCIPLE (SRP)");

            var user = new User { Name = "Vishwas Vijayvargiya", Email = "vishwas.v@intimetec.com" };
            var userRepo = new UserRepository();
            var emailService = new EmailService();
            var validator = new UserValidator();

            Console.WriteLine("Processing user registration...\n");

            if (validator.ValidateEmail(user.Email))
            {
                Console.WriteLine($"Email '{user.Email}' is valid");
                userRepo.Save(user);
                emailService.SendEmail(user);
            }
            else
            {
                Console.WriteLine("Invalid email address");
            }
        }
    }
}