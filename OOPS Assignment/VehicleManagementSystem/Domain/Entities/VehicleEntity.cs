namespace OOPSAssignment.VehicleManagementSystem.Domain.Entities;

/// <summary>
/// Core vehicle data (entity). No operational behavior.
/// </summary>
public abstract class VehicleEntity
{
    protected VehicleEntity(string make, string model, int year, double price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }

    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public double Price { get; set; }
    public bool IsRunning { get; set; }
}
