using VehicleManagementSystem.Domain.Energy;

namespace VehicleManagementSystem.Domain.Vehicles;

public abstract class Vehicle : IVehicle
{
    private readonly IEnergyStore _energyStore;

    private const double MinPriceUsd = 0;
    private const double MaxPriceUsd = 1_000_000;

    protected Vehicle(
        string make,
        string model,
        int year,
        double price,
        IEnergyStore energyStore)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = NormalizePrice(price);
        _energyStore = energyStore;
    }

    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public double Price { get; private set; }

    public bool IsRunning { get; private set; }
    public abstract string Kind { get; }

    public void Start()
    {
        if (!_energyStore.HasEnergy)
        {
            Console.WriteLine(CannotStartMessage);
            return;
        }

        IsRunning = true;
        Console.WriteLine(StartMessage);
    }

    public void Stop()
    {
        IsRunning = false;
        Console.WriteLine($"{Make} {Model} stopped.");
    }

    public void ReplenishEnergy(decimal amountPercent)
    {
        if (amountPercent <= 0)
            return;

        _energyStore.AddPercent(amountPercent);
        Console.WriteLine($"{EnergyVerbPastTense}. {EnergyLevelLabel}: {_energyStore.LevelPercent}%");
    }

    public virtual string GetDisplayInfo() => $"{DisplayName}: {Year} {Make} {Model}, Price: ${Price}";

    public void SetPrice(double price) => Price = NormalizePrice(price);

    protected abstract string DisplayName { get; }
    protected abstract string EnergyVerbPastTense { get; }
    protected abstract string EnergyLevelLabel { get; }
    protected abstract string CannotStartMessage { get; }
    protected abstract string StartMessage { get; }

    private static double NormalizePrice(double price)
    {
        if (double.IsNaN(price) || double.IsInfinity(price))
            return MinPriceUsd;

        if (price < MinPriceUsd)
            return MinPriceUsd;

        if (price > MaxPriceUsd)
            return MaxPriceUsd;

        return price;
    }
}

