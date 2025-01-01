namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandKeyTests;

/// <summary>
/// This class tests the equality logic for the <see cref="CommandKey"/> class.
/// It includes tests for the following methods and operators:
///		* <see cref="CommandKey.Equals(CommandKey)"/>
///		* <see cref="CommandKey.Equals(Object?)"/>
///		* == operator
///		* != operator
/// </summary>
public class Equals
{
	#region Equals(CommandKey)
	[Fact]
	public void ReturnsFalse_WhenCommandKeyIsDefault()
	{
		//Arrange
		CommandKey thisKey = "c";
		CommandKey otherKey = default;

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandKeysAreDifferent()
	{
		//Arrange
		var thisKey = (CommandKey)"c";
		var otherKey = CommandKey.None;

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandKeysDiffersInCasing()
	{
		//Arrange
		CommandKey thisKey = "c";
		CommandKey otherKey = "C";

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCommandKeysDiffersInWhitespace()
	{
		//Arrange
		CommandKey thisKey = "c";
		CommandKey otherKey = " c ";

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenBothCommandKeysAreDefault()
	{
		//Arrange
		CommandKey thisKey = default;
		CommandKey otherKey = default;

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCommandKeysAreEqual()
	{
		//Arrange
		CommandKey thisKey = "c";
		CommandKey otherKey = "c";

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(CommandKey)

	#region Equals(Object?)
	[Fact]
	public void ReturnsFalse_WhenKeyIsNull()
	{
		//Arrange
		CommandKey thisKey = "c";
		Object? otherKey = null;

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenKeyIsNotCommandKey()
	{
		//Arrange
		CommandKey thisKey = "c";
		var otherKey = 'c';

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenKeyIsDefaultCommandKey()
	{
		//Arrange
		CommandKey thisKey = "c";
		Object? otherKey = default(CommandKey);

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]	
	public void ReturnsTrue_WhenBothKeysAreDefaultCommandKey()
	{
		//Arrange
		CommandKey thisKey = default;
		Object? otherKey = default(CommandKey);

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenKeyIsCommandKeyAndEqual()
	{
		//Arrange
		CommandKey thisKey = "c";
		Object? otherKey = (CommandKey)"c";

		//Act
		var isEqual = thisKey.Equals(otherKey);

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion Equals(Object?)

	#region == operator
	[Fact]
	public void OperatorEquals_ReturnsFalse_WhenKeysAreNotEqual()
	{
		//Arrange
		CommandKey left = "c";
		CommandKey right = "d";

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void OperatorEquals_ReturnsFalse_WhenOnlyLeftKeyIsNull()
	{
		//Arrange
		CommandKey? left = null;
		CommandKey right = "c";

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void OperatorEquals_ReturnsTrue_WhenBothKeysAreNull()
	{
		//Arrange
		CommandKey? left = null;
		CommandKey? right = null;

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void OperatorEquals_ReturnsTrue_WhenKeysAreEqual()
	{
		//Arrange
		CommandKey left = "c";
		CommandKey right = "c";

		//Act
		var isEqual = left == right;

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion == operator

	#region != operator
	[Fact]
	public void OperatorNotEquals_ReturnsFalse_WhenKeysAreEqual()
	{
		// Arrange
		CommandKey left = "c";
		CommandKey right = "c";

		// Act
		var isEqual = left != right;

		// Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void OperatorNotEquals_ReturnsFalse_WhenBothKeysAreNull()
	{
		//Arrange
		CommandKey? left = null;
		CommandKey? right = null;

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeFalse();
	}

	[Fact]
	public void OperatorNotEquals_ReturnsTrue_WhenKeysAreNotEqual()
	{
		// Arrange
		CommandKey left = "c";
		CommandKey right = "d";

		// Act
		var isEqual = left != right;

		// Assert
		isEqual.Should().BeTrue();
	}

	[Fact]
	public void OperatorNotEquals_ReturnsTrue_WhenOnlyLeftKeyIsNull()
	{
		//Arrange
		CommandKey? left = null;
		CommandKey right = "c";

		//Act
		var isEqual = left != right;

		//Assert
		isEqual.Should().BeTrue();
	}
	#endregion != operator
}
