using PaymentManagementSystem.Interfaces;

namespace PaymentManagementSystem;

public sealed class EmailPaymentNotifier : IPaymentNotifier
{
    private readonly INotificationService _service;

    public EmailPaymentNotifier(INotificationService service)
    {
        _service = service;
    }

    public void NotifySuccess(PaymentRequest request)
    {
        _service.Send(request.CustomerId, $"Payment of {request.Amount} processed");
    }
}
