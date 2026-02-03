using GameDemo.io;

namespace LoggerProjekt;

public class Logger
{
    private readonly IWriter _writer;

    public Logger(IWriter writer)
    {
        _writer = writer;
    }

    void Log(string message)
    {
        const string prefix = "Prefix";// Up zum bauen des prefixes
        _writer.Write($"{prefix}: {message}");
    }
}