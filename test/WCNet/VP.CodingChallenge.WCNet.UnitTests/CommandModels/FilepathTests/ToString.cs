namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.FilepathTests;

public class ToString
{
    [Fact]
    public void ReturnsValueOfFilepathAsString()
    {
        //Arrange
        var filepath = new FilePath("C:\\temp\\file.txt");
        var expected = "C:\\temp\\file.txt";

        //Act
        var actual = filepath.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}