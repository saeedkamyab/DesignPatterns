public interface IFileSystemItem
{
    void Print(int depth = 0);
}
public class FileItem : IFileSystemItem
{
    private readonly string _name;

    public FileItem(string name)
    {
        _name = name;
    }

    public void Print(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth)} File: {_name}");
    }
}
public class Folder : IFileSystemItem
{
    private readonly string _name;
    private readonly List<IFileSystemItem> _items = new();

    public Folder(string name)
    {
        _name = name;
    }

    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public void Print(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth)} Folder: {_name}");

        foreach (var item in _items)
        {
            item.Print(depth + 2);
        }
    }
}



public class Program
{

    static void Main(string[] args)
    {
        var root = new Folder("Root");

        var images = new Folder("Images");
        images.Add(new FileItem("photo1.png"));
        images.Add(new FileItem("photo2.png"));

        var docs = new Folder("Docs");
        docs.Add(new FileItem("resume.pdf"));

        root.Add(images);
        root.Add(docs);
        root.Add(new FileItem("readme.txt"));

        root.Print();

    }
}