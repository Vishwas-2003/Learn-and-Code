namespace OOPSAssignment.CreatorMonetization.Domain;

public sealed class EarningContext
{
    public EarningContext(int views, int subscribers, double baseAmount)
    {
        Views = views;
        Subscribers = subscribers;
        BaseAmount = baseAmount;
    }

    public int Views { get; }
    public int Subscribers { get; }
    public double BaseAmount { get; }
}
