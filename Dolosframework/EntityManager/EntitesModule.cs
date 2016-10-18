using Dolosframework.Offset;
using System;
using System.Collections.Generic;

namespace Dolosframework.EntityManager
{
    public class EntitesModule : Module
    {
        public List<BaseEntity> Entities = new List<BaseEntity>();

        protected override void OnUpdate()
        {
            base.OnUpdate();

            Entities.Clear();
            for (var index = 0; index < 32; index++)
            {
                var localPlayer = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.dwLocalPlayer, false);
                var baseAddress = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.Entity.EntityList + (index) * 0x10, false);
                if (baseAddress == IntPtr.Zero || baseAddress == localPlayer) continue;
                var entity = new BaseEntity(baseAddress);

                Entities.Add(entity);
            }
        }
    }
}