namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.CommandNotSetErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var error = CommandNotSetError.Create();

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be("Command is not set. First set command and try again.");
    }
}
