namespace CaloriesCalculator.Structure
{
    public sealed class ActivityLevel : IActivity
    {
        public float GetActivityFor(Protos.ActivityLevel activity, Protos.SexOrientation sex)
        {
            switch (activity)
            {
                case Protos.ActivityLevel.None:
                    return GetNoneActivity();
                case Protos.ActivityLevel.Verylow:
                    return GetVeryLowActivity();
                case Protos.ActivityLevel.Low:
                    return GetLowActivity(sex);
                case Protos.ActivityLevel.Average:
                    return GetAverageActivity(sex);
                case Protos.ActivityLevel.High:
                    return GetHighActivity(sex);
                case Protos.ActivityLevel.Veryhigh:
                    return GetVeryHighActivity(sex);
                default:
                    return 0f;
            }
        }

        private float GetNoneActivity()
        {
            return ActivityValues.None;
        }

        private float GetVeryLowActivity()
        {
            return ActivityValues.VeryLow;
        }

        private float GetLowActivity(Protos.SexOrientation sex)
        {
            if (sex == Protos.SexOrientation.Female)
            {
                return ActivityValues.Female.Low;
            }
            return ActivityValues.Male.Low;
        }

        private float GetAverageActivity(Protos.SexOrientation sex)
        {
            if (sex == Protos.SexOrientation.Female)
            {
                return ActivityValues.Female.Average;
            }
            return ActivityValues.Male.Average;
        }

        private float GetHighActivity(Protos.SexOrientation sex)
        {
            if (sex == Protos.SexOrientation.Female)
            {
                return ActivityValues.Female.High;
            }
            return ActivityValues.Male.High;
        }

        private float GetVeryHighActivity(Protos.SexOrientation sex)
        {
            if (sex == Protos.SexOrientation.Female)
            {
                return ActivityValues.Female.Veryhigh;
            }
            return ActivityValues.Male.Veryhigh;
        }
    }
}