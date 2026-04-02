namespace AtmRefactoring.ValueObjects;

public readonly struct AtmTerminalAccess : IEquatable<AtmTerminalAccess>
{
    public static AtmTerminalAccess Unavailable => default;

    private readonly int _deviceId;

    private AtmTerminalAccess(int deviceId) => _deviceId = deviceId;

    public static AtmTerminalAccess ForDevice(int deviceId) => new(deviceId);

    public bool IsAvailable => _deviceId != 0;

    public bool Equals(AtmTerminalAccess other) => _deviceId == other._deviceId;

    public override bool Equals(object? obj) => obj is AtmTerminalAccess other && Equals(other);

    public override int GetHashCode() => _deviceId;

    public static bool operator ==(AtmTerminalAccess left, AtmTerminalAccess right) => left.Equals(right);

    public static bool operator !=(AtmTerminalAccess left, AtmTerminalAccess right) => !left.Equals(right);
}
