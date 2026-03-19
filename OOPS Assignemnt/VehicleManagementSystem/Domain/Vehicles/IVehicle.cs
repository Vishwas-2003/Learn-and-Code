namespace VehicleManagementSystem.Domain.Vehicles;

public interface IVehicle
{
    string Kind { get; }
    string Make { get; }
    string Model { get; }
    int Year { get; }
    double Price { get; }

    bool IsRunning { get; }

    void Start();
    void Stop();
    void SetPrice(double price);
    void ReplenishEnergy(decimal amountPercent);
    string GetDisplayInfo();
}

