namespace GameDemo.io;

public class ConsolenWriter: IWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}