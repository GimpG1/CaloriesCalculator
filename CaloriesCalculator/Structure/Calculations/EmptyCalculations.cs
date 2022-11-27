namespace CaloriesCalculator.Structure.Calculations
{
    public sealed class EmptyCalculations : BaseCalculationData
    {
        public override float Base => default;

        public override float WeightMultiplier => default;

        public override float HeightMultiplier => default;

        public override float AgeMultiplier => default;

        public EmptyCalculations(IActivity activity): base(activity)
        {
        }
    }
}