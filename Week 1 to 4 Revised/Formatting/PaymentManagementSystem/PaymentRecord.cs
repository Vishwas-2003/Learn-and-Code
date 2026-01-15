namespace PaymentManagementSystem;

public sealed record PaymentRecord(
    string TransactionId,
    string CustomerId,
    decimal Amount,
    DateTime Timestamp);
