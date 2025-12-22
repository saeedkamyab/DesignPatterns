public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}
public interface IDocumentVisitor
{
    void Visit(TextElement text);
    void Visit(ImageElement image);
}

public class TextElement : IDocumentElement
{
    public string Text { get; }

    public TextElement(string text)
    {
        Text = text;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ImageElement : IDocumentElement
{
    public int Width { get; }
    public int Height { get; }

    public ImageElement(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class SizeCalculatorVisitor : IDocumentVisitor
{
    public int TotalSize { get; private set; }

    public void Visit(TextElement text)
    {
        TotalSize += text.Text.Length;
    }

    public void Visit(ImageElement image)
    {
        TotalSize += image.Width * image.Height;
    }
}


public class RenderVisitor : IDocumentVisitor
{
    public void Visit(TextElement text)
    {
        Console.WriteLine($"Render text: {text.Text}");
    }

    public void Visit(ImageElement image)
    {
        Console.WriteLine($"Render image {image.Width}x{image.Height}");
    }
}


public class Program
{
    static void Main(string[] args)
    {
        var document = new List<IDocumentElement>
{
    new TextElement("Hello"),
    new ImageElement(100, 200),
    new TextElement("Visitor Pattern")
};

        var sizeVisitor = new SizeCalculatorVisitor();
        foreach (var element in document)
        {
            element.Accept(sizeVisitor);
        }

        Console.WriteLine(sizeVisitor.TotalSize);

        var renderVisitor = new RenderVisitor();
        foreach (var element in document)
        {
            element.Accept(renderVisitor);
        }

    }
}