namespace Dolosframework.Offset
{
    public class Offsets
    {
        public static class Misc
        {
            public static int Health = 0xFC;
            public static int Team = 0xF0;
            public static int m_vecOrigin = 0x134;
            public static int DwClientState = 0x005C7594;
            public static int fFlags = 0x100;
        }

        public static class LocalPlayer
        {
            public static int dwLocalPlayer = 0xAA38CC;
            public static int m_iCrosshairId = 0xAA70;
            public static int ForceAttack = 0x02F05F84;
            public static int ForceJump = 0x4F5782C;
            public static int m_Local = 0x2FAC;
            public static int m_ViewAngles = 0x4D0C;
            public static int m_aimPunchAngle = 0x301C;
        }

        public static class Entity
        {
            public static int EntityList = 0x04AC5E14;
            public static int m_dwBoneMatrix = 0x2698;
            public static int m_BSpotted = 0x939;
        }
    }
}