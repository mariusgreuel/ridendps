using System;

namespace DPS
{
    public class ColoredConsole : IDisposable
    {
        public ColoredConsole(ConsoleColor color)
        {
            oldConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }

        public void Dispose()
        {
            Console.ForegroundColor = oldConsoleColor;
        }

        ConsoleColor oldConsoleColor;
    }
}
