namespace CaloriesCalculator.Structure.Calculations
{
    public sealed class FemaleCalculationData : BaseCalculationData
    {
        public override float Base => 655.1f;

        public override float WeightMultiplier => 9.567f;

        public override float HeightMultiplier => 1.85f;

        public override float AgeMultiplier => 4.68f;

        public FemaleCalculationData(IActivity activity) : base(activity)
        {
        }
    }
}
