namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.MessageTests;

public class GetHashCode
{
	[Fact]
	public void ReturnsSameValue_WhenSameInstanceIsCalledMultipleTimes()
	{
		//Arrange
		var message = new Message("Hello, World!");
		var expected = message.GetHashCode();

		//Act
		var actual = message.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_ForDifferentInstancesWhenTheyAreEqual()
	{
		//Arrange
		var message1 = new Message("Hello, World!");
		var message2 = new Message("Hello, World!");
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenBothMessageTextsAreNull()
	{
		//Arrange
		var message1 = new Message(null!);
		var message2 = new Message(null!);
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenBothMessageTextsAreEmpty()
	{
		//Arrange
		var message1 = new Message("");
		var message2 = new Message(String.Empty);
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenBothMessageTextsAreWhitespace()
	{
		//Arrange
		var message1 = new Message(" ");
		var message2 = new Message(" ");
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsSameValue_WhenBothMessageTextsAreDefault()
	{
		//Arrange
		var message1 = default(Message);
		var message2 = default(Message);
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().Be(expected);
	}

	[Theory]
	[InlineData(null)]				//Null
	[InlineData("")]				//Empty string
	[InlineData("Hello, World!!")]	//Extra exclamation mark
	[InlineData("!@#$%^&*()")]		//Special characters
	public void ReturnsDifferentValue_WhenMessageTextsDifferInValue(String? text)
	{
		//Arrange
		var message1 = new Message("Hello, World!");
		var message2 = new Message(text!);
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}

	[Fact]
	public void ReturnsDifferentValue_WhenMessageTextsDifferInCasing()
	{
		//Arrange
		var message1 = new Message("Hello, World!");
		var message2 = new Message("hello, world!");
		var expected = message1.GetHashCode();

		//Act
		var actual = message2.GetHashCode();

		//Assert
		actual.Should().NotBe(expected);
	}
}