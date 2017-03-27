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

        public int CurrentWeapon
        {
            get
            {
                var WeaponIndex = Framework.Memory.Read<int>(LocalPlayer + Offsets.netvars.m_hActiveWeapon, false) & 0xFFF;
                var WeapnEntity = Framework.Memory.Read<int>(Framework.ClientDll.BaseAddress + (int) baseAddress);
                return WeaponIndex;

            }
        }


        /// <summary>
        /// Returns the entities health
        /// </summary>
        public int Health => Framework.Memory.Read<int>(baseAddress + Offsets.netvars.m_iHealth, false);

        /// <summary>
        /// Returns the entities team
        /// </summary>
        public int Team => Framework.Memory.Read<int>(baseAddress + Offsets.netvars.m_iTeamNum, false);

        /// <summary>
        /// Returns true if they are spotted false if they are not
        /// </summary>
        public bool Spotted => Framework.Memory.Read<bool>(baseAddress + Offsets.netvars.m_bSpotted, false);

        /// <summary>
        /// return the clientstate
        /// </summary>
        public IntPtr ClientState => Framework.Memory.Read<IntPtr>(Framework.EngineDll.BaseAddress + Offsets.signatures.dwClientState, false);

        /// <summary>
        /// Return flags for bunnyhop
        /// </summary>
        public byte Flags => Framework.Memory.Read<byte>(baseAddress + Offsets.netvars.m_fFlags, false);

        public Vector3 VecPunch => Framework.Memory.Read<Vector3>(baseAddress + Offsets.netvars.m_aimPunchAngle, false);

        public IntPtr LocalPlayer => Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.signatures.dwLocalPlayer, false);


        public Vector3 Origin => Framework.Memory.Read<Vector3>(baseAddress + Offsets.netvars.m_vecOrigin, false);

        public Vector3 eyepos => Framework.Memory.Read<Vector3>(LocalPlayer + Offsets.netvars.m_vecViewOffset, false);


        public Vector3 ViewAngles => Framework.Memory.Read<Vector3>(ClientState + Offsets.signatures.dwClientState_ViewAngles, false);

        public void SetViewAngle(Vector3 value) => Framework.Memory.Write(ClientState + Offsets.signatures.dwClientState_ViewAngles, value, false);
            
        public void SetJump(int value) => Framework.Memory.Write(baseAddress + Offsets.signatures.dwForceJump, value, false);
       
        /// <summary>
        ///Set Enemys as spotted on the radar
        /// </summary>
        /// <param name="value">1 to set them as spotted 0 to remove them as spotted</param>
        public void SetSpotted(int value) => Framework.Memory.Write(baseAddress + Offsets.netvars.m_bSpotted, value, false);

        /// <summary>
        /// Returns the entities bonebase
        /// </summary>
        ///
        public IntPtr BoneBase => Framework.Memory.Read<IntPtr>(baseAddress + Offsets.netvars.m_dwBoneMatrix, false);

        /// <summary>
        /// Returns the entities position
        /// </summary>
        public Vector3 Position => Framework.Memory.Read<Vector3>(baseAddress + Offsets.netvars.m_vecOrigin, false);

        public Vector3 LocalEyePosition
        {
            get
            {
                var x = Framework.Memory.Read<Vector3>(baseAddress + Offsets.netvars.m_vecOrigin, false);
                var y = Framework.Memory.Read<Vector3>(baseAddress + Offsets.netvars.m_vecViewOffset, false);
                return x+y;
            }
        }


        public float Distance
        {
            get
            {
                var xx = Framework.Memory.Read<IntPtr>(Framework.ClientDll.BaseAddress + Offsets.signatures.dwLocalPlayer, false);
                var positionLocal = Framework.Memory.Read<Vector3>(xx + Offsets.netvars.m_vecOrigin, false);

                return Position.DistanceTo(positionLocal);
            }
        }



        /// <summary>
        /// Returns the entities position of the bone they want [6 head]
        /// </summary>
        public Vector3 BonePosition(int boneId)
        {
            Vector3 bonepos;

            if (BoneBase == IntPtr.Zero)
            {
                bonepos.X = 0;
                bonepos.Y = 0;
                bonepos.Z = 0;
                return bonepos;
            }   
           

            bonepos.X = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x0C, false);
            bonepos.Y = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x1C, false);
            bonepos.Z = Framework.Memory.Read<float>(BoneBase + 0x30 * boneId + 0x2C, false);
            return bonepos;
            
        }

        public static void SetAttack(int value)
        {
            Framework.Memory.Write<int>(Framework.ClientDll.BaseAddress + Offsets.signatures.dwForceAttack, value, false);
        }


    }
}