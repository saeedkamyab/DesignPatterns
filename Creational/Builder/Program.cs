public class Report
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IncludeCharts { get; set; }
    public bool IncludeSummary { get; set; }
    public bool IncludeFooter { get; set; }
    public string? Watermark { get; set; }
}
public interface IReportBuilder
{
    IReportBuilder SetTitle(string title);
    IReportBuilder SetAuthor(string author);
    IReportBuilder WithCharts();
    IReportBuilder WithSummary();
    IReportBuilder WithFooter();
    IReportBuilder WithWatermark(string watermark);
    Report Build();
    void Reset();
}
public class ReportBuilder : IReportBuilder
{
    private Report _report = new Report();
    public Report Build()
    {
        var result = _report;
        Reset();
        return result;
    }

    public void Reset()
    {
        _report = new Report();
    }

    public IReportBuilder SetAuthor(string author)
    {
        _report.Author = author;
        return this;
    }

    public IReportBuilder SetTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public IReportBuilder WithCharts()
    {
        _report.IncludeCharts = true;
        return this;
    }

    public IReportBuilder WithFooter()
    {
        _report.IncludeFooter = true;
        return this;
    }

    public IReportBuilder WithSummary()
    {
        _report.IncludeSummary = true;
        return this;
    }

    public IReportBuilder WithWatermark(string watermark)
    {
        _report.Watermark = watermark;
        return this;
    }
}
public class Program
{

    static void Main(string[] args)
    {
        var builder = new ReportBuilder();
        var repo=builder.SetTitle("Annual Report")
            .SetAuthor("John Doe")
            .WithCharts()
            .WithSummary()
            .WithWatermark("Confidential")
            .Build();
    }
}
