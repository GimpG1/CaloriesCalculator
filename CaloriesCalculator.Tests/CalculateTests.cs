using CaloriesCalculator.Protos;
using CaloriesCalculator.Structure;
using Moq;

namespace CaloriesCalculator.Tests
{
    public class CalculateTests
    {
        [Theory]
        [InlineData(SexOrientation.Male, 1_809.67f ,80f, 170f, 30f)]
        [InlineData(SexOrientation.Female, 1_383.46f ,55f, 170f, 24f)]
        public void Check_IfCanCalculate_PPM(SexOrientation orientation, float ppm, float weight, float height, uint age)
        {        
            var helper = new HelperCalculationsTests();
            var _mActivity = new Mock<IActivity>();

            var calculationData = helper.CreateBaseCalculationFor(orientation, _mActivity.Object);  

            Assert.NotNull(calculationData);
            Assert.Equal(ppm, calculationData.CalculateBasicMetabolism(weight, height, age));
        }

        [Theory]
        [InlineData(SexOrientation.Male, Protos.ActivityLevel.Verylow, 2_171.60f, 1_809.67f ,80f, 170f, 30f)]
        [InlineData(SexOrientation.Female, Protos.ActivityLevel.Verylow, 1_660.16f, 1_383.46f ,55f, 170f, 24f)]
        public void Check_IfCanCalculate_CPM(SexOrientation orientation, Protos.ActivityLevel activity, float cpm, float ppm, float weight, float height, uint age)
        {          
            var helper = new HelperCalculationsTests();
            var _mActivity = new Mock<IActivity>();
            _mActivity.Setup(item=>item.GetActivityFor(It.IsAny<Protos.ActivityLevel>(), It.IsAny<SexOrientation>()))
                      .Returns(helper.GetActivityValueFor(orientation, activity));

            var calculationData = helper.CreateBaseCalculationFor(orientation, _mActivity.Object);  

            Assert.NotNull(calculationData);
            Assert.Equal(ppm, calculationData.CalculateBasicMetabolism(weight, height, age));

            Assert.True(calculationData.TryCalculateTotalMetabolism(activity, orientation, out float cpmResult));
            Assert.Equal(cpm, cpmResult);
        }
    }
}