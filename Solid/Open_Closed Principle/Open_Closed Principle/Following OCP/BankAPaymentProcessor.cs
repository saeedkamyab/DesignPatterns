namespace Open_Closed_Principle.Following_OCP
{
    public class BankAPaymentProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(PaymentContext paymentContext)
        {
            // Complex logic for BankA payments
            return true;
        }
    }
}
