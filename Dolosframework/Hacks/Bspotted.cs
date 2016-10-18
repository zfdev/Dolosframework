using System;
using System.Linq;

namespace Dolosframework.Hacks
{
    public partial class Bspotted
    {
        public static void Activated()
        {
            Framework.Entities.Entities.ForEach((enemy) => enemy.SetSpotted(1));
        }
    }
}