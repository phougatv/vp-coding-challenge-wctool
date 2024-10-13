namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.FilepathTests;

public class NotEquals
{
    [Fact]
    public void ReturnsFalse_WhenInstancesAreEqual()
    {
        //Arrange
        var left = new Filepath("C:\\temp\\file.txt");
        var right = new Filepath("C:\\temp\\file.txt");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreNotEqual()
    {
        //Arrange
        var left = new Filepath("C:\\temp\\file.txt");
        var right = new Filepath("C:\\temp\\file2.txt");

        //Act
        var actual = left != right;

        //Assert
        actual.Should().BeTrue();
    }
}
