using SRP.Model;

namespace SRP.Service
{
    public class EmailService
    {
        public void SendEmail(User user)
        {
            Console.WriteLine($"Email sent to {user.Email}");
        }
    }
}
