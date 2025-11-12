namespace ParaTrooper
{
    static class Constants
    {
        public static float AimSensitivity = 2;
        public static AimPattern AimPattern = AimPattern.Tap;
    }

    public enum AimPattern
    {
        Hold,
        Tap
    }
}