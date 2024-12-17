namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.FilepathTests;

public class ImplicitOperations
{
    [Fact]
    public void ReturnsFilepath_WhenConvertingStringToFilepath()
    {
        // Arrange
        var str = "C:\\temp\\file.txt";
        var expectedFilepath = new Filepath("C:\\temp\\file.txt");

        // Act
        Filepath actualFilepath = str;

        // Assert
        actualFilepath.Should().Be(expectedFilepath);
    }

    [Fact]
    public void ReturnsString_WhenConvertingFilepathToString()
    {
        // Arrange
        var filepath = new Filepath("C:\\temp\\file.txt");

        // Act
        String actual = filepath;

        // Assert
        actual.Should().Be("C:\\temp\\file.txt");
    }
}
