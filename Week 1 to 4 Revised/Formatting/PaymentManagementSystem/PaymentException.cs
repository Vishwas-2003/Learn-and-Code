namespace PaymentManagementSystem;

public sealed class PaymentException : Exception
{
    public PaymentException(string message) : base(message)
    {
    }
}
