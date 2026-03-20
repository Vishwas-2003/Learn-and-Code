namespace OOPSAssignment.VehicleManagementSystem.Domain.Entities;

public sealed class ElectricCarEntity : VehicleEntity
{
    public ElectricCarEntity(string make, string model, int year, double price, decimal batteryLevelPercent)
        : base(make, model, year, price)
    {
        BatteryLevelPercent = batteryLevelPercent;
    }

    public decimal BatteryLevelPercent { get; set; }
}
