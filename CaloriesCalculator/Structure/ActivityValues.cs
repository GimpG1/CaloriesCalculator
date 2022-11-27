namespace CaloriesCalculator.Structure
{
    public static class ActivityValues
    {
        public static float None => 1.1f;
        public static float VeryLow => 1.2f;

        public static class Female
        {
            public static float Low => 1.4f;
            public static float Average => 1.5f;
            public static float High => 1.8f;
            public static float Veryhigh => 2.1f;
        }
        public static class Male
        {
            public static float Low => 1.5f;
            public static float Average => 1.6f;
            public static float High => 2.0f;
            public static float Veryhigh => 2.3f;
        }
    }
}