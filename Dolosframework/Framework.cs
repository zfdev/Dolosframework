using System;
using System.Diagnostics;
using System.Linq;
using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Modules;
using Dolosframework.CrosshairManager;
using Dolosframework.EntityManager;
using Dolosframework.Hacks;
using Dolosframework.Math;
using Dolosframework.Offset;
using Dolosframework.PlayerManager;

namespace Dolosframework
{
    public static class Framework
    {
        public static MemorySharp Memory { get; private set; }
        public static RemoteModule ClientDll { get; private set; }
        public static RemoteModule EngineDll { get; private set; }
        public static PlayerModule LocalPlayer { get; private set; }
        public static EntitesModule Entities { get; private set; }
        public static CrosshairModule Crosshair { get; private set; }


        public static void OnLoad()
        {
            var processes = Process.GetProcessesByName("csgo");
            while (processes.Length == 0)
            {
                Console.WriteLine(@"Waiting for csgo to start");
                if (processes.Length == 1)
                    break;
            }

            while (ClientDll == null || EngineDll == null)
            {
                var sharp = new MemorySharp(processes[0]);
                ClientDll = sharp.Modules.RemoteModules.FirstOrDefault(f => f.Name == "client.dll");
                EngineDll = sharp.Modules.RemoteModules.FirstOrDefault(f => f.Name == "engine.dll");
            }

            Entities = new EntitesModule();
            LocalPlayer = new PlayerModule();
            Crosshair = new CrosshairModule();
            Memory = new MemorySharp(processes[0]);
        }

        internal static void Loop()
        {
            var x = Memory.Read<IntPtr>(EngineDll.BaseAddress + Offsets.signatures.dwClientState, false);
            var f = Memory.Read<int>(x + 0x100, false);


            if (f == 6)
            {
                LocalPlayer.Update();
                Entities.Update();
                Crosshair.Update();
                // TODO!! Make better aimbot
                //foreach (var enemies in Entities.Entities)
                //foreach (var player in LocalPlayer.Localplayer)
                //{
                //    //Console.WriteLine(player.CurrentWeapon);
                //    if (enemies.Health <= 1) continue;
                //    var currentViewAngle = player.ViewAngles;
                //    var localHeadPos = player.LocalEyePosition;
                //    var enemyHeadPos = enemies.BonePosition(8);

                //    var calculatedAngle = localHeadPos.CalcAngle(enemyHeadPos);
                //    var clampedAngle = calculatedAngle.ClampAngle();
                //    var Fov =
                //        System.Math.Sqrt(System.Math.Pow(clampedAngle.X - currentViewAngle.X, 2) +
                //                         System.Math.Pow(clampedAngle.Y - currentViewAngle.Y, 2));
                //    if (!(Fov < 2)) continue;
                //        if (IsDown)
                //        {


                //        } 
                //    }


                //Bunnyhop.Activated();
                //TriggerBot.Activated();

                var IsDown = (Vector3.GetKeyState(0x48) & 0xFF00) != 0;
                var Toggled = Vector3.GetKeyState(0x48) != 0;

                Bspotted.Activated();
            }
        }
    }
}