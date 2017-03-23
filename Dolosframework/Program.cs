using System.Drawing;
using Colorful;

namespace Dolosframework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteAscii("HA! GAAY!", Color.Gold);
            Framework.OnLoad();
            while (true)
                Framework.Loop();
        }
    }
}