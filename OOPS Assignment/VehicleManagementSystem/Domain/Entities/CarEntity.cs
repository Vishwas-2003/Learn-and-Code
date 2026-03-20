namespace OOPSAssignment.VehicleManagementSystem.Domain.Entities;

public sealed class CarEntity : VehicleEntity
{
    public CarEntity(string make, string model, int year, double price, decimal fuelLevelPercent)
        : base(make, model, year, price)
    {
        FuelLevelPercent = fuelLevelPercent;
    }

    public decimal FuelLevelPercent { get; set; }
}
