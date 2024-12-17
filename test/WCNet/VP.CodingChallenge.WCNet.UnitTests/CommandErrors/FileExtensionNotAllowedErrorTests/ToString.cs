namespace VP.CodingChallenge.WCNet.UnitTests.CommandErrors.FileExtensionNotAllowedErrorTests;

public class ToString
{
    [Fact]
    public void ReturnsErrorMessage()
    {
        //Arrange
        var extension = "ppt";
        var error = FileExtensionNotAllowedError.Create(extension);

        //Act
        var result = error.ToString();

        //Assert
        result.Should().Be($"File extension: \".{extension}\" not allowed.");
    }
}
