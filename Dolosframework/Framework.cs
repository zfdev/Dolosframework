using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Modules;
using Dolosframework.CrosshairManager;
using Dolosframework.EntityManager;
using Dolosframework.Hacks;
using Dolosframework.PlayerManager;
using System;
using System.Diagnostics;
using System.Linq;

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
            }

            while (ClientDll == null || EngineDll == null)
            {
                var sharp = new MemorySharp(Process.GetProcessesByName("csgo")[0]);
                ClientDll = sharp.Modules.RemoteModules.FirstOrDefault(f => f.Name == "client.dll");
                EngineDll = sharp.Modules.RemoteModules.FirstOrDefault(f => f.Name == "engine.dll");
            }

            Entities = new EntitesModule();
            LocalPlayer = new PlayerModule();
            Crosshair = new CrosshairModule();

            Memory = new MemorySharp(Process.GetProcessesByName("csgo")[0]);
        }

        internal static void Loop()
        {
            Entities.Update();
            Crosshair.Update();
            LocalPlayer.Update();

            Bspotted.Activated();
            Triggerbot.Activated();
        }
    }
}