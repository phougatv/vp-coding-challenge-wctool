namespace VP.CodingChallenge.WCNet.Test.Unit.CommandModels.CommandArgumentTests;

public class ToString
{
    [Fact]
    public void ReturnsStringContainingCommandKeyAndFilepath()
    {
        //Arrange
        var commandKey = new CommandKey("-c");
        var filename = "filename.txt";
        var filepath = Path.Combine($".\\filepath\\{filename}");
        var commandArgs = CommandArgument.Create(commandKey, filepath);
        var expected = $"Command: {commandKey}, Filename: \"{filename}\"";

        //Act
        var actual = commandArgs.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}
