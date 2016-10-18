using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Dolosframework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteAscii("#GSH", Color.Gold);

            Console.WriteLine("dolosframework", Color.DarkGoldenrod);
            Framework.OnLoad();

            while (true)
            {
                Framework.Loop();
            }

            // Console.ReadKey();
            // ReSharper disable once FunctionNeverReturns
        }
    }
}