namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandKeyTests;

public class ToString
{
    [Fact]
    public void ReturnsStringContainingCommandKeyAndFilepath()
    {
        //Arrange
<<<<<<< HEAD
        var commandKey = new Command("-c");
=======
        var commandKey = new CommandKey("-c");
>>>>>>> master
        var expected = "-c";

        //Act
        var actual = commandKey.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}
