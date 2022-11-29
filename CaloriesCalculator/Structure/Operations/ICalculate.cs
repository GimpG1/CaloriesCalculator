using CaloriesCalculator.Protos;

namespace CaloriesCalculator.Structure.Operations
{
    public interface ICalculate
    {
        public int BasicMetabolism { get; }
        public int TotalMetabolism { get; }
        ICalculate CalculateBasicMetabolism(CalculateBasicRequest request);
        ICalculate CalculateTotalMetabolism(Protos.ActivityLevel activityLevel, Protos.SexOrientation sex);
    }
}