namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandRequestTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, "filepath");
        var right = CommandRequest.Create(CommandKey.None, "filepath");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, "filepath");
        var right = CommandRequest.Create(CommandKey.None, "different filepath");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
