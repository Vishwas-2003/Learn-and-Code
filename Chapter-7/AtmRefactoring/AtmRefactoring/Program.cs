using AtmRefactoring.Constants;
using AtmRefactoring.Controllers;
using AtmRefactoring.Enums;
using AtmRefactoring.Exceptions;
using AtmRefactoring.Models;
using AtmRefactoring.ValueObjects;

namespace AtmRefactoring;

internal static class Program
{
    private static void Main()
    {
        RunScenario(new WithdrawalScenarioRequest
        {
            Title = AtmConstants.ScenarioTitleSuccess,
            Controller = CreateControllerForHappyPath(),
            AccountId = AtmConstants.DefaultAccountId,
            Amount = AtmConstants.DemoWithdrawalAmount,
        });

        RunScenario(new WithdrawalScenarioRequest
        {
            Title = AtmConstants.ScenarioTitleInsufficientFunds,
            Controller = CreateControllerWithBalance(AtmConstants.DemoLowBalance),
            AccountId = AtmConstants.DefaultAccountId,
            Amount = AtmConstants.DemoWithdrawalAmount,
        });

        RunScenario(new WithdrawalScenarioRequest
        {
            Title = AtmConstants.ScenarioTitleDeviceLocked,
            Controller = CreateControllerWithSuspendedDevice(),
            AccountId = AtmConstants.DefaultAccountId,
            Amount = AtmConstants.DemoSmallWithdrawal,
        });

        RunScenario(new WithdrawalScenarioRequest
        {
            Title = AtmConstants.ScenarioTitleNoNetwork,
            Controller = CreateControllerWithDisconnectedWifi(),
            AccountId = AtmConstants.DefaultAccountId,
            Amount = AtmConstants.DemoSmallWithdrawal,
        });

        RunScenario(new WithdrawalScenarioRequest
        {
            Title = AtmConstants.ScenarioTitleUnavailableTerminal,
            Controller = CreateControllerWithUnavailableTerminal(),
            AccountId = AtmConstants.DefaultAccountId,
            Amount = AtmConstants.DemoSmallWithdrawal,
        });
    }

    private static void RunScenario(WithdrawalScenarioRequest scenario)
    {
        Console.WriteLine(string.Format(AtmConstants.ScenarioHeaderFormat, scenario.Title));
        try
        {
            scenario.Controller.Withdraw(scenario.AccountId, scenario.Amount);
            Console.WriteLine(AtmConstants.SuccessResult);
        }
        catch (DeviceLockedException ex)
        {
            Console.WriteLine(string.Format(AtmConstants.ResultDeviceLockedFormat, ex.Message));
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(string.Format(
                AtmConstants.ResultInsufficientFundsFormat,
                ex.AvailableBalance,
                ex.RequestedAmount));
        }
        catch (NetworkConnectionException ex)
        {
            Console.WriteLine(string.Format(AtmConstants.ResultNetworkFormat, ex.Message));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(string.Format(AtmConstants.ResultDeviceUnavailableFormat, ex.Message));
        }

        Console.WriteLine();
    }

    private static ATMDeviceController CreateControllerForHappyPath() =>
        new(new AtmDeviceControllerDependencies());

    private static ATMDeviceController CreateControllerWithBalance(decimal balance) =>
        new(new AtmDeviceControllerDependencies { GetBalance = _ => balance });

    private static ATMDeviceController CreateControllerWithSuspendedDevice() =>
        new(new AtmDeviceControllerDependencies
        {
            RetrieveDeviceRecord = _ => new DeviceRecord
            {
                Status = DeviceStatus.Suspended,
                WifiConnection = WifiConnectionState.Connected,
            },
        });

    private static ATMDeviceController CreateControllerWithDisconnectedWifi() =>
        new(new AtmDeviceControllerDependencies
        {
            RetrieveDeviceRecord = _ => new DeviceRecord
            {
                Status = DeviceStatus.Active,
                WifiConnection = WifiConnectionState.Disconnected,
            },
        });

    private static ATMDeviceController CreateControllerWithUnavailableTerminal() =>
        new(new AtmDeviceControllerDependencies { ResolveTerminalAccess = _ => AtmTerminalAccess.Unavailable });
}
