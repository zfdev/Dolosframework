using System;
using System.Linq;

namespace Dolosframework.Hacks
{
    public class Bspotted : Module
    {
        public static void Activated()
        {
            Framework.Entities.Entities.ForEach((enemy) => enemy.SetSpotted(1));
        }
    }
}