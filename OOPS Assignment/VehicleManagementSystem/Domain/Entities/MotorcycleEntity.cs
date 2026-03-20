namespace OOPSAssignment.VehicleManagementSystem.Domain.Entities;

public sealed class MotorcycleEntity : VehicleEntity
{
    public MotorcycleEntity(
        string make,
        string model,
        int year,
        double price,
        decimal fuelLevelPercent,
        bool hasSidecar)
        : base(make, model, year, price)
    {
        FuelLevelPercent = fuelLevelPercent;
        HasSidecar = hasSidecar;
    }

    public decimal FuelLevelPercent { get; set; }
    public bool HasSidecar { get; }
}
