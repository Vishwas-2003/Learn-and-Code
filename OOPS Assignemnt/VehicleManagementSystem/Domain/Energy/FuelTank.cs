namespace VehicleManagementSystem.Domain.Energy;

public sealed class FuelTank : EnergyStoreBase
{
    public FuelTank(Percentage initialFuelLevelPercent) : base(initialFuelLevelPercent) { }
}
