public interface ICommand
{
    void Execute();
    void Undo();
}
public class CreateOrderCommand : ICommand
{
    private readonly OrderDto _dto;
    private readonly OrderService _service;

    public CreateOrderCommand(OrderDto dto, OrderService service)
    {
        _dto = dto;
        _service = service;
    }

    public void Execute()
    {
        _service.CreateOrder(_dto);
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}
public class LoggedCommand : ICommand
{
    private readonly ICommand _inner;

    public void Execute()
    {
        Log();
        _inner.Execute();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}


public class Program
{

    static void Main(string[] args)
    {
        OrderService _service; //it must be injected not like this
        ICommand command = new CreateOrderCommand(dto, _service);
        command.Execute();
    }
}