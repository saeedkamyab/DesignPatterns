public abstract class ReportGenerator
{
    // Template Method
    public void Generate()
    {
        LoadData();
        ProcessData();
        Export();
    }

    protected virtual void LoadData()
    {
        Console.WriteLine("Loading data...");
    }

    // Step متغیر
    protected abstract void ProcessData();

    protected virtual void Export()
    {
        Console.WriteLine("Exporting report...");
    }
}
public class SalesReport : ReportGenerator
{
    protected override void ProcessData()
    {
        Console.WriteLine("Processing sales data");
    }
}
public class InventoryReport : ReportGenerator
{
    protected override void ProcessData()
    {
        Console.WriteLine("Processing inventory data");
    }
}


public class Program
{
    static void Main(string[] args)
    {
        ReportGenerator report = new SalesReport();
        report.Generate();

        report = new InventoryReport();
        report.Generate();
    }
}