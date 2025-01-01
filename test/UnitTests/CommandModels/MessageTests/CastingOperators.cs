namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.MessageTests;

public class CastingOperators
{
	[Fact]
	public void Successfully_ConvertsStringToMessage()
	{
		//Arrange
		var text = "Hello World!";

		//Act
		Message message = text;

		//Assert
		message.Text.Should().Be(text);
	}

	[Fact]
	public void Successfully_ConvertsEmptyStringToMessage()
	{
		//Arrange
		var text = "";

		//Act
		Message message = text;

		//Assert
		message.Text.Should().Be(text).And.Be(String.Empty);
	}

	[Fact]
	public void Successfully_ConvertsNullStringToMessage()
	{
		//Arrange
		var text = (String)null!;
		var message = new Message(text);

		//Act
		String actualText = message;

		//Assert
		actualText.Should().Be(text);
	}

	[Theory]
	[InlineData(" ")]			//Single whitespace
	[InlineData("  ")]			//Multiple whitespaces
	[InlineData("1234567890")]	//Numbers
	[InlineData("!@#$%^&*()")]	//Special characters
	public void Successfully_ConvertsStringContainigSpecialCharactersToMessage(String text)
	{
		//Arrange & Act
		var message = new Message(text);

		//Assert
		message.Text.Should().Be(text);
	}

	[Fact]
	public void Successfully_ConvertsMessageToString()
	{
		//Arrange
		var text = "Hello World!";
		var message = new Message(text);

		//Act
		String actualText = message;

		//Assert
		actualText.Should().Be(text);
	}

	[Fact]
	public void Successfully_ConvertsEmptyMessageToString()
	{
		//Arrange
		var text = "";
		var message = new Message(text);

		//Act
		String actualText = message;

		//Assert
		actualText.Should().Be(text).And.Be(String.Empty);
	}

	[Fact]
	public void Successfully_ConvertsNullMessageToString()
	{
		//Arrange
		var text = (String)null!;
		var message = new Message(text);

		//Act
		String actualText = message;

		//Assert
		actualText.Should().Be(text);
	}

	[Theory]
	[InlineData(" ")]           //Single whitespace
	[InlineData("  ")]          //Multiple whitespaces
	[InlineData("1234567890")]  //Numbers
	[InlineData("!@#$%^&*()")]  //Special characters
	public void Successfully_ConvertsMessageTextContainigSpecialCharactersToString(String text)
	{
		//Arrange
		var message = new Message(text);

		//Act
		String actual = message;

		//Assert
		actual.Should().Be(text);
	}
}
