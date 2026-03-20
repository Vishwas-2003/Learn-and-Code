namespace OOPSAssignment.VehicleManagementSystem.Domain.Energy;

public readonly record struct Percentage(decimal Value)
{
    public static Percentage From(decimal value)
    {
        var normalized = Math.Clamp(value, 0m, 100m);
        return new Percentage(decimal.Round(normalized, 2, MidpointRounding.AwayFromZero));
    }

    public override string ToString() => $"{Value:N2}%";
}
