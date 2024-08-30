namespace VP.CodingChallenge.WCNet.Test.Unit.CommandModels.CommandKeyTests;

public class ToString
{
    [Fact]
    public void ReturnsStringContainingCommandKeyAndFilepath()
    {
        //Arrange
        var commandKey = new CommandKey("-c");
        var expected = "-c";

        //Act
        var actual = commandKey.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}
