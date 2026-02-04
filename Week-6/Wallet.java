public class Wallet {

    private double balance;

    public Wallet (double balance) {
        this.balance = balance;
    }

    public boolean Withdraw (double amount) {
        if (balance >= amount) {
            balance -= amount;
            return true;
        }
        return false;
    }
}
