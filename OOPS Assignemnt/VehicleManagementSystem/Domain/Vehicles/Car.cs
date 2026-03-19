using VehicleManagementSystem.Domain.Energy;

namespace VehicleManagementSystem.Domain.Vehicles;

public sealed class Car : Vehicle
{
    public Car(string make, string model, int year, double price, Percentage initialFuelLevelPercent)
        : base(make, model, year, price, new FuelTank(initialFuelLevelPercent))
    {
    }

    protected override string DisplayName => "Car";
    protected override string EnergyVerbPastTense => "Refueled";
    protected override string EnergyLevelLabel => "Fuel level";
    protected override string CannotStartMessage => "Cannot start - no fuel!";
    protected override string StartMessage => $"{Make} {Model} started.";
    public override string Kind => "Car";
}

