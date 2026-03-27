using PaymentManagementSystem.Interfaces;

namespace PaymentManagementSystem;

public sealed class InMemoryPaymentRecorder : IPaymentRecorder
{
    public void Record(PaymentRequest request, string transactionId)
    {
        _ = new PaymentRecord(
            transactionId,
            request.CustomerId,
            request.Amount,
            DateTime.UtcNow);
    }
}
