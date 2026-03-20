namespace OOPSAssignment.CreatorMonetization.Domain;

public interface IEarningStrategy
{
    double Calculate(EarningContext context);
}
