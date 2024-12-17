namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.FileNotFoundErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var filename = "file.txt";
        var error = FileNotFoundError.Create(filename);

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be($"File: {filename}, not found.");
    }
}
