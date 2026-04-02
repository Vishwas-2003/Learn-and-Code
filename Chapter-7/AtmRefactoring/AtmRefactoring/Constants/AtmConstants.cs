namespace AtmRefactoring.Constants;

public static class AtmConstants
{
    public const string PrimaryDeviceId = "DEV1";
    public const string DefaultAccountId = "ACC1";
    public const int DefaultTerminalDeviceId = 1;
    public const decimal DefaultMockBalance = 1000m;

    public const decimal DemoWithdrawalAmount = 100m;
    public const decimal DemoLowBalance = 50m;
    public const decimal DemoSmallWithdrawal = 10m;

    public const string DeviceUnavailableMessage = "ATM device is not available.";
    public const string DeviceLockedMessage = "The ATM device is locked or suspended.";
    public const string NetworkUnavailableMessage = "Network connection is not available.";
    public const string InsufficientFundsMessageFormat = "Insufficient funds. Available: {0:C}, requested: {1:C}.";

    public const string ScenarioHeaderFormat = "--- {0} ---";
    public const string SuccessResult = "Result: withdrawal completed successfully.";
    public const string ResultDeviceLockedFormat = "Result: device locked — {0}";
    public const string ResultInsufficientFundsFormat = "Result: insufficient funds — available {0:C}, requested {1:C}.";
    public const string ResultNetworkFormat = "Result: network error — {0}";
    public const string ResultDeviceUnavailableFormat = "Result: device unavailable — {0}";

    public const string DispensedMessageFormat = "Dispensed {0:C} from ATM terminal access {1}.";

    public const string ScenarioTitleSuccess = "Successful withdrawal";
    public const string ScenarioTitleInsufficientFunds = "Insufficient funds";
    public const string ScenarioTitleDeviceLocked = "Device locked";
    public const string ScenarioTitleNoNetwork = "No network";
    public const string ScenarioTitleUnavailableTerminal = "ATM terminal unavailable";
}
