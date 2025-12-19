namespace SRP.Utility
{
    public class UserValidator
    {
        public bool ValidateEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }
    }
}
