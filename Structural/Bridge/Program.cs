public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}
public abstract class Notification
{
    protected readonly IMessageSender _sender;

    protected Notification(IMessageSender sender)
    {
        _sender = sender;
    }

    public abstract void Notify(string message);
}
public class AlertNotification : Notification
{
    public AlertNotification(IMessageSender sender) : base(sender) { }

    public override void Notify(string message)
    {
        _sender.Send("ALERT: " + message);
    }
}

public class ReminderNotification : Notification
{
    public ReminderNotification(IMessageSender sender) : base(sender) { }

    public override void Notify(string message)
    {
        _sender.Send("REMINDER: " + message);
    }
}


public class Program
{

    static void Main(string[] args)
    {
        var emailAlert =
     new AlertNotification(new EmailSender());

        var smsReminder =
            new ReminderNotification(new SmsSender());

        emailAlert.Notify("Server down");
        smsReminder.Notify("Meeting at 10");

    }
}
