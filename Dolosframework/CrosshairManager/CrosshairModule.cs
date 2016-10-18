using Dolosframework.Offset;
using System;
using System.Collections.Generic;

namespace Dolosframework.CrosshairManager
{
    public class CrosshairModule : Module
    {
        public readonly List<BaseCrosshair> Crosshair = new List<BaseCrosshair>();

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Crosshair.Clear();

            var baseAddress = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.dwLocalPlayer, false);
            var crosshairId = Framework.Memory.Read<int>(baseAddress + Offsets.LocalPlayer.m_iCrosshairId, false);
            var baseCrosshair = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.Entity.EntityList + (crosshairId - 1) * 0x10, false);

            if (baseCrosshair == IntPtr.Zero) return;
            var baseaddress = new BaseCrosshair(baseCrosshair);
            Crosshair.Add(baseaddress);
        }
    }
}