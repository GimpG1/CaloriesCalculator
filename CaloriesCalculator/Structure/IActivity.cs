namespace CaloriesCalculator.Structure
{
    public interface IActivity
    {
        public float GetActivityFor(Protos.ActivityLevel activity, Protos.SexOrientation sex);
    }
}
