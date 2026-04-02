using AtmRefactoring.Constants;

namespace AtmRefactoring.Exceptions;

public sealed class DeviceLockedException : Exception
{
    public DeviceLockedException()
        : base(AtmConstants.DeviceLockedMessage)
    {
    }

    public DeviceLockedException(string message)
        : base(message)
    {
    }

    public DeviceLockedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
