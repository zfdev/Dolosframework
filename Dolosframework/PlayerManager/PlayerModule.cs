using Dolosframework.EntityManager;
using Dolosframework.Offset;
using System;
using System.Collections.Generic;

namespace Dolosframework.PlayerManager
{
    public class PlayerModule : Module
    {
        public readonly List<BaseEntity> Localplayer = new List<BaseEntity>();

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Localplayer.Clear();

            var baseAddress = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.dwLocalPlayer, false);

            if (baseAddress != IntPtr.Zero)
            {
        
                    var player = new BaseEntity(baseAddress);
                    Localplayer.Add(player);
               
            }
        }
    }
}