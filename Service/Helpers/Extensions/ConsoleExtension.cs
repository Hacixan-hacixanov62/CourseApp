

namespace Service.Helpers.Extensions
{
    public static   class ConsoleExtension
    {
        public static void WriteConsole(this ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
