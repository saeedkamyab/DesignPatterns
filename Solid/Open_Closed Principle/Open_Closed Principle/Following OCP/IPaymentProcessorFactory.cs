namespace Open_Closed_Principle.Following_OCP
{
    public interface IPaymentProcessorFactory
    {
        PaymentProcessor CreatePaymentProcessor(Bank bank);
    }
}
