namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CountTests;

public class Equals
{
    #region IEquatable<Count>.Equals
    [Fact]
    public void ReturnsFalse_WhenInstanceAreNotEqual()
    {
        //Arrange
        var other = new Count(5);
        var current = new Count(6);

        //Act
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreEqual()
    {
        //Arrange
        var other = new Count(5);
        var current = new Count(5);

        //Act
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<Count>.Equals

    #region Equals(Objects? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = new Count(5);

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullButIsNotOfTypeCount()
    {
        //Arrange
        var commandKey = new CommandKey("x");
        var obj = (Object?)commandKey;
        var current = new Count(5);

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullAndIsOfTypeCountButInstancesAreNotEqual()
    {
        //Arrange
        var other = new Count(6);
        var obj = (Object?)other;
        var current = new Count(5);

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsNotNullAndIsOfTypeCountAndInstancesAreEqual()
    {
        //Arrange
        var other = new Count(5);
        var obj = (Object?)other;
        var current = new Count(5);

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion Equals(Objects? obj)

    #region == Operator
    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
        //Arrange
        var left = (Count?)null;
        var right = new Count(5);

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var left = new Count(5);
        var right = (Count?)null;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandsAreNotNullAndNotEqual()
    {
        //Arrange
        var left = new Count(5);
        var right = new Count(6);

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenBothOperandsAreNull()
    {
        //Arrange
        var left = (Count?)null;
        var right = (Count?)null;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenBothOperandsAreEqual()
    {
        //Arrange
        var left = new Count(5);
        var right = new Count(5);

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }
    #endregion == Operator
}
