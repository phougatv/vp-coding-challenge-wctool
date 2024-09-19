namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandKeyTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = new Command("-c");
        var right = new Command("-c");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = new Command("-c");
        var right = new Command("-w");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
