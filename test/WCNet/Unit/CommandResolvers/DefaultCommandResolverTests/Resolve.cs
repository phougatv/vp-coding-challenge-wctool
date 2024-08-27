namespace VP.CodingChallenge.WCNet.Test.Unit.CommandResolvers.DefaultCommandResolverTests;

public class Resolve
{
	[Fact]
	public void ReturnsCommandNotFoundInstance_WhenKeyDoesNotExists()
	{
		//Arrange
		var commandMap = new Dictionary<String, ICommand>
		{
			{ "-c", new ByteCountCommand() }
		};
		var key = new Command("-w");
		var defaultResolver = new DefaultCommandResolver(commandMap);

		//Act
		var actualCommand = defaultResolver.Resolve(key);

		//Assert
		actualCommand.Should().BeOfType<CommandNotFound>();
	}

	[Fact]
	public void ReturnsCommandFromTheDictionary_WhenKeyExists()
	{
		//Arrange
		var commandMap = new Dictionary<String, ICommand>
		{
			{ "-c", new ByteCountCommand() }
		};
		var key = new Command("-c");
		var defaultResolver = new DefaultCommandResolver(commandMap);

		//Act
		var actualCommand = defaultResolver.Resolve(key);

		//Assert
		actualCommand.Should().BeOfType<ByteCountCommand>();
	}
}
