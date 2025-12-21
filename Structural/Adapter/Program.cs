public interface IPaymentGateway
{
    void Pay(decimal amount);
}
public class LegacyBankApi
{
    public void MakePayment(double money)
    {
        Console.WriteLine($"Paid {money} via bank");
    }
}
public class BankApiAdapter : IPaymentGateway
{
    private readonly LegacyBankApi _bankApi;

    public BankApiAdapter(LegacyBankApi bankApi)
    {
        _bankApi = bankApi;
    }

    public void Pay(decimal amount)
    {
        _bankApi.MakePayment((double)amount);
    }
}
public class Program
{

    static void Main(string[] args)
    {
        IPaymentGateway payment =
     new BankApiAdapter(new LegacyBankApi());
        payment.Pay(100);

    }
}
