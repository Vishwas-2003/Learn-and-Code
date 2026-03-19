using VehicleManagementSystem.Domain.Energy;

namespace VehicleManagementSystem.Domain.Vehicles;

public sealed class Motorcycle : Vehicle
{
    public Motorcycle(
        string make,
        string model,
        int year,
        double price,
        Percentage initialFuelLevelPercent,
        bool hasSidecar)
        : base(make, model, year, price, new FuelTank(initialFuelLevelPercent))
    {
        HasSidecar = hasSidecar;
    }

    public bool HasSidecar { get; }

    protected override string DisplayName => "Motorcycle";
    protected override string EnergyVerbPastTense => "Refueled";
    protected override string EnergyLevelLabel => "Fuel level";
    protected override string CannotStartMessage => "Cannot start - no fuel!";
    protected override string StartMessage => $"{Make} {Model} started.";
    public override string Kind => "Motorcycle";

    public override string GetDisplayInfo()
        => $"{base.GetDisplayInfo()}, Sidecar: {HasSidecar}";
}

