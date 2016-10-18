using Dolosframework.CrosshairManager;
using Dolosframework.Math;
using System.Linq;
using System.Threading;

namespace Dolosframework.Hacks
{
    public partial class Triggerbot : Module
    {
        public static void Activated()
        {
            foreach (var x in Framework.Crosshair.Crosshair)
            {
                foreach (var f in Framework.LocalPlayer.Localplayer)
                {
                    var myTeam = f.Team;
                    if (x.Team == myTeam)
                    {
                    }
                    else if (x.Team == 0)
                    {
                    }
                    else if (x.Team != myTeam)
                    {
                        if (Vector3.IsKeyDown(0x06))
                        {
                            f.SetAttack(1);
                            Thread.Sleep(50);
                            f.SetAttack(0);
                        }
                    }
                }
            }
        }
    }
}