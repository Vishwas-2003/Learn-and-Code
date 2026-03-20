namespace OOPSAssignment.CreatorMonetization.Domain.Entities;

public sealed class CreatorEntity
{
    public CreatorEntity(string name, int views, int subscribers, double baseAmount)
    {
        Name = name;
        Views = views;
        Subscribers = subscribers;
        BaseAmount = baseAmount;
    }

    public string Name { get; }
    public int Views { get; }
    public int Subscribers { get; }
    public double BaseAmount { get; }
}
