using VehicleManagementSystem.Domain.Energy;

namespace VehicleManagementSystem.Domain.Vehicles;

public sealed class ElectricCar : Vehicle
{
    public ElectricCar(string make, string model, int year, double price, Percentage initialBatteryLevelPercent)
        : base(make, model, year, price, new Battery(initialBatteryLevelPercent))
    {
    }

    protected override string DisplayName => "Electric Car";
    protected override string EnergyVerbPastTense => "Charged";
    protected override string EnergyLevelLabel => "Battery level";
    protected override string CannotStartMessage => "Cannot start - battery dead!";
    protected override string StartMessage => $"{Make} {Model} electric motor started.";
    public override string Kind => "Electric car";
}

