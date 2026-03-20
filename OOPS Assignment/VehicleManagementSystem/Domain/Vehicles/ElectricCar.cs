using OOPSAssignment.VehicleManagementSystem.Domain.Entities;
using OOPSAssignment.VehicleManagementSystem.Domain.Energy;

namespace OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

public sealed class ElectricCar : Vehicle
{
    public ElectricCar(ElectricCarEntity entity)
        : base(entity, new Battery(Percentage.From(entity.BatteryLevelPercent)))
    {
    }

    protected override string DisplayName => "Electric Car";
    protected override string EnergyVerbPastTense => "Charged";
    protected override string EnergyLevelLabel => "Battery level";
    protected override string CannotStartMessage => "Cannot start - battery dead!";
    protected override string StartMessage => $"{Make} {Model} electric motor started.";
    public override string Kind => "Electric car";

    protected override void SyncEnergyLevelToEntity(decimal levelPercent)
        => ((ElectricCarEntity)Entity).BatteryLevelPercent = levelPercent;
}
