namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.FilepathTests;

public class GetFilename
{
    [Fact]
    public void ReturnsFilename_WhenFilenameExistsInPath()
    {
        // Arrange
        var filepath = new Filepath("C:/test.txt");
        var expected = "test.txt";

        // Act
        var result = filepath.GetFilename();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ReturnsEmpty_WhenFilenameDoesNotExistInPath()
    {
        // Arrange
        var filepath = new Filepath("C:/");

        // Act
        var result = filepath.GetFilename();

        // Assert
        result.Should().Be(Filepath.Empty);
    }
}
