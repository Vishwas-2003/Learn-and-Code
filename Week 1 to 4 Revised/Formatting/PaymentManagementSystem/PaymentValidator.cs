namespace PaymentManagementSystem;

public sealed class PaymentValidator
{
    private const decimal MinAmount = 0.01m;

    public void Validate(PaymentRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.CustomerId))
        {
            throw new ArgumentException("Customer ID required");
        }

        if (request.Amount <= MinAmount)
        {
            throw new ArgumentException("Invalid amount");
        }
    }
}
