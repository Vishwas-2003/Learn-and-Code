namespace PaymentManagementSystem.Interfaces;

public interface IPaymentRecorder
{
    void Record(PaymentRequest request, string transactionId);
}
