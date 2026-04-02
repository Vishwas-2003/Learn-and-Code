using AtmRefactoring.Constants;

namespace AtmRefactoring.Exceptions;

public sealed class NetworkConnectionException : Exception
{
    public NetworkConnectionException()
        : base(AtmConstants.NetworkUnavailableMessage)
    {
    }

    public NetworkConnectionException(string message)
        : base(message)
    {
    }

    public NetworkConnectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
