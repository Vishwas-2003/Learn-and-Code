using OOPSAssignment.VehicleManagementSystem.Domain.Entities;
using OOPSAssignment.VehicleManagementSystem.Domain.Energy;

namespace OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

public sealed class Car : Vehicle
{
    public Car(CarEntity entity)
        : base(entity, new FuelTank(Percentage.From(entity.FuelLevelPercent)))
    {
    }

    protected override string DisplayName => "Car";
    protected override string EnergyVerbPastTense => "Refueled";
    protected override string EnergyLevelLabel => "Fuel level";
    protected override string CannotStartMessage => "Cannot start - no fuel!";
    protected override string StartMessage => $"{Make} {Model} started.";
    public override string Kind => "Car";

    protected override void SyncEnergyLevelToEntity(decimal levelPercent)
        => ((CarEntity)Entity).FuelLevelPercent = levelPercent;
}
