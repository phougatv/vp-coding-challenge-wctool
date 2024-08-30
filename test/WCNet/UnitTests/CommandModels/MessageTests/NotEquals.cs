namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.MessageTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = new Message("message");
        var right = new Message("message");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = new Message("message");
        var right = new Message("test message");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
