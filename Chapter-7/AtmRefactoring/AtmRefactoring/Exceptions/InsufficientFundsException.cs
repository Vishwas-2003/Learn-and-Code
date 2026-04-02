using AtmRefactoring.Constants;

namespace AtmRefactoring.Exceptions;

public sealed class InsufficientFundsException : Exception
{
    public decimal AvailableBalance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientFundsException(decimal availableBalance, decimal requestedAmount)
        : base(string.Format(AtmConstants.InsufficientFundsMessageFormat, availableBalance, requestedAmount))
    {
        AvailableBalance = availableBalance;
        RequestedAmount = requestedAmount;
    }

    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
