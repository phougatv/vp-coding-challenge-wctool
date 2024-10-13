namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.FilepathTests;

public class Equals
{
    #region IEquatable<Count>.Equals
    [Fact]
    public void ReturnsFalse_WhenInstanceAreNotEqual()
    {
        //Arrange
        var other = new Filepath("x");
        var current = new Filepath("y");

        //Act
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreEqual()
    {
        //Arrange
        var other = new Filepath("x");
        var current = new Filepath("x");

        //Act
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<Count>.Equals

    #region IEquatable<Count>.Equals(Objects? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = new Filepath("x");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullButIsNotOfTypeFilepath()
    {
        //Arrange
        var commandKey = new CommandKey("x");
        var obj = (Object?)commandKey;
        var current = new Filepath("fake/file/path");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotNullAndIsOfTypeFilepathButValuesAreNotEqual()
    {
        //Arrange
        var other = new Filepath("fake/file/path");
        var obj = (Object?)other;
        var current = new Filepath("actual/file/path");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsNotNullAndIsOfTypeFilepathAndValuesAreEqual()
    {
        //Arrange
        var other = new Filepath("fake/file/path");
        var obj = (Object?)other;
        var current = new Filepath("fake/file/path");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<Count>.Equals(Objects? obj)

    #region == Operator
    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
       //Arrange
        var other = new Filepath("fake/file/path");
        var current = (Filepath?)null;

        //Act
        var actual = current == other;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var other = (Filepath?)null;
        var current = new Filepath("fake/file/path");

        //Act
        var actual = current == other;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenInstancesAreNotNullAndNotEqual()
    {
        //Arrange
        var other = new Filepath("fake/file/path");
        var current = new Filepath("actual/file/path");

        //Act
        var actual = current == other;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenBothOperandsAreNull()
    {
        //Arrange
        var other = (Filepath?)null;
        var current = (Filepath?)null;

        //Act
        var actual = current == other;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenBothOperandsAreEqual()
    {
        //Arrange
        var other = new Filepath("fake/file/path");
        var current = new Filepath("fake/file/path");

        //Act
        var actual = current == other;

        //Assert
        actual.Should().BeTrue();
    }
    #endregion == Operator
}