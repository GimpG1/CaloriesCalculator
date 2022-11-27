using CaloriesCalculator.Protos;
using CaloriesCalculator.Structure.Calculations;

namespace CaloriesCalculator.Structure.Operations
{
    public sealed class Calculate : ICalculate
    {
        private readonly BaseCalculationData calculationData;

        public Calculate(BaseCalculationData calculationData)
        {
            this.calculationData = calculationData;
        }

        public float CalculatePpm(CalculateBasicRequest request)
        {
            return this.calculationData.CalculatePPM(weight: request.Weight, height: request.Width, age: request.Age);
        }

        public bool CalculateCpm(Protos.ActivityLevel activityLevel, Protos.SexOrientation sex, out float cpm)
        {
            if(!this.calculationData.IsCalculated)
            {
                cpm = default;
                return false;
            }
            return this.calculationData.TryCalculateCPM(activityLevel, sex, out cpm);
        }
    }
}
