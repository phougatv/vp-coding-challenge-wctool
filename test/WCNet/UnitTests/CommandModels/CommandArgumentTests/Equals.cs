<<<<<<< HEAD
﻿//namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandArgumentTests;

//public class Equals
//{
//    #region IEquatable<CommandArgument>.Equals
//    [Fact]
//    public void ReturnsFalse_WhenInstancesAreNotEqual()
//    {
//        //Arrange
//        var other = CommandArgument.Create(["c"], "filepath");
//        var current = CommandArgument.Create(["c"], "fake-filepath");

//        //Assert
//        var actual = current.Equals(other);

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsTrue_WhenInstancesAreEqual()
//    {
//        //Arrange
//        var other = CommandArgument.Create(["c"], "filepath");
//        var current = CommandArgument.Create(["c"], "filepath");

//        //Assert
//        var actual = current.Equals(other);

//        //Assert
//        actual.Should().BeTrue();
//    }
//    #endregion IEquatable<CommandArgument>.Equals

//    #region IEquatable<CommandArgument>.Equals(Object? obj)
//    [Fact]
//    public void ReturnsFalse_WhenObjectIsNull()
//    {
//        //Arrange
//        var obj = (Object?)null;
//        var current = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = current.Equals(obj);

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsFalse_WhenObjectIsNotOfTypeCommandArgument()
//    {
//        //Arrange
//        var obj = (Object?)new CommandKey("-c");
//        var current = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = current.Equals(obj);

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsFalse_WhenObjectIsOfTypeCommandArgumentButOneOfThePropertiesDoesNotMatch()
//    {
//        //Arrange
//        var obj = (Object?)CommandArgument.Create(["c"], "fake-filepath");
//        var current = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = current.Equals(obj);

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsTrue_WhenObjectIsOfTypeCommandArgumentAndAllThePropertiesMatch()
//    {
//        //Arrange
//        var obj = (Object?)CommandArgument.Create(["c"], "filepath");
//        var current = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = current.Equals(obj);

//        //Assert
//        actual.Should().BeTrue();
//    }

//    #endregion IEquatable<CommandArgument>.Equals(Object? obj)

//    #region == Operator
//    [Fact]
//    public void ReturnsFalse_WhenOperandLeftIsNull()
//    {
//        //Arrange
//        var left = (CommandArgument)null!;
//        var right = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsFalse_WhenOperandRightIsNull()
//    {
//        //Arrange
//        var left = CommandArgument.Create(["c"], "filepath");
//        var right = (CommandArgument)null!;

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsFalse_WhenCommandKeyMatchesButFilepathDoesNot()
//    {
//        //Arrange
//        var left = CommandArgument.Create(["c"], "filepath");
//        var right = CommandArgument.Create(["c"], "fake-filepath");

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsFalse_WhenFilepathMatchesButCommandKeyDoesNot()
//    {
//        //Arrange
//        var left = CommandArgument.Create(["c"], "filepath");
//        var right = CommandArgument.Create(["w"], "filepath");

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeFalse();
//    }

//    [Fact]
//    public void ReturnsTrue_WhenOperandsAreNull()
//    {
//        //Arrange
//        var left = (CommandArgument)null!;
//        var right = (CommandArgument)null!;

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeTrue();
//    }

//    [Fact]
//    public void ReturnsTrue_WhenOperandsBothCommandKeyAndFilepathAreEqual()
//    {
//        //Arrange
//        var left = CommandArgument.Create(["c"], "filepath");
//        var right = CommandArgument.Create(["c"], "filepath");

//        //Act
//        var actual = left == right;

//        //Assert
//        actual.Should().BeTrue();
//    }
//    #endregion == Operator
//}
=======
﻿namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandModels.CommandArgumentTests;

public class Equals
{
    #region IEquatable<CommandArgument>.Equals
    [Fact]
    public void ReturnsFalse_WhenInstancesAreNotEqual()
    {
        //Arrange
        var other = CommandArgument.Create(["c"], "filepath");
        var current = CommandArgument.Create(["c"], "fake-filepath");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenInstancesAreEqual()
    {
        //Arrange
        var other = CommandArgument.Create(["c"], "filepath");
        var current = CommandArgument.Create(["c"], "filepath");

        //Assert
        var actual = current.Equals(other);

        //Assert
        actual.Should().BeTrue();
    }
    #endregion IEquatable<CommandArgument>.Equals

    #region IEquatable<CommandArgument>.Equals(Object? obj)
    [Fact]
    public void ReturnsFalse_WhenObjectIsNull()
    {
        //Arrange
        var obj = (Object?)null;
        var current = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsNotOfTypeCommandArgument()
    {
        //Arrange
        var obj = (Object?)new CommandKey("-c");
        var current = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenObjectIsOfTypeCommandArgumentButOneOfThePropertiesDoesNotMatch()
    {
        //Arrange
        var obj = (Object?)CommandArgument.Create(["c"], "fake-filepath");
        var current = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenObjectIsOfTypeCommandArgumentAndAllThePropertiesMatch()
    {
        //Arrange
        var obj = (Object?)CommandArgument.Create(["c"], "filepath");
        var current = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = current.Equals(obj);

        //Assert
        actual.Should().BeTrue();
    }

    #endregion IEquatable<CommandArgument>.Equals(Object? obj)

    #region == Operator
    [Fact]
    public void ReturnsFalse_WhenOperandLeftIsNull()
    {
        //Arrange
        var left = (CommandArgument)null!;
        var right = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenOperandRightIsNull()
    {
        //Arrange
        var left = CommandArgument.Create(["c"], "filepath");
        var right = (CommandArgument)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenCommandKeyMatchesButFilepathDoesNot()
    {
        //Arrange
        var left = CommandArgument.Create(["c"], "filepath");
        var right = CommandArgument.Create(["c"], "fake-filepath");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsFalse_WhenFilepathMatchesButCommandKeyDoesNot()
    {
        //Arrange
        var left = CommandArgument.Create(["c"], "filepath");
        var right = CommandArgument.Create(["w"], "filepath");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsAreNull()
    {
        //Arrange
        var left = (CommandArgument)null!;
        var right = (CommandArgument)null!;

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void ReturnsTrue_WhenOperandsBothCommandKeyAndFilepathAreEqual()
    {
        //Arrange
        var left = CommandArgument.Create(["c"], "filepath");
        var right = CommandArgument.Create(["c"], "filepath");

        //Act
        var actual = left == right;

        //Assert
        actual.Should().BeTrue();
    }
    #endregion == Operator
}
>>>>>>> master
