using PaymentManagementSystem;
using PaymentManagementSystem.Interfaces;

class Program
{
    static void Main()
    {
        INotificationService notificationService = new ConsoleNotificationService();
        IPaymentNotifier paymentNotifier = new EmailPaymentNotifier(notificationService);
        IPaymentRecorder paymentRecorder = new InMemoryPaymentRecorder();

        var validator = new PaymentValidator();
        var executor = new PaymentExecutor();

        var paymentProcessor = new PaymentProcessor(
            validator,
            executor,
            paymentRecorder,
            paymentNotifier);

        var request = new PaymentRequest( CustomerId: "CUST-101", Amount: 1500m);

        PaymentResult result = paymentProcessor.Process(request);

        Console.WriteLine(result.Message);
        Console.WriteLine($"Transaction ID: {result.TransactionId}");
    }
}
