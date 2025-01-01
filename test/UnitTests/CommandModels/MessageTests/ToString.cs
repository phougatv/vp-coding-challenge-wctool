namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.MessageTests;

public class ToString
{
	[Fact]
	public void ReturnsTextInExpectedFormat_WhenTextHasValue()
	{
		//Arrange
		var message = new Message("Hello, World!");
		var expected = "Message=[Text: \"Hello, World!\"]";

		//Act
		var actual = message.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsTextInExpectedFormat_WhenMessageIsDefault()
	{
		//Arrange
		var message = default(Message);
		var expected = "Message=[Text: \"null\"]";

		//Act
		var actual = message.ToString();

		//Assert
		actual.Should().Be(expected);
	}

	[Fact]
	public void ReturnsTextInExpectedFormat_WhenTextIsEmpty()
	{
		//Arrange
		var message1 = new Message("");
		var message2 = new Message(String.Empty);
		var expected = "Message=[Text: \"empty\"]";

		//Act
		var actual1 = message1.ToString();
		var actual2 = message2.ToString();

		//Assert
		actual1.Should().Be(actual2).And.Be(expected);
	}

	[Fact]
	public void ReturnsTextInExpectedFormat_WhenTextIsNull()
	{
		//Arrange
		var message = new Message(null!);
		var expected = "Message=[Text: \"null\"]";

		//Act
		var actual = message.ToString();

		//Assert
		actual.Should().Be(expected);
	}
}
