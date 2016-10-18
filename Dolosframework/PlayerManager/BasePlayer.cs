using Dolosframework.Math;
using Dolosframework.Offset;
using System;

namespace Dolosframework.PlayerManager
{
    public class BasePlayer
    {
        public readonly IntPtr BaseAddress;

        /// <summary>
        /// The Base Address for the localplayer
        /// </summary>
        /// <param name="baseAddress"></param>
        public BasePlayer(IntPtr baseAddress)
        {
            this.BaseAddress = baseAddress;
        }

        #region Localplayer info

        /// <summary>
        /// Returns the localplayers health
        /// </summary>
        public int Health => Framework.Memory.Read<int>(BaseAddress + Offsets.Misc.Health, false);

        /// <summary>
        /// Returns the localplayers health
        /// </summary>
        public int Team => Framework.Memory.Read<int>(BaseAddress + Offsets.Misc.Team, false);

        /// <summary>
        /// Returns the base address of the enemy or entity in the crosshair
        /// </summary>
        public int Crosshair => Framework.Memory.Read<int>(BaseAddress + Offsets.LocalPlayer.m_iCrosshairId, false);

        public IntPtr ClientState => Framework.Memory.Read<IntPtr>(Framework.EngineDll.BaseAddress + Offsets.Misc.DwClientState, false);

        #endregion Localplayer info

        #region Vector3

        /// <summary>
        /// Returns Players position
        /// </summary>
        ///

        public Vector3 Position => Framework.Memory.Read<Vector3>(BaseAddress + Offsets.Misc.m_vecOrigin, false);

        /// <summary>
        /// Have no idea what this do
        /// </summary>
        public Vector3 VecView => Framework.Memory.Read<Vector3>(BaseAddress + Offsets.LocalPlayer.m_ViewAngles, false);

        /// <summary>
        /// Returns the eyeposition
        /// </summary>
        ///
        public Vector3 EyePos => Position + VecView;

        public Vector3 ViewAngle => Framework.Memory.Read<Vector3>(ClientState + Offsets.LocalPlayer.m_ViewAngles, false);

        public Vector3 VecPunch => Framework.Memory.Read<Vector3>(BaseAddress + Offsets.LocalPlayer.m_aimPunchAngle, false);

        public void SetViewAngles(Vector3 SetView)
        {
            var clientState = Framework.Memory.Read<IntPtr>(Framework.EngineDll.BaseAddress + 0x005BB2C4, false);
            Framework.Memory.Write<Vector3>(clientState + 0x00004D0C, SetView, false);
        }

        #endregion Vector3

        #region Write to client

        /// <summary>
        /// Insert int to shoot
        /// </summary>
        /// <param name="Value">1 to attack 0 to not attack</param>
        public void SetAttack(int Value)
        {
            Framework.Memory.Write<int>(Framework.ClientDll.BaseAddress + Offsets.LocalPlayer.ForceAttack, Value, false);
        }

        #endregion Write to client
    }
}