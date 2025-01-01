namespace VP.CodingChallenge.WCNet.UnitTest.CommandModels.CommandKeyTests;

public class CastingOperators
{
	[Fact]
	public void Successfully_ConvertsStringToCommandKey()
	{
		//Arrange
		var key = "c";

		//Act
		CommandKey commandKey = key;

		//Assert
		commandKey.Key.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsEmptyStringToCommandKey()
	{
		//Arrange
		var key = String.Empty;

		//Act
		CommandKey commandKey = key;

		//Assert
		commandKey.Key.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsWhitespaceStringToCommandKey()
	{
		//Arrange
		var key = " ";

		//Act
		CommandKey commandKey = key;

		//Assert
		commandKey.Key.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsCommandKeyToString()
	{
		//Arrange
		var key = "c";
		var commandKey = new CommandKey(key);

		//Act
		String actualKey = commandKey;

		//Assert
		actualKey.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsCommandKeyToEmptyString()
	{
		//Arrange
		var key = String.Empty;
		var commandKey = new CommandKey(key);

		//Act
		String actualKey = commandKey;

		//Assert
		actualKey.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsCommandKeyToWhitespaceString()
	{
		//Arrange
		var key = " ";
		var commandKey = new CommandKey(key);

		//Act
		String actualKey = commandKey;

		//Assert
		actualKey.Should().Be(key);
	}

	[Fact]
	public void Successfully_ConvertsDefaultCommandKeyToNullString()
	{
		//Arrange
		var key = default(CommandKey);

		//Act
		String actualKey = key;

		//Assert
		actualKey.Should().BeNull();
	}
}
