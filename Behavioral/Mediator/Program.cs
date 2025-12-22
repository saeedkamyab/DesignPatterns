public interface IRequest { }
public interface IMediator
{
    void Send(IRequest request);
}
public class CreateOrderRequest : IRequest
{
    public int ProductId { get; }
    public int Quantity { get; }

    public CreateOrderRequest(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
public interface IRequestHandler<T> where T : IRequest
{
    void Handle(T request);
}
public class CreateOrderHandler
    : IRequestHandler<CreateOrderRequest>
{
    private readonly OrderService _order;
    private readonly InventoryService _inventory;
    private readonly PaymentService _payment;

    public CreateOrderHandler(
        OrderService order,
        InventoryService inventory,
        PaymentService payment)
    {
        _order = order;
        _inventory = inventory;
        _payment = payment;
    }

    public void Handle(CreateOrderRequest request)
    {
        _order.Create(request);
        _inventory.Reserve(request.ProductId, request.Quantity);
        _payment.Pay();
    }
}
public class Mediator : IMediator
{
    private readonly IServiceProvider _provider;

    public Mediator(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void Send(IRequest request)
    {
        var handlerType = typeof(IRequestHandler<>)
            .MakeGenericType(request.GetType());

        dynamic handler = _provider.GetService(handlerType);
        handler.Handle((dynamic)request);
    }
}



public class Program
{
    static void Main(string[] args)
    {
        IMediator _mediator; //it must be inject

        _mediator.Send(
            new CreateOrderRequest(dto.ProductId, dto.Quantity));
    }
}