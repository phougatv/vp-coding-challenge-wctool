namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.CommandFormatErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var error = CommandFormatError.Create();

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be("Incorrect command format, try -<command> <filepath_along_with_filename.extension>.");
    }
}
