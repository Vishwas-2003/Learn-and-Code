using AtmRefactoring.Controllers;

namespace AtmRefactoring.Models;

public sealed class WithdrawalScenarioRequest
{
    public required string Title { get; init; }
    public required ATMDeviceController Controller { get; init; }
    public required string AccountId { get; init; }
    public decimal Amount { get; init; }
}
