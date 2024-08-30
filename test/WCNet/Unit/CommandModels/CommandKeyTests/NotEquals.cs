namespace VP.CodingChallenge.WCNet.Test.Unit.CommandModels.CommandKeyTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = new CommandKey("-c");
        var right = new CommandKey("-c");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = new CommandKey("-c");
        var right = new CommandKey("-w");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
