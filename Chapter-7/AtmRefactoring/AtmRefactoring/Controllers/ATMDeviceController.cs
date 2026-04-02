using AtmRefactoring.Constants;
using AtmRefactoring.Enums;
using AtmRefactoring.Exceptions;
using AtmRefactoring.Models;
using AtmRefactoring.ValueObjects;

namespace AtmRefactoring.Controllers;

public sealed class ATMDeviceController
{
    private readonly Func<string, AtmTerminalAccess> _resolveTerminalAccess;
    private readonly Func<AtmTerminalAccess, DeviceRecord> _retrieveDeviceRecord;
    private readonly Func<string, decimal> _getBalance;
    private readonly Action<AtmTerminalAccess, decimal> _dispenseCash;

    public ATMDeviceController(AtmDeviceControllerDependencies? dependencies = null)
    {
        var d = dependencies ?? new AtmDeviceControllerDependencies();
        _resolveTerminalAccess = d.ResolveTerminalAccess
            ?? (_ => AtmTerminalAccess.ForDevice(AtmConstants.DefaultTerminalDeviceId));
        _retrieveDeviceRecord = d.RetrieveDeviceRecord
            ?? (_ => new DeviceRecord
            {
                Status = DeviceStatus.Active,
                WifiConnection = WifiConnectionState.Connected,
            });
        _getBalance = d.GetBalance ?? (_ => AtmConstants.DefaultMockBalance);
        _dispenseCash = d.DispenseCash
            ?? ((terminalAccess, amount) => Console.WriteLine(
                string.Format(AtmConstants.DispensedMessageFormat, amount, terminalAccess.GetHashCode())));
    }

    public void Withdraw(string accountId, decimal amount)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(accountId);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(amount, 0m);

        var terminalAccess = _resolveTerminalAccess(AtmConstants.PrimaryDeviceId);
        EnsureTerminalAccessAvailable(terminalAccess);

        var record = _retrieveDeviceRecord(terminalAccess);
        EnsureDeviceIsUnlocked(record);
        EnsureNetworkIsAvailable(record);
        EnsureSufficientFunds(accountId, amount);

        _dispenseCash(terminalAccess, amount);
    }

    private static void EnsureTerminalAccessAvailable(AtmTerminalAccess terminalAccess)
    {
        if (!terminalAccess.IsAvailable)
        {
            throw new InvalidOperationException(AtmConstants.DeviceUnavailableMessage);
        }
    }

    private static void EnsureDeviceIsUnlocked(DeviceRecord record)
    {
        if (record.Status == DeviceStatus.Suspended)
        {
            throw new DeviceLockedException();
        }
    }

    private static void EnsureNetworkIsAvailable(DeviceRecord record)
    {
        if (record.WifiConnection != WifiConnectionState.Connected)
        {
            throw new NetworkConnectionException();
        }
    }

    private void EnsureSufficientFunds(string accountId, decimal amount)
    {
        var balance = _getBalance(accountId);
        if (balance < amount)
        {
            throw new InsufficientFundsException(balance, amount);
        }
    }
}
