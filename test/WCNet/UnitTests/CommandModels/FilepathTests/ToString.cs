namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.FilepathTests;

public class ToString
{
    [Fact]
    public void ReturnsValueOfFilepathAsString()
    {
        //Arrange
        var filepath = new Filepath("C:\\temp\\file.txt");
        var expected = "C:\\temp\\file.txt";

        //Act
        var actual = filepath.ToString();

        //Assert
        actual.Should().Be(expected);
    }
}