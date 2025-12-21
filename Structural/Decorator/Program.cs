public interface ILogger
{
    void Log(string message);
}
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
public abstract class LoggerDecorator : ILogger
{
    protected readonly ILogger _inner;

    protected LoggerDecorator(ILogger inner)
    {
        _inner = inner;
    }

    public virtual void Log(string message)
    {
        _inner.Log(message);
    }
}
public class TimestampLogger : LoggerDecorator
{
    public TimestampLogger(ILogger inner) : base(inner) { }

    public override void Log(string message)
    {
        var msg = $"[{DateTime.Now}] {message}";
        base.Log(msg);
    }
}

public class EncryptedLogger : LoggerDecorator
{
    public EncryptedLogger(ILogger inner) : base(inner) { }

    public override void Log(string message)
    {
        var encrypted = Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(message));

        base.Log(encrypted);
    }
}
public class Program
{

    static void Main(string[] args)
    {
        ILogger logger =
     new EncryptedLogger(
         new TimestampLogger(
             new ConsoleLogger()));

        logger.Log("Hello Decorator");

    }
}