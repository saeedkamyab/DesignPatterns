public class TreeType
{
    public string Name { get; }
    public string Mesh { get; }
    public string Texture { get; }

    public TreeType(string name, string mesh, string texture)
    {
        Name = name;
        Mesh = mesh;
        Texture = texture;
    }

    public void Render(int x, int y)
    {
        Console.WriteLine(
            $"Render {Name} at ({x},{y}) with {Mesh}/{Texture}");
    }
}
public class TreeFactory
{
    private readonly Dictionary<string, TreeType> _types = new();

    public TreeType GetTreeType(string name, string mesh, string texture)
    {
        var key = $"{name}-{mesh}-{texture}";

        if (!_types.ContainsKey(key))
        {
            _types[key] = new TreeType(name, mesh, texture);
        }

        return _types[key];
    }
}
public class Tree
{
    private readonly int _x;
    private readonly int _y;
    private readonly TreeType _type;

    public Tree(int x, int y, TreeType type)
    {
        _x = x;
        _y = y;
        _type = type;
    }

    public void Draw()
    {
        _type.Render(_x, _y);
    }
}



public class Program
{

    static void Main(string[] args)
    {
        var factory = new TreeFactory();
        var forest = new List<Tree>();

        for (int i = 0; i < 100_000; i++)
        {
            var type = factory.GetTreeType("Oak", "oak.mesh", "oak.png");
            forest.Add(new Tree(i, i * 2, type));
        }

        forest.ForEach(t => t.Draw());

    }
}