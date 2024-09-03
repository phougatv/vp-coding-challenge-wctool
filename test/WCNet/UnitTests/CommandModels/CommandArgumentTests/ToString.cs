namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandArgumentTests;

public class ToString
{
    [Fact]
    public void ReturnsStringContainingCommandKeyAndFilepath()
    {
        //Arrange
        var commandKeys = new CommandKey[] { "-c" };
        var filename = "filename.txt";
        var filepath = Path.Combine($".\\filepath\\{filename}");
        var commandArgs = CommandArgument.Create(commandKeys, filepath);
        var expected = $"Command: {commandKeys}, Filename: \"{filename}\"";

        //Act
        var actual = commandArgs.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}
