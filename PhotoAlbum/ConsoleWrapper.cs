namespace PhotoAlbum;

public interface IConsoleWrapper
{
    void DisplayLine(string text);
    string ReadLine();
}

public class ConsoleWrapper : IConsoleWrapper
{
    public void DisplayLine(string text)
    {
        Console.WriteLine(text);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }
}