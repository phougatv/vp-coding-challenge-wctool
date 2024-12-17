namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CountTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = new Count(1);
        var right = new Count(1);

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = new Count(1);
        var right = new Count(2);

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
