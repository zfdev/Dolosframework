namespace Dolosframework.Offset
{
    public class Offsets
    {
        public static class Misc
        {
            public static int Health = 0xFC;
            public static int Team = 0xF0;
            public static int m_vecOrigin = 0x134;
            public static int DwClientState = 0x5C02C4;
        }

        public static class LocalPlayer
        {
            public static int dwLocalPlayer = 0x00A9E8E4;
            public static int m_iCrosshairId = 0x0000AA70;
            public static int ForceAttack = 0x02F00DF4;
            public static int m_Local = 0x2FAC;
            public static int m_ViewAngles = 0x4D0C;
            public static int m_aimPunchAngle = 0x301C;
        }

        public static class Entity
        {
            public static int EntityList = 0x04AC0CA4;
            public static int m_dwBoneMatrix = 0x2698;
            public static int m_BSpotted = 0x939;
        }
    }
}