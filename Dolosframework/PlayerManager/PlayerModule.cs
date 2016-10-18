using Dolosframework.Offset;
using System;
using System.Collections.Generic;

namespace Dolosframework.PlayerManager
{
    public class PlayerModule : Module
    {
        public List<BasePlayer> Localplayer = new List<BasePlayer>();

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Localplayer.Clear();

            var baseAddress = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.dwLocalPlayer, false);

            if (baseAddress == IntPtr.Zero) return;
            var player = new BasePlayer(baseAddress);
            Localplayer.Add(player);
        }
    }
}