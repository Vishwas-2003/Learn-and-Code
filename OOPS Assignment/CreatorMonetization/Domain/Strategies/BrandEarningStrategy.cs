using OOPSAssignment.CreatorMonetization.Domain;

namespace OOPSAssignment.CreatorMonetization.Domain.Strategies;

public sealed class BrandEarningStrategy : IEarningStrategy
{
    public double Calculate(EarningContext context)
        => context.BaseAmount;
}
