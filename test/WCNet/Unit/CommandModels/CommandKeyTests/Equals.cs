namespace VP.CodingChallenge.WCNet.Test.Unit.CommandModels.CommandKeyTests;

public class Equals
{
    #region IEquatable<CommandKey>.Equals
    [Fact]
    public void ReturnsFalse_WhenInstancesAreNotEqual()
    {
        //Arrange
        var other = new CommandKey("-c");
        var current = new CommandKey("-w");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreEqual()
    {
        //Arrange
        var other = new CommandKey("-c");
        var current = new CommandKey("-c");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<CommandKey>.Equals

    #region IEquatable<CommandKey>.Equals(Object? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = new CommandKey("-c");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullButIsNotOfTypeCommandKey()
    {
        //Arrange
        var obj = (Object?)CommandArgument.Create("-c", "fake-filepath");
        var current = new CommandKey("-c");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullAndIsOfTypeCommandKeyButNotEqualToTheCurrentInstance()
    {
        //Arrange
        var obj = (Object?)new CommandKey("-w");
        var current = new CommandKey("-c");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsNotNullAndIsOfTypeCommandKeyAndIsEqualToTheCurrentInstance()
    {
        //Arrange
        var obj = (Object?)new CommandKey("-c");
        var current = new CommandKey("-c");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }

    #endregion IEquatable<CommandKey>.Equals(Object? obj)

    #region == Operator
    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
        //Arrange
        var left = (CommandKey)null!;
        var right = new CommandKey("-c");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var left = new CommandKey("-c");
        var right = (CommandKey)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandsAreNotNullAndNotEqual()
    {
        //Arrange
        var left = new CommandKey("-c");
        var right = new CommandKey("-w");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNull()
    {
        //Arrange
        var left = (CommandKey)null!;
        var right = (CommandKey)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNotNullAndEqual()
    {
        //Arrange
        var left = new CommandKey("-c");
        var right = new CommandKey("-c");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }
    #endregion == Operator
}
