using CaloriesCalculator.Protos;

namespace CaloriesCalculator.Structure.Operations
{
    public interface ICalculate
    {
        float CalculatePpm(CalculateBasicRequest request);
        bool CalculateCpm(Protos.ActivityLevel activityLevel, Protos.SexOrientation sex, out float cpm);
    }
}