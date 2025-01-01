namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.FilepathTests;

public class ImplicitOperations
{
    [Fact]
    public void ReturnsFilepath_WhenConvertingStringToFilepath()
    {
        // Arrange
        var str = "C:\\temp\\file.txt";
        var expectedFilepath = new FilePath("C:\\temp\\file.txt");

        // Act
        FilePath actualFilepath = str;

        // Assert
        actualFilepath.Should().Be(expectedFilepath);
    }

    [Fact]
    public void ReturnsString_WhenConvertingFilepathToString()
    {
        // Arrange
        var filepath = new FilePath("C:\\temp\\file.txt");

        // Act
        String actual = filepath;

        // Assert
        actual.Should().Be("C:\\temp\\file.txt");
    }
}
