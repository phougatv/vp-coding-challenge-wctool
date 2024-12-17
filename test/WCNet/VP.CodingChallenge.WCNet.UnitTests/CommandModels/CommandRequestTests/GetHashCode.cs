namespace VP.CodingChallenge.WCNet.UnitTests.CommandModels.CommandRequestTests;

public class GetHashCode
{
    [Fact]
    public void ReturnsSameHashCode_WhenObjectsAreEqual()
    {
        //Arrange
        var left1 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right1 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var left2 = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("fake/file/path"));
        var right2 = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("fake/file/path"));

        //Act
        var leftHashCode1 = left1.GetHashCode();
        var rightHashCode1 = right1.GetHashCode();
        var leftHashCode2 = left2.GetHashCode();
        var rightHashCode2 = right2.GetHashCode();

        //Assert
        leftHashCode1.Should().Be(rightHashCode1);
        leftHashCode2.Should().Be(rightHashCode2);
    }

    [Fact]
    public void ReturnsDifferentHashCode_WhenObjectsAreNotEqual()
    {
        //Arrange
        var left1 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right1 = CommandRequest.Create(CommandKey.None, new Filepath("actual/file/path"));
        var left2 = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("fake/file/path"));
        var right2 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var leftHashCode1 = left1.GetHashCode();
        var rightHashCode1 = right1.GetHashCode();
        var leftHashCode2 = left2.GetHashCode();
        var rightHashCode2 = right2.GetHashCode();

        //Assert
        leftHashCode1.Should().NotBe(rightHashCode1);
        leftHashCode2.Should().NotBe(rightHashCode2);
    }
}
