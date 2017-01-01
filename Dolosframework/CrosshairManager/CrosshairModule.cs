using Dolosframework.EntityManager;
using Dolosframework.Offset;
using System;
using System.Collections.Generic;

namespace Dolosframework.CrosshairManager
{
    public class CrosshairModule : Module
    {
        public readonly List<BaseEntity> Crosshair = new List<BaseEntity>();

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Crosshair.Clear();

            var baseAddress = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.Signatures.dwLocalPlayer, false);
            var crosshairId = Framework.Memory.Read<int>(baseAddress + Offsets.Netvars.m_iCrosshairId, false);
            var baseCrosshair = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.Signatures.dwEntityList + (crosshairId - 1) * 0x10, false);

            if (baseCrosshair == IntPtr.Zero) return;
            var baseaddress = new BaseEntity(baseCrosshair);
            Crosshair.Add(baseaddress);
        }
    }
}