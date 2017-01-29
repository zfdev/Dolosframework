using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Modules;
using Dolosframework.CrosshairManager;
using Dolosframework.EntityManager;
using Dolosframework.Hacks;
using Dolosframework.PlayerManager;
using System;
using System.Diagnostics;
using System.Linq;
using Dolosframework.Offset;

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
        private static TriggerBot Triggerbot { get; set; }
        

        public static void OnLoad()
        {
            var processes = Process.GetProcessesByName("csgo");
            while (processes.Length == 0)
            {
                Console.WriteLine(@"Waiting for csgo to start");
                if (processes.Length == 1)
                {
                    break;
                }
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
            Triggerbot = new TriggerBot();
  
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

                //foreach (var enemy in Framework.Crosshair.Crosshair)
                //{
                //    var enemyhead = enemy.BonePosition(6);

                //    foreach (var localplayer in Framework.LocalPlayer.Localplayer)
                //    {
                //        var ff = localplayer.viewangles;
                //        Console.WriteLine(ff.ToString());
                //    }
                //}

                Bunnyhop.Activated();
                Bspotted.Activated();
                TriggerBot.Activated();

            }
        }
    }
}