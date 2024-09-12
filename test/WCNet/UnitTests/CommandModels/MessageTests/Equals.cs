namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.MessageTests;

public class Equals
{
    #region IEquatable<Message>.Equals
    [Fact]
    public void ReturnsFalse_WhenInstancesAreNotEqual()
    {
        //Arrange
        var other = new Message("test message");
        var current = new Message("message");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreEqual()
    {
        //Arrange
        var other = new Message("message");
        var current = new Message("message");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<Message>.Equals

    #region IEquatable<Message>.Equals(Object? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = new Message("message");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullButIsNotOfTypeMessage()
    {
        //Arrange
        var obj = (Object?)CommandArgument.Create(["c"], "fake-filepath");
        var current = new Message("message");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullAndIsOfTypeMessageButNotEqualToTheCurrentInstance()
    {
        //Arrange
        var obj = (Object?)new Message("test message");
        var current = new Message("message");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsNotNullAndIsOfTypeMessageAndIsEqualToTheCurrentInstance()
    {
        //Arrange
        var obj = (Object?)new Message("message");
        var current = new Message("message");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }

    #endregion IEquatable<Message>.Equals(Object? obj)

    #region == Operator
    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
        //Arrange
        var left = (Message)null!;
        var right = new Message("message");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var left = new Message("message");
        var right = (Message)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandsAreNotEqual()
    {
        //Arrange
        var left = new Message("message");
        var right = new Message("test message");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNull()
    {
        //Arrange
        var left = (Message)null!;
        var right = (Message)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNotNullAndEqual()
    {
        //Arrange
        var left = new Message("message");
        var right = new Message("message");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }
    #endregion == Operator
}
