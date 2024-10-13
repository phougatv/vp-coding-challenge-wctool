namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandRequestTests;

public class ToString
{
    [Fact]
    public void ReturnsCommandKeyAndFilename_WhenNotDefault()
    {
        // Arrange
        var commandKey = new CommandKey("c");
        var filepath = new Filepath("C:/test.txt");
        var filename = Path.GetFileName(filepath);
        var commandRequest = CommandRequest.Create(commandKey, filepath);

        // Act
        var result = commandRequest.ToString();

        // Assert
        result.Should().Be($"Command key: {commandKey}, Filename: \"{filename}\"");
    }

    [Fact]
    public void ReturnsDefaultCommandKeysAndFilename_WhenDefault()
    {
        // Arrange
        var defaultCommandKeys = new[] { new CommandKey("c1"), new CommandKey("c2") };
        var filepath = new Filepath("C:/test.txt");
        var filename = Path.GetFileName(filepath);
        var commandRequest = CommandRequest.CreateDefault(defaultCommandKeys, filepath);

        // Act
        var result = commandRequest.ToString();

        // Assert
        result.Should().Be($"Default command keys: {String.Join(", ", defaultCommandKeys)}, Filename: \"{filename}\"");
    }
}
