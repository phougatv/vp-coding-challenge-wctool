namespace VP.CodingChallenge.WCNet.Test.Unit.CommandModels.CommandArgumentTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = CommandArgument.Create("-c", "filepath");
        var right = CommandArgument.Create("-c", "filepath");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = CommandArgument.Create("-c", "filepath");
        var right = CommandArgument.Create("-c", "fake-filepath");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
