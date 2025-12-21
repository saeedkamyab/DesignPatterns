public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public interface IProductService
{
    List<Product> GetProducts();
}


public class ProductService : IProductService
{
    public List<Product> GetProducts()
    {
        Console.WriteLine("Loading from database...");
        Thread.Sleep(2000); // شبیه‌سازی DB سنگین

        return Enumerable.Range(1, 5)
            .Select(i => new Product { Id = i, Name = $"Product {i}" })
            .ToList();
    }
}
public class ProductServiceProxy : IProductService
{
    private readonly IProductService _realService;
    private List<Product>? _cache;

    public ProductServiceProxy(IProductService realService)
    {
        _realService = realService;
    }

    public List<Product> GetProducts()
    {
        if (_cache == null)
        {
            Console.WriteLine("Cache miss → calling real service");
            _cache = _realService.GetProducts();
        }
        else
        {
            Console.WriteLine("Cache hit");
        }

        return _cache;
    }
}



public class Program
{

    static void Main(string[] args)
    {
        IProductService _service;//it must be inject not like this
      
        var real = new ProductService();
        _service = new ProductServiceProxy(real);
    }
}