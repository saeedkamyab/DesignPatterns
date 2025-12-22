public interface IPaymentStrategy
{
    void Pay(decimal amount);
}
public class CashPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} by cash");
    }
}

public class CardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} by card");
    }
}

public class CryptoPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} by crypto");
    }
}
public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public PaymentContext(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Pay(decimal amount)
    {
        _strategy.Pay(amount);
    }
}




public class Program
{
    static void Main(string[] args)
    {

        var payment = new PaymentContext(new CashPayment());
        payment.Pay(100);

        payment.SetStrategy(new CardPayment());
        payment.Pay(200);


    }
}