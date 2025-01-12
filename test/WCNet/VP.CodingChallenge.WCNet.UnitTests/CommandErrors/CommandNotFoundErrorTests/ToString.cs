namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.CommandNotFoundErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var commandKey = new CommandKey("c");
        var error = CommandNotRegisteredError.Create(commandKey);

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be("Command 'c' not found.");
    }
}
