namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.MessageTests;

public class ImplicitOperations
{
    [Fact]
    public void ReturnsMessage_WhenConvertingStringToMessage()
    {
        // Arrange
        var message = new Message("Hello, World!");

        // Act
        String actual = message;

        // Assert
        actual.Should().Be("Hello, World!");
    }

    [Fact]
    public void ReturnsString_WhenConvertingMessageToString()
    {
        // Arrange
        var stringMessage = "Hello, World!";
        var expected = new Message("Hello, World!");

        // Act
        Message actual = stringMessage;

        // Assert
        actual.Should().Be(expected);
    }
}
