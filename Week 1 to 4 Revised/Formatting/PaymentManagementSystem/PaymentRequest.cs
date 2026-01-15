namespace PaymentManagementSystem;

public sealed record PaymentRequest(
    string CustomerId,
    decimal Amount);
