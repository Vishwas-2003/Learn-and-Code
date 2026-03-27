namespace PaymentManagementSystem.Interfaces;

public interface IPaymentNotifier
{
    void NotifySuccess(PaymentRequest request);
}
