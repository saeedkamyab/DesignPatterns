public interface IOrderObserver
{
    void OnOrderCreated(Order order);
}
public class OrderService
{
    private readonly List<IOrderObserver> _observers = new();

    public void Subscribe(IOrderObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IOrderObserver observer)
    {
        _observers.Remove(observer);
    }

    public void CreateOrder(Order order)
    {
        Console.WriteLine("Order created");

        Notify(order);
    }

    private void Notify(Order order)
    {
        foreach (var observer in _observers)
        {
            observer.OnOrderCreated(order);
        }
    }
}
public class EmailObserver : IOrderObserver
{
    public void OnOrderCreated(Order order)
    {
        Console.WriteLine("Email sent");
    }
}
public class InventoryObserver : IOrderObserver
{
    public void OnOrderCreated(Order order)
    {
        Console.WriteLine("Inventory updated");
    }
}

public class Order
{
}

public class Program
{
    static void Main(string[] args)
    {
        var orderService = new OrderService();

        orderService.Subscribe(new EmailObserver());
        orderService.Subscribe(new InventoryObserver());

        orderService.CreateOrder(new Order());

    }
}