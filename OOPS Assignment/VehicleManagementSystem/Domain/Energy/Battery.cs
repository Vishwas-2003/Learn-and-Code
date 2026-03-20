namespace OOPSAssignment.VehicleManagementSystem.Domain.Energy;

public sealed class Battery : EnergyStoreBase
{
    public Battery(Percentage initialBatteryLevelPercent) : base(initialBatteryLevelPercent) { }
}
