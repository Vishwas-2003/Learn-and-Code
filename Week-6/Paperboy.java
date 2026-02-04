public class Paperboy {

    public void CollectPayment (Customer customer, double paymentAmount) {
        boolean amountPaid = customer.Pay(paymentAmount);

        if (!amountPaid) {
            // come back later
        }
    }
}
