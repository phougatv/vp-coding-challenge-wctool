namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CommandKeyTests;

public class ImplicitOperations
{
    [Fact]
    public void ReturnsCommandKey_WhenConvertingStringToCommandKey()
    {
        // Arrange
        var commandKey = new CommandKey("c");

        // Act
        String actual = commandKey;

        // Assert
        actual.Should().Be("c");
    }

    [Fact]
    public void ReturnsString_WhenConvertingCommandKeyToString()
    {
        // Arrange
        var stringCommandKey = "c";
        var expected = new CommandKey("c");

        // Act
        CommandKey actual = stringCommandKey;

        // Assert
        actual.Should().Be(expected);
    }
}
