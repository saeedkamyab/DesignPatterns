namespace Open_Closed_Principle.Following_OCP
{
    public class BankBPaymentProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(PaymentContext paymentContext)
        {
            // Complex logic for BankB payments
            return false;
        }
    }
}
