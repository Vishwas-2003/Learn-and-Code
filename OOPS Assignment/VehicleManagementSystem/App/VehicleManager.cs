using OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

namespace OOPSAssignment.VehicleManagementSystem.App;

public sealed class VehicleManager
{
    private readonly List<IVehicle> _vehicles = [];

    public IReadOnlyList<IVehicle> Vehicles => _vehicles;

    public void Add(IVehicle? vehicle)
    {
        if (vehicle is null)
            return;

        _vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.Kind} added");
    }

    public void DisplayAll()
    {
        Console.WriteLine("\n=== Vehicles ===");
        foreach (var vehicle in _vehicles)
            Console.WriteLine(vehicle.GetDisplayInfo());
    }

    public double TotalValue()
    {
        double total = 0;
        foreach (var vehicle in _vehicles)
            total += vehicle.Price;
        return total;
    }

    public void StartAll()
    {
        foreach (var vehicle in _vehicles)
            vehicle.Start();
    }
}
