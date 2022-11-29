using System;

namespace CaloriesCalculator.Structure.Calculations
{
    public abstract class BaseCalculationData
    {
        internal protected float _cpm = default;
        internal protected IActivity _activity;
        public abstract float Base { get; }
        public abstract float WeightMultiplier { get; }
        public abstract float HeightMultiplier { get; }
        public abstract float AgeMultiplier { get; }
        public bool IsCalculated => _cpm != default;
        public BaseCalculationData(IActivity activity)
        {
            _activity = activity ?? throw new ArgumentNullException(nameof(activity));
        }

        /// <summary>
        /// Method to calculate basic metabolism using the Harris Benedicta pattern
        /// </summary>
        //TODO: rename func name
        public virtual float CalculateBasicMetabolism(float weight, float height, uint age)
        {
            _cpm = Base + WeightMultiplier * weight + HeightMultiplier * height - AgeMultiplier * age;
            return (float)Math.Round(_cpm, 2);
        }
        /// <summary>
        /// Method to calculate total metabolism
        /// </summary>
        //TODO: rename func name
        public virtual bool TryCalculateTotalMetabolism(Protos.ActivityLevel activityLevel, Protos.SexOrientation sex, out float cpm)
        {
            if (IsCalculated)
            {
                cpm = (float)Math.Round(_cpm * _activity.GetActivityFor(activityLevel, sex), 2);
                return true;
            }

            cpm = 0f;
            return false;
        }
    }
}
