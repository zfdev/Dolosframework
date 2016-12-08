using Dolosframework.Math;
using Dolosframework.Offset;
using System;

namespace Dolosframework.EntityManager
{
    public class BaseEntity
    {
        private readonly IntPtr baseAddress;

        public BaseEntity(IntPtr baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        /// <summary>
        /// Returns the entities health
        /// </summary>
        public int Health => Framework.Memory.Read<int>(baseAddress + Offsets.Misc.Health, false);

        /// <summary>
        /// Returns the entities team
        /// </summary>
        public int Team => Framework.Memory.Read<int>(baseAddress + Offsets.Misc.Team, false);

        /// <summary>
        /// Returns true if they are spotted false if they are not
        /// </summary>
        public bool Spotted => Framework.Memory.Read<bool>(baseAddress + Offsets.Entity.m_BSpotted, false);

        /// <summary>
        /// return the clientstate
        /// </summary>
        public IntPtr ClientState => Framework.Memory.Read<IntPtr>(Framework.EngineDll.BaseAddress + Offsets.Misc.DwClientState, false);


        public IntPtr InGame => Framework.Memory.Read<IntPtr>(ClientState + 0xE8);
        /// <summary>
        ///Set Enemys as spotted on the radar
        /// </summary>
        /// <param name="value">1 to set them as spotted 0 to remove them as spotted</param>
        public void SetSpotted(int value) => Framework.Memory.Write<int>(baseAddress + Offsets.Entity.m_BSpotted, value, false);

        /// <summary>
        /// Returns the entities bonebase
        /// </summary>
        ///
        public IntPtr BoneBase => Framework.Memory.Read<IntPtr>(baseAddress + Offsets.Entity.m_dwBoneMatrix, false);

        /// <summary>
        /// Returns the entities position
        /// </summary>
        public Vector3 Position => Framework.Memory.Read<Vector3>(baseAddress + Offsets.Misc.m_vecOrigin, false);

        public float Distance
        {
            get
            {
                var xx = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.dwLocalPlayer, false);
                var positionLocal = Framework.Memory.Read<Vector3>(xx + Offsets.Misc.m_vecOrigin, false);

                return positionLocal.DistanceTo(Position);
            }
        }

        /// <summary>
        /// Returns the entities position of the bone they want [6 head]
        /// </summary>
        public Vector3 BonePosition(int boneId)
        {
            Vector3 bonepos;

            bonepos.X = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x0C, false);
            bonepos.Y = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x1C, false);
            bonepos.Z = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x2C, false);
            return bonepos;
        }

        public static void SetAttack(int value)
        {
            Framework.Memory.Write<int>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.ForceAttack, value, false);
        }
    }
}