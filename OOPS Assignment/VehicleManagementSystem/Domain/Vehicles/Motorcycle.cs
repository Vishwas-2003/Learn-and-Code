using OOPSAssignment.VehicleManagementSystem.Domain.Entities;
using OOPSAssignment.VehicleManagementSystem.Domain.Energy;

namespace OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

public sealed class Motorcycle : Vehicle
{
    public Motorcycle(MotorcycleEntity entity)
        : base(entity, new FuelTank(Percentage.From(entity.FuelLevelPercent)))
    {
    }

    public bool HasSidecar => ((MotorcycleEntity)Entity).HasSidecar;

    protected override string DisplayName => "Motorcycle";
    protected override string EnergyVerbPastTense => "Refueled";
    protected override string EnergyLevelLabel => "Fuel level";
    protected override string CannotStartMessage => "Cannot start - no fuel!";
    protected override string StartMessage => $"{Make} {Model} started.";
    public override string Kind => "Motorcycle";

    public override string GetDisplayInfo()
        => $"{base.GetDisplayInfo()}, Sidecar: {HasSidecar}";

    protected override void SyncEnergyLevelToEntity(decimal levelPercent)
        => ((MotorcycleEntity)Entity).FuelLevelPercent = levelPercent;
}
