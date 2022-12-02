namespace CaloriesCalculator.Tests;

public class ActivityLevelTests
{
    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_NoneActivitySet_Then_ExpectSameResult(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        Assert.Equal(ActivityValues.None, al.GetActivityFor(Protos.ActivityLevel.None, orientation));
    }

    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_VeryLowActivitySet_Then_ExpectSameResult(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        Assert.Equal(ActivityValues.VeryLow, al.GetActivityFor(Protos.ActivityLevel.Verylow, orientation));
    }

    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_LowActivitySet_Then_CheckTheResults(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        if (orientation == Protos.SexOrientation.Female)
        {
            Assert.Equal(ActivityValues.Female.Low, al.GetActivityFor(Protos.ActivityLevel.Low, orientation));
        }
        else
        {
            Assert.Equal(ActivityValues.Male.Low, al.GetActivityFor(Protos.ActivityLevel.Low, orientation));
        }
    }

    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_AverageActivitySet_Then_CheckTheResults(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        if (orientation == Protos.SexOrientation.Female)
        {
            Assert.Equal(ActivityValues.Female.Average, al.GetActivityFor(Protos.ActivityLevel.Average, orientation));
        }
        else
        {
            Assert.Equal(ActivityValues.Male.Average, al.GetActivityFor(Protos.ActivityLevel.Average, orientation));
        }
    }

    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_HighActivitySet_Then_CheckTheResults(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        if (orientation == Protos.SexOrientation.Female)
        {
            Assert.Equal(ActivityValues.Female.High, al.GetActivityFor(Protos.ActivityLevel.High, orientation));
        }
        else
        {
            Assert.Equal(ActivityValues.Male.High, al.GetActivityFor(Protos.ActivityLevel.High, orientation));
        }
    }

    [Theory]
    [InlineData(Protos.SexOrientation.Female)]
    [InlineData(Protos.SexOrientation.Male)]
    public void When_VeryHighActivitySet_Then_CheckTheResults(Protos.SexOrientation orientation)
    {
        ActivityLevel al = new();
        if (orientation == Protos.SexOrientation.Female)
        {
            Assert.Equal(ActivityValues.Female.Veryhigh, al.GetActivityFor(Protos.ActivityLevel.Veryhigh, orientation));
        }
        else
        {
            Assert.Equal(ActivityValues.Male.Veryhigh, al.GetActivityFor(Protos.ActivityLevel.Veryhigh, orientation));
        }
    }
}