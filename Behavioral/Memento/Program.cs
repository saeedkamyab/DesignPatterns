public class EditorMemento
{
    public string Text { get; }

    public EditorMemento(string text)
    {
        Text = text;
    }
}
public class Editor
{
    private string _text = "";

    public void SetText(string text)
    {
        _text = text;
    }

    public EditorMemento Save()
    {
        return new EditorMemento(_text);
    }

    public void Restore(EditorMemento memento)
    {
        _text = memento.Text;
    }

    public void Print()
    {
        Console.WriteLine(_text);
    }
}
public class History
{
    private readonly Stack<EditorMemento> _undoStack = new();

    public void Push(EditorMemento memento)
    {
        _undoStack.Push(memento);
    }

    public EditorMemento Pop()
    {
        return _undoStack.Pop();
    }
}



public class Program
{
    static void Main(string[] args)
    {
        var editor = new Editor();
        var history = new History();

        editor.SetText("Hello");
        history.Push(editor.Save());

        editor.SetText("Hello World");
        history.Push(editor.Save());

        editor.SetText("Hello World !!!");

        editor.Restore(history.Pop());
        editor.Print(); // Hello World

        editor.Restore(history.Pop());
        editor.Print(); // Hello

    }
}