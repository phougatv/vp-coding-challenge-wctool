namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandKeyTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
<<<<<<< HEAD
        var left = new Command("-c");
        var right = new Command("-c");
=======
        var left = new CommandKey("-c");
        var right = new CommandKey("-c");
>>>>>>> master

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
<<<<<<< HEAD
        var left = new Command("-c");
        var right = new Command("-w");
=======
        var left = new CommandKey("-c");
        var right = new CommandKey("-w");
>>>>>>> master

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
