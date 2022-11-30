using System;
using CaloriesCalculator.Protos;
using CaloriesCalculator.Structure.Calculations;

namespace CaloriesCalculator.Structure.Operations
{
    public sealed class Calculate : ICalculate
    {
        private readonly BaseCalculationData calculationData;

        private float _basic;
        private float _total;
        public int BasicMetabolism => (int)Math.Round(_basic);

        public int TotalMetabolism => (int)Math.Round(_total);

        public Calculate(BaseCalculationData calculationData)
        {
            this.calculationData = calculationData;
        }

        public ICalculate CalculateBasicMetabolism(CalculateBasicRequest request)
        {
            _basic = this.calculationData.CalculateBasicMetabolism(weight: request.Weight, height: request.Height, age: request.Age);
            return this;
        }

        public ICalculate CalculateTotalMetabolism(Protos.ActivityLevel activityLevel, SexOrientation sex)
        {
            if(!this.calculationData.IsCalculated)
            {
                _total = default;
            }
            this.calculationData.TryCalculateTotalMetabolism(activityLevel, sex, out _total);
            return this;
        }
    }
}
