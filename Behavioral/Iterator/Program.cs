using System.Security.Cryptography.X509Certificates;

public class OrderCollection : IEnumerable<Order>
{
    private readonly List<Order> _orders = new();

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public IEnumerator<Order> GetEnumerator()
    {
        foreach (var order in _orders)
            yield return order;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Order
{
    public  int Id { get; set; }
    public Order()
    {
       
    }
}

public class Program
{

    static void Main(string[] args)
    {
        var orders = new OrderCollection();
        orders.Add(new Order { Id = 1 });
        orders.Add(new Order { Id = 2 });

        foreach (var order in orders)
        {
            Console.WriteLine(order.Id);
        }
    }
}