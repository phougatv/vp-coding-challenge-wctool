namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandErrors.CommandNotFoundErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var commandKey = new CommandKey("c");
        var error = CommandNotFoundError.Create(commandKey);

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be("Command 'c' not found.");
    }
}
