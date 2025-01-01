namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandRequestTests;

/// <summary>
/// This class tests the equality logic for the <see cref="CommandRequest"/> class.
/// It includes tests for the following methods and operators:
///		* <see cref="CommandRequest.Equals(CommandRequest)"/>
///		* <see cref="CommandRequest.Equals(Object?)"/>
///		* == operator
///		* != operator
/// </summary>
public class Equals
{
	#region Equals(CommandRequest)
	[Fact]
	public void ReturnsFalse_WhenCommandRequestIsDefault()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = default(CommandRequest);

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestIsNull()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = (CommandRequest?)null;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersBecauseCommandKeysOfCurrentObjectIsNull()
	{
		//Arrange
		var nullKeys = (IReadOnlyCollection<CommandKey>)null!;
		var current = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");
		var other = CommandRequest.Create("c", "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersBecauseCommandKeysOfCurrentObjectIsEmpty()
	{
		//Arrange
		var emptyKeys = (IReadOnlyCollection<CommandKey>)[];
		var current = CommandRequest.Create(emptyKeys, "fake/file/path/file.txt");
		var other = CommandRequest.Create("c", "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersBecauseCommandKeysOfOtherObjectIsNull()
	{
		//Arrange
		var nullKeys = (IReadOnlyCollection<CommandKey>)null!;
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersBecauseCommandKeysOfOtherObjectIsEmpty()
	{
		//Arrange
		var emptyKeys = (IReadOnlyCollection<CommandKey>)[];
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = CommandRequest.Create(emptyKeys, "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersInTheCountOfCommandKeys()
	{
		//Arrange
		var current = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");
		var other = CommandRequest.Create(["c", "w"], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersInTheOrderOfCommandKeys()
	{
		//Arrange
		var current = CommandRequest.Create(["c", "w"], "fake/file/path/file.txt");
		var other = CommandRequest.Create(["w", "c"], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersInTheValueOfCommandKeys()
	{
		//Arrange
		var current = CommandRequest.Create(["c", "w"], "fake/file/path/file.txt");
		var other = CommandRequest.Create(["c", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersInTheFilePath()
	{
		//Arrange
		var current = CommandRequest.Create("c", "real/file/path/file.txt");
		var other = CommandRequest.Create("c", "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandRequestDiffersInTheFilePathCasing()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = CommandRequest.Create("c", "fake/file/path/File.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenCommandRequestIsEqualAndBothCommandKeysAreNeitherNullNorEmpty()
	{
		//Arrange
		var current = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");
		var other = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCommandRequestIsEqualAndBothCommandKeysAreEmpty()
	{
		//Arrange
		var current = CommandRequest.Create([], "fake/file/path/file.txt");
		var other = CommandRequest.Create([], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCommandRequestIsEqualAndBothCommandKeysAreNull()
	{
		//Arrange
		var nullKeys = (IReadOnlyCollection<CommandKey>)null!;
		var current = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");
		var other = CommandRequest.Create(nullKeys, "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(CommandRequest)

	#region Equals(Object?)
	[Fact]
	public void ReturnsFalse_WhenObjectIsNotCommandRequest()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = new Object();

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsCommandRequestAndIsNull()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = (Object?)(CommandRequest?)null;

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsDefaultCommandRequest()
	{
		//Arrange
		var current = CommandRequest.Create("c", "fake/file/path/file.txt");
		var other = (Object?)default(CommandRequest);

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenObjectIsCommandRequestAndIsEqual()
	{
		//Arrange
		var current = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");
		var other = (Object)CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = current.Equals(other);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(Object?)

	#region == operator
	[Fact]
	public void ReturnsFalse_WhenOperandLeftIsNull()
	{
		//Arrange
		var left = (CommandRequest?)null;
		var right = CommandRequest.Create("c", "fake/file/path/file.txt");

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOperandRightIsNull()
	{
		//Arrange
		var left = CommandRequest.Create("c", "fake/file/path/file.txt");
		var right = (CommandRequest?)null;

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandsAreNull()
	{
		//Arrange
		var left = (CommandRequest?)null;
		var right = (CommandRequest?)null;

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandsAreDefault()
	{
		//Arrange
		var left = default(CommandRequest);
		var right = default(CommandRequest);

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandsAreEqual()
	{
		//Arrange
		var left = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");
		var right = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion == operator

	#region != operator
	[Fact]
	public void ReturnsFalse_WhenOperandsAreEqual()
	{
		//Arrange
		var left = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");
		var right = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOperandsAreNull()
	{
		//Arrange
		var left = (CommandRequest?)null;
		var right = (CommandRequest?)null;

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOperandsAreDefault()
	{
		//Arrange
		var left = default(CommandRequest);
		var right = default(CommandRequest);

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandLeftIsNull()
	{
		//Arrange
		var left = (CommandRequest?)null;
		var right = CommandRequest.Create("c", "fake/file/path/file.txt");

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandRightIsNull()
	{
		//Arrange
		var left = CommandRequest.Create("c", "fake/file/path/file.txt");
		var right = (CommandRequest?)null;

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenOperandsAreNotEqual()
	{
		//Arrange
		var left = CommandRequest.Create(["w", "m"], "fake/file/path/file.txt");
		var right = CommandRequest.Create(["c", "w", "m"], "fake/file/path/file.txt");

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion != operator
}