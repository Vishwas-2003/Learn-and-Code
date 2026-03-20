using OOPSAssignment.CreatorMonetization.Domain;

namespace OOPSAssignment.CreatorMonetization.Domain.Strategies;

public sealed class SubscriptionEarningStrategy : IEarningStrategy
{
    private const double AmountPerSubscriber = 2;

    public double Calculate(EarningContext context)
        => context.Subscribers * AmountPerSubscriber;
}
