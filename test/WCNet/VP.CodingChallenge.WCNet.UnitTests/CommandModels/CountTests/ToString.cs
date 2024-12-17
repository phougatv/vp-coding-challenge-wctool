namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CountTests;

public class ToString
{
    [Fact]
    public void ReturnsValueOfCountAsString()
    {
        //Arrange
        var count = new Count(5);
        var expected = "5";

        //Act
        var actual = count.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}