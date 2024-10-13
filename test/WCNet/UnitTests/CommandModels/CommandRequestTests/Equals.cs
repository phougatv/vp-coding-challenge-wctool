namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandRequestTests;

public class Equals
{
    #region IEquatable<CommandRequest>.Equals(CommandRequest? other)
    [Fact]
    public void ReturnsFalse_WhenOtherIsNull()
    {
        //Arrange
        var other = (CommandRequest?)null;
        var current = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOtherIsNotNullButNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(CommandKey.None, new Filepath("actual/file/path"));

        //Act
        var actual = left.Equals(right);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenOtherIsNotNullAndEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var actual = left.Equals(right);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<CommandRequest>.Equals(CommandRequest? other)

    #region Equals(Object? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullButIsNotOfTypeCommandRequest()
    {
        //Arrange
        var commandKey = new CommandKey("x");
        var obj = (Object?)commandKey;
        var current = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullAndIsOfTypeCommandRequestButNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(CommandKey.None, new Filepath("actual/file/path"));
        var obj = (Object?)right;

        //Act
        var actual = left.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsNotNullAndIsOfTypeCommandRequestAndEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var obj = (Object?)right;

        //Act
        var actual = left.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion Equals(Object? obj)

    #region == Operator
    [Fact]
    public void ReturnsTrue_WhenBothInstancesAreNull()
    {
        //Arrange
        CommandRequest? left = null;
        CommandRequest? right = null;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenReferencesOfBothInstancesAreEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = left;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
        //Arrange
        CommandRequest? left = null;
        var right = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        CommandRequest? right = null;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandsAreNotNullAndNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("actual/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOnlyFilepathIsNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(CommandKey.None, new Filepath("actual/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOnlyCommandKeyIsNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.Create(new CommandKey("c"), new Filepath("fake/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOnlyIsDefaultIsNotEqual()
    {
        //Arrange
        var left = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("fake/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOnlyDefaultCommandKeysAreNotEqual()
    {
        //Arrange
        var left = CommandRequest.CreateDefault([CommandKey.None], new Filepath("fake/file/path"));
        var right = CommandRequest.CreateDefault([new CommandKey("c")], new Filepath("fake/file/path"));

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNotNullAndEqual()
    {
        //Arrange
        var left1 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var right1 = CommandRequest.Create(CommandKey.None, new Filepath("fake/file/path"));
        var left2 = CommandRequest.CreateDefault([CommandKey.None], new Filepath("fake/file/path"));
        var right2 = CommandRequest.CreateDefault([CommandKey.None], new Filepath("fake/file/path"));

        //Act
        var actual1 = left1 == right1;
        var actual2 = left2 == right2;

        //Assert
        actual1.Should().BeTrue();
        actual2.Should().BeTrue();
    }
    #endregion == Operator
}
