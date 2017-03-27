using System.Drawing;
using Colorful;

namespace Dolosframework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteAscii("jewkiller2000", Color.Gold);
            Framework.OnLoad();
            while (true)
                Framework.Loop();
        }
    }
}