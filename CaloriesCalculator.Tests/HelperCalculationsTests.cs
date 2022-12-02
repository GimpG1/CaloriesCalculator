using CaloriesCalculator.Protos;
using CaloriesCalculator.Structure.Calculations;

namespace CaloriesCalculator.Tests;
class HelperCalculationsTests
{
   internal float GetActivityValueFor(SexOrientation orientation, Protos.ActivityLevel activity)
   {
       return activity switch
       {
           Protos.ActivityLevel.None => ActivityValues.None,
           Protos.ActivityLevel.Verylow => ActivityValues.VeryLow,
           Protos.ActivityLevel.Low => orientation == SexOrientation.Male ? ActivityValues.Male.Low : ActivityValues.Female.Low,
           Protos.ActivityLevel.Average => orientation == SexOrientation.Male ? ActivityValues.Male.Average : ActivityValues.Female.Average,
           Protos.ActivityLevel.High => orientation == SexOrientation.Male ? ActivityValues.Male.High : ActivityValues.Female.High,
           Protos.ActivityLevel.Veryhigh => orientation == SexOrientation.Male ? ActivityValues.Male.Veryhigh : ActivityValues.Female.Veryhigh,
           _ => 0.0f,
       };
   }
   
   internal BaseCalculationData CreateBaseCalculationFor(SexOrientation orientation, IActivity activity)
   {
       return orientation switch
       {
           SexOrientation.Female => new FemaleCalculationData(activity),
           SexOrientation.Male => new MaleCalculationData(activity),
           _ => new EmptyCalculations(activity),
       };
   }
}