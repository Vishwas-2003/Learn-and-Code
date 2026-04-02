using AtmRefactoring.Enums;

namespace AtmRefactoring.Models;

public sealed class DeviceRecord
{
    public DeviceStatus Status { get; init; }
    public WifiConnectionState WifiConnection { get; init; }
}
