namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.MessageTests;

public class Equals
{
	#region Equals(Message)
	[Fact]
	public void ReturnsFalse_WhenOtherIsNullMessageText()
	{
		//Arrange
		var current = new Message("Test");
		var other = new Message(null!);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOtherIsEmptyMessageText()
	{
		//Arrange
		var current = new Message("Test");
		var other_1 = new Message("");
		var other_2 = new Message(String.Empty);

		//Act
		var actual_1 = current.Equals(other_1);
		var actual_2 = current.Equals(other_2);

		//Assert
		actual_1.Should().BeFalse();
		actual_2.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOtherIsDefaultMessageText()
	{
		//Arrange
		var current = new Message("Test");
		var other = default(Message);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenCurrentIsDefaultMessageText()
	{
		//Arrange
		var current = default(Message);
		var other = new Message("Test");

		//Act
		var actual = other.Equals(current);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenOtherIsNotEqual()
	{
		//Arrange
		var current = new Message("Test");
		var other = new Message("Test 2");

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenCurrentAndOtherAreHaveNullText()
	{
		//Arrange
		var current = new Message(null!);
		var other = new Message(null!);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCurrentAndOtherAreHaveEmptyText()
	{
		//Arrange
		var current = new Message("");
		var other = new Message(String.Empty);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCurrentAndOtherAreDefault()
	{
		//Arrange
		var current = default(Message);
		var other = default(Message);

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}

	[Fact]
	public void ReturnsTrue_WhenCurrentAndOtherAreEqual()
	{
		//Arrange
		var current = new Message("Test");
		var other = new Message("Test");

		//Act
		var actual = current.Equals(other);

		//Assert
		actual.Should().BeTrue();
	}
	#endregion Equals(Message)

	#region Equals(Object)
	[Fact]
	public void ReturnsFalse_WhenObjectIsNull()
	{
		//Arrange
		var @this = new Message("Test");
		Object? obj = null;

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsNotOfTypeMessage()
	{
		//Arrange
		var @this = new Message("Test");
		Object obj = new CommandKey("Test");

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsFalse_WhenObjectIsOfTypeMessageButIsNotEqual()
	{
		//Arrange
		var @this = new Message("Test");
		Object obj = new Message("Test 2");

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenObjectIsOfTypeMessageAndIsEqual()
	{
		//Arrange
		var @this = new Message("Test");
		Object obj = new Message("Test");

		//Act
		var actual = @this.Equals(obj);

		//Assert
		actual.Should().BeTrue();
	}
	#endregion Equals(Object)

	#region == Operator
	[Fact]
	public void ReturnsFalse_WhenLeftAndRightAreNotEqual()
	{
		//Arrange
		var left = new Message("Test");
		var right = new Message("Test 2");

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreEqual()
	{
		//Arrange
		var left = new Message("Test");
		var right = new Message("Test");

		//Act
		var actual = left == right;

		//Assert
		actual.Should().BeTrue();
	}
	#endregion == Operator

	#region != Operator
	[Fact]
	public void ReturnsFalse_WhenLeftAndRightAreEqual()
	{
		//Arrange
		var left = new Message("Test");
		var right = new Message("Test");

		//Act
		var actual = left != right;

		//Assert
		actual.Should().BeFalse();
	}

	[Fact]
	public void ReturnsTrue_WhenLeftAndRightAreNotEqual()
	{
		//Arrange
		var left = new Message("Test");
		var right = new Message("Test 2");

		//Act
		var actual = left != right;

		//Assert
		actual.Should().BeTrue();
	}
	#endregion != Operator
}
