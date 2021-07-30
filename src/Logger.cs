using Riden;
using System;

namespace DPS
{
    class Logger : IModbusLogger
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
