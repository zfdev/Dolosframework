using System;
using System.Linq;

namespace Dolosframework.Hacks
{
    public class Bspotted : Module
    {
        public void Activate()
        {
            Framework.Entities.Entities.ForEach((enemy) => enemy.SetSpotted(1));
        }

        public void Deactivate()
        {
            Framework.Entities.Entities.ForEach((enemy) => enemy.SetSpotted(0));
        }
    }
}