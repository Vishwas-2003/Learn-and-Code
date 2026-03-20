namespace OOPSAssignment.VehicleManagementSystem.Domain.Energy;

public abstract class EnergyStoreBase : IEnergyStore
{
    private Percentage _level;

    protected EnergyStoreBase(Percentage initialLevel)
    {
        _level = initialLevel;
    }

    public decimal LevelPercent => _level.Value;

    public bool HasEnergy => LevelPercent > 0;

    public void AddPercent(decimal amountPercent)
    {
        if (amountPercent <= 0)
            return;

        _level = Percentage.From(LevelPercent + amountPercent);
    }
}
