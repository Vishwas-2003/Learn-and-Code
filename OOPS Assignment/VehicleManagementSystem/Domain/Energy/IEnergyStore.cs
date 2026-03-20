namespace OOPSAssignment.VehicleManagementSystem.Domain.Energy;

public interface IEnergyStore
{
    decimal LevelPercent { get; }
    bool HasEnergy { get; }

    void AddPercent(decimal amountPercent);
}
