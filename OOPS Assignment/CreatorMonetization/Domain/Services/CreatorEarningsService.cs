using OOPSAssignment.CreatorMonetization.Domain;
using OOPSAssignment.CreatorMonetization.Domain.Entities;

namespace OOPSAssignment.CreatorMonetization.Domain.Services;

public sealed class CreatorEarningsService
{
    private readonly List<IEarningStrategy> _earningStrategies = [];

    public IReadOnlyList<IEarningStrategy> EarningStrategies => _earningStrategies;

    public void RegisterEarningStrategy(IEarningStrategy strategy)
    {
        if (strategy is null)
            return;

        _earningStrategies.Add(strategy);
    }

    public double CalculateEarnings(CreatorEntity creator)
    {
        var context = new EarningContext(creator.Views, creator.Subscribers, creator.BaseAmount);
        double total = 0;
        foreach (var strategy in _earningStrategies)
            total += strategy.Calculate(context);
        return total;
    }
}
