namespace ClickGame;

internal static class Tracer
{
    public static readonly ConsoleColor InfoColor = ConsoleColor.Blue;
    public static readonly ConsoleColor WarningColor = ConsoleColor.Yellow;
    public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;

    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = InfoColor;
        Console.WriteLine($"[SYS:Info] {message}");
        Console.ResetColor();
    }

    public static void WriteWarning(string message)
    {
        Console.ForegroundColor = WarningColor;
        Console.WriteLine($"[SYS:Warning] {message}");
        Console.ResetColor();
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ErrorColor;
        Console.WriteLine($"[SYS:Error] {message}");
        Console.ResetColor();
    }
}