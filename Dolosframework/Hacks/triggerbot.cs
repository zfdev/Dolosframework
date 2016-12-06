using Colorful;
using Dolosframework.CrosshairManager;
using Dolosframework.EntityManager;
using Dolosframework.Math;
using System.Linq;
using System.Threading;

namespace Dolosframework.Hacks
{
    public class TriggerBot : Module
    {
        public static void Activated()
        {
            if (Vector3.IsKeyDown(0x45) || Vector3.IsKeyDown(0x05) || Vector3.IsKeyDown(0x06))
            {
                foreach (var Crosshair in Framework.Crosshair.Crosshair)
                {
                    if (Crosshair.Team != 0)
                    {
                        foreach (var Player in Framework.LocalPlayer.Localplayer)
                        {
                            if (Crosshair.Team != Player.Team)
                            {
                                BaseEntity.SetAttack(1);
                                Thread.Sleep(50);
                                BaseEntity.SetAttack(0);
                            }
                        }
                    }
                }
            }
        }
    }
}