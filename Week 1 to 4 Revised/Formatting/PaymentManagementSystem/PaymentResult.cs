namespace PaymentManagementSystem;

public sealed class PaymentResult
{
    public bool IsSuccessful { get; }
    public string Message { get; }
    public string? TransactionId { get; }

    private PaymentResult(
        bool isSuccessful,
        string message,
        string? transactionId)
    {
        IsSuccessful = isSuccessful;
        Message = message;
        TransactionId = transactionId;
    }

    public static PaymentResult Success(string transactionId)
    {
        return new PaymentResult(
            true,
            "Payment successful",
            transactionId);
    }

    public static PaymentResult Failure(string message)
    {
        return new PaymentResult(
            false,
            message,
            null);
    }
}
