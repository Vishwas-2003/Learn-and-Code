using PaymentManagementSystem.Interfaces;

namespace PaymentManagementSystem;

public sealed class ConsoleNotificationService : INotificationService
{
    public void Send(string customerId, string message)
    {
        Console.WriteLine($"Notification sent to {customerId}: {message}");
    }
}
