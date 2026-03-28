public class Customer {

    private String firstName;
    private String lastName;
    private Wallet wallet;

    public Customer (String firstName, String lastName, Wallet wallet) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.wallet = wallet;
    }

    public boolean Pay (double amount) {
        return wallet.Withdraw(amount);
    }
}
