using OOPSAssignment.VehicleManagementSystem.Domain.Entities;
using OOPSAssignment.VehicleManagementSystem.Domain.Energy;

namespace OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

/// <summary>
/// Vehicle behavior; state lives on <see cref="VehicleEntity"/>.
/// </summary>
public abstract class Vehicle : IVehicle
{
    private readonly IEnergyStore _energyStore;

    private const double MinPriceUsd = 0;
    private const double MaxPriceUsd = 1_000_000;

    protected Vehicle(VehicleEntity entity, IEnergyStore energyStore)
    {
        Entity = entity;
        Entity.Price = NormalizePrice(Entity.Price);
        _energyStore = energyStore;
    }

    protected VehicleEntity Entity { get; }

    public string Make => Entity.Make;
    public string Model => Entity.Model;
    public int Year => Entity.Year;
    public double Price => Entity.Price;

    public bool IsRunning => Entity.IsRunning;
    public abstract string Kind { get; }

    public void Start()
    {
        if (!_energyStore.HasEnergy)
        {
            Console.WriteLine(CannotStartMessage);
            return;
        }

        Entity.IsRunning = true;
        Console.WriteLine(StartMessage);
    }

    public void Stop()
    {
        Entity.IsRunning = false;
        Console.WriteLine($"{Make} {Model} stopped.");
    }

    public void ReplenishEnergy(decimal amountPercent)
    {
        if (amountPercent <= 0)
            return;

        _energyStore.AddPercent(amountPercent);
        SyncEnergyLevelToEntity(_energyStore.LevelPercent);
        Console.WriteLine($"{EnergyVerbPastTense}. {EnergyLevelLabel}: {_energyStore.LevelPercent}%");
    }

    public virtual string GetDisplayInfo() => $"{DisplayName}: {Year} {Make} {Model}, Price: ${Price}";

    public void SetPrice(double price)
    {
        Entity.Price = NormalizePrice(price);
    }

    protected abstract string DisplayName { get; }
    protected abstract string EnergyVerbPastTense { get; }
    protected abstract string EnergyLevelLabel { get; }
    protected abstract string CannotStartMessage { get; }
    protected abstract string StartMessage { get; }

    protected abstract void SyncEnergyLevelToEntity(decimal levelPercent);

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
