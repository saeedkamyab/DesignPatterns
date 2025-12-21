public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _instance =
        new(() => new AppConfig());

    public static AppConfig Instance => _instance.Value;

    public string ConnectionString { get; }

    private AppConfig()
    {
        ConnectionString = "Server=.;Database=AppDb;";
    }
}




public class Program
{

    static void Main(string[] args)
    {
        var config1 = AppConfig.Instance;
        var config2 = AppConfig.Instance;

        Console.WriteLine(ReferenceEquals(config1, config2)); // True
    }
}

