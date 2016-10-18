using Dolosframework.Math;
using Dolosframework.Offset;
using System;

namespace Dolosframework.CrosshairManager
{
    public class BaseCrosshair
    {
        private readonly IntPtr baseCrosshair;

        public BaseCrosshair(IntPtr baseCrosshair)
        {
            this.baseCrosshair = baseCrosshair;
        }

        public int Team => Framework.Memory.Read<int>(baseCrosshair + Offsets.Misc.Team, false);

        private IntPtr BoneBase => Framework.Memory.Read<IntPtr>(baseCrosshair + Offsets.Entity.m_dwBoneMatrix, false);

        public Vector3 BonePosition(int boneId)
        {
            Vector3 bonepos;

            bonepos.X = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x0C, false);
            bonepos.Y = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x1C, false);
            bonepos.Z = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x2C, false);
            return bonepos;
        }
    }
}