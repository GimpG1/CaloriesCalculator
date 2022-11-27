namespace CaloriesCalculator.Structure.Calculations
{
    public sealed class MaleCalculationData : BaseCalculationData
    {
        public override float Base => 66.47f;

        public override float WeightMultiplier => 13.7f;

        public override float HeightMultiplier => 5.0f;

        public override float AgeMultiplier => 6.76f;
    
        public MaleCalculationData(IActivity activity) : base (activity)
        {
        }
    }
}
