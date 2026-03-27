using PaymentManagementSystem.Interfaces;

namespace PaymentManagementSystem;

public sealed class PaymentProcessor
{
    private readonly PaymentValidator _validator;
    private readonly PaymentExecutor _executor;
    private readonly IPaymentRecorder _recorder;
    private readonly IPaymentNotifier _notifier;

    public PaymentProcessor(
        PaymentValidator validator,
        PaymentExecutor executor,
        IPaymentRecorder recorder,
        IPaymentNotifier notifier)
    {
        _validator = validator;
        _executor = executor;
        _recorder = recorder;
        _notifier = notifier;
    }

    public PaymentResult Process(PaymentRequest request)
    {
        _validator.Validate(request);

        string transactionId = _executor.Execute(request);
        _recorder.Record(request, transactionId);
        _notifier.NotifySuccess(request);

        return PaymentResult.Success(transactionId);
    }
}
