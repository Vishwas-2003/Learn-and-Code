using AtmRefactoring.ValueObjects;

namespace AtmRefactoring.Models;

public sealed class AtmDeviceControllerDependencies
{
    public Func<string, AtmTerminalAccess>? ResolveTerminalAccess { get; init; }
    public Func<AtmTerminalAccess, DeviceRecord>? RetrieveDeviceRecord { get; init; }
    public Func<string, decimal>? GetBalance { get; init; }
    public Action<AtmTerminalAccess, decimal>? DispenseCash { get; init; }
}
