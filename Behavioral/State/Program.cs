
public interface IOrderState
{
    void Pay(OrderContext order);
    void Ship(OrderContext order);
    void Cancel(OrderContext order);
}
public class OrderContext
{
    private IOrderState _state;

    public OrderContext()
    {
        _state = new CreatedState();
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void Pay() => _state.Pay(this);
    public void Ship() => _state.Ship(this);
    public void Cancel() => _state.Cancel(this);
}
public class CreatedState : IOrderState
{
    public void Pay(OrderContext order)
    {
        Console.WriteLine("Order paid");
        order.SetState(new PaidState());
    }

    public void Ship(OrderContext order)
    {
        throw new Exception("Cannot ship unpaid order");
    }

    public void Cancel(OrderContext order)
    {
        Console.WriteLine("Order cancelled");
        order.SetState(new CancelledState());
    }
}
public class PaidState : IOrderState
{
    public void Pay(OrderContext order)
    {
        throw new Exception("Already paid");
    }

    public void Ship(OrderContext order)
    {
        Console.WriteLine("Order shipped");
        order.SetState(new ShippedState());
    }

    public void Cancel(OrderContext order)
    {
        throw new Exception("Cannot cancel paid order");
    }
}
public class ShippedState : IOrderState
{
    public void Pay(OrderContext order)
    {
        throw new Exception("Already shipped");
    }

    public void Ship(OrderContext order)
    {
        throw new Exception("Already shipped");
    }

    public void Cancel(OrderContext order)
    {
        throw new Exception("Cannot cancel shipped order");
    }
}
public class CancelledState : IOrderState
{
    public void Pay(OrderContext order)
    {
        throw new Exception("Order cancelled");
    }

    public void Ship(OrderContext order)
    {
        throw new Exception("Order cancelled");
    }

    public void Cancel(OrderContext order)
    {
        throw new Exception("Already cancelled");
    }
}


public class Program
{
    static void Main(string[] args)
    {

        var order = new OrderContext();

        order.Pay();    // Created → Paid
        order.Ship();   // Paid → Shipped
        order.Cancel(); // ❌ Exception

    }
}