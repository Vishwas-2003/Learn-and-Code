namespace PaymentManagementSystem;

public sealed class PaymentExecutor
{
    private const decimal MaxLimit = 5000m;

    public string Execute(PaymentRequest request)
    {
        if (request.Amount > MaxLimit)
        {
            throw new PaymentException("Limit exceeded");
        }

        return GenerateTransactionId();
    }

    private static string GenerateTransactionId()
    {
        return $"TXN-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
    }
}
