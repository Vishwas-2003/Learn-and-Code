using OOPSAssignment.CreatorMonetization.Domain;

namespace OOPSAssignment.CreatorMonetization.Domain.Strategies;

public sealed class AdsEarningStrategy : IEarningStrategy
{
    private const double RatePerView = 0.05;

    public double Calculate(EarningContext context)
        => context.Views * RatePerView;
}
