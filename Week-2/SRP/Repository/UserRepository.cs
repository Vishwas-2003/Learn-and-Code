using SRP.Model;

namespace SRP.Repository
{
    public class UserRepository
    {
        public void Save(User user)
        {
            Console.WriteLine($"User {user.Name} saved to database");
        }
    }
}
