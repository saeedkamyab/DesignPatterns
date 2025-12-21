public class AuthService
{
    public bool Login() => true;
}

public class FraudService
{
    public bool Check() => true;
}

public class BankService
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount}");
    }
}

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}
public class PaymentFacade
{
    private readonly AuthService _auth = new();
    private readonly FraudService _fraud = new();
    private readonly BankService _bank = new();
    private readonly Logger _logger = new();

    public void Pay(decimal amount)
    {
        if (!_auth.Login())
            throw new Exception("Auth failed");

        if (!_fraud.Check())
            throw new Exception("Fraud detected");

        _bank.Pay(amount);
        _logger.Log("Payment successful");
    }
}


public class Program
{

    static void Main(string[] args)
    {
        var payment = new PaymentFacade();
        payment.Pay(500);

    }
}