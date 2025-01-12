namespace VP.CodingChallenge.WCNet.UnitTest.CommandFactories.CountCommandFactoryTests;

public class CreateCommands
{
	[Fact]
	public void ReturnsCommandKeyNullOrEmptyError_WhenCommandKeysIsNull()
	{
		//Arrange
		var serviceProvider = Substitute.For<IServiceProvider>();
		var commandFactory = new CountCommandFactory(serviceProvider);

		//Act
		var actualResults = commandFactory.CreateCommands(null!);

		//Assert
		actualResults.Should().NotBeNull();
		actualResults.IsFailed.Should().BeTrue();
		actualResults.Error.Should()
			.BeOfType<CommandKeysNullOrEmptyError>().And
			.Subject.As<CommandKeysNullOrEmptyError>().ToString().Should().Be("'CommandKeys' cannot be null or empty.");
	}

	[Fact]
	public void ReturnsCommandKeyNullOrEmptyError_WhenCommandKeysIsEmpty()
	{
		//Arrange
		var serviceProvider = Substitute.For<IServiceProvider>();
		var commandFactory = new CountCommandFactory(serviceProvider);
		var commandKeys = Array.Empty<CommandKey>();

		//Act
		var actualResults = commandFactory.CreateCommands(commandKeys);

		//Assert
		actualResults.Should().NotBeNull();
		actualResults.IsFailed.Should().BeTrue();
		actualResults.Error.Should()
			.BeOfType<CommandKeysNullOrEmptyError>().And
			.Subject.As<CommandKeysNullOrEmptyError>().ToString().Should().Be("'CommandKeys' cannot be null or empty.");
	}

	[Fact]
	public void ReturnsCollectionOfAsyncCommandWithOneItem_WhenCommandKeysHasOneRegisteredCommandKey()
	{
		//Arrange
		var key = "c";
		var commandKey = new CommandKey(key);
		var commandKeys = (IReadOnlyCollection<CommandKey>)[commandKey];
		var stubByteCountable = Substitute.For<IByteCountable>();
		var byteCountCommand = (IAsyncCommand)new ByteCountCommand(stubByteCountable);
		var stubKeyedserviceProvider = Substitute.For<IKeyedServiceProvider>();
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey).Returns(byteCountCommand);

		var commandFactory = new CountCommandFactory(stubKeyedserviceProvider);

		//Act
		var actualResults = commandFactory.CreateCommands(commandKeys);

		//Assert
		actualResults.Value.Should()
			.BeAssignableTo<ICollection<IAsyncCommand>>()
			.And.HaveCount(1);

		actualResults.Value.First().Should()
			.BeOfType<ByteCountCommand>()
			.And.BeAssignableTo<IAsyncCommand>();
	}

	[Fact]
	public void ReturnsCollectionOfAsyncCommandWithThreeItems_WhenCommandKeysHasThreeRegisteredCommandKeys()
	{
		//Arrange
		var key1 = "c";
		var key2 = "w";
		var key3 = "l";
		var commandKey1 = new CommandKey(key1);
		var commandKey2 = new CommandKey(key2);
		var commandKey3 = new CommandKey(key3);
		var commandKeys = (IReadOnlyCollection<CommandKey>)[commandKey1, commandKey2, commandKey3];
		var stubByteCountable = Substitute.For<IByteCountable>();
		var stubWordCountable = Substitute.For<IAsyncWordCountable>();
		var stubLineCountable = Substitute.For<IAsyncLineCountable>();
		var expected1 = (IAsyncCommand)new ByteCountCommand(stubByteCountable);
		var expected2 = (IAsyncCommand)new WordCountCommand(stubWordCountable);
		var expected3 = (IAsyncCommand)new LineCountCommand(stubLineCountable);
		var stubKeyedserviceProvider = Substitute.For<IKeyedServiceProvider>();
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey1).Returns(expected1);
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey2).Returns(expected2);
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey3).Returns(expected3);

		var commandFactory = new CountCommandFactory(stubKeyedserviceProvider);

		//Act
		var actualResults = commandFactory.CreateCommands(commandKeys);

		//Assert
		actualResults.Value.Should()
			.BeAssignableTo<ICollection<IAsyncCommand>>()
			.And.HaveCount(3);

		actualResults.Value.Should().SatisfyRespectively(
			first => first.Should().BeOfType<ByteCountCommand>().And.BeAssignableTo<IAsyncCommand>(),
			second => second.Should().BeOfType<WordCountCommand>().And.BeAssignableTo<IAsyncCommand>(),
			third => third.Should().BeOfType<LineCountCommand>().And.BeAssignableTo<IAsyncCommand>()
		);
	}

	[Fact]
	public void ReturnsCollectionOfAsyncCommandWithTwoItems_WhenCommandKeysHasOneRegisteredAndOneUnregisteredCommandKeys()
	{
		//Arrange
		var key1 = "c";
		var key2 = "w";
		var commandKey1 = new CommandKey(key1);
		var commandKey2 = new CommandKey(key2);
		var commandKeys = (IReadOnlyCollection<CommandKey>)[commandKey1, commandKey2];
		var stubByteCountable = Substitute.For<IByteCountable>();
		var expected1 = (IAsyncCommand)new ByteCountCommand(stubByteCountable);
		var stubKeyedserviceProvider = Substitute.For<IKeyedServiceProvider>();
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey1).Returns(expected1);
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey2).Returns((IAsyncCommand)null!);

		var commandFactory = new CountCommandFactory(stubKeyedserviceProvider);

		//Act
		var actualResults = commandFactory.CreateCommands(commandKeys);

		//Assert
		actualResults.Value.Should()
			.BeAssignableTo<ICollection<IAsyncCommand>>()
			.And.HaveCount(2);

		actualResults.Value.Should().SatisfyRespectively(
			first => first.Should().BeOfType<ByteCountCommand>().And.BeAssignableTo<IAsyncCommand>(),
			second => second.Should().BeOfType<CommandNotRegistered>().And.BeAssignableTo<IAsyncCommand>()
		);
	}

	[Fact]
	public void ReturnsCollectionOfAsyncCommandWithTwoItems_WhenCommandKeysHasTwoUnregisteredCommandKeys()
	{
		//Arrange
		var key1 = "c";
		var key2 = "w";
		var commandKey1 = new CommandKey(key1);
		var commandKey2 = new CommandKey(key2);
		var commandKeys = (IReadOnlyCollection<CommandKey>)[commandKey1, commandKey2];
		var stubKeyedserviceProvider = Substitute.For<IKeyedServiceProvider>();
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey1).Returns((IAsyncCommand)null!);
		stubKeyedserviceProvider.GetKeyedService<IAsyncCommand>(commandKey2).Returns((IAsyncCommand)null!);

		var commandFactory = new CountCommandFactory(stubKeyedserviceProvider);

		//Act
		var actualResults = commandFactory.CreateCommands(commandKeys);

		//Assert
		actualResults.Value.Should()
			.BeAssignableTo<ICollection<IAsyncCommand>>()
			.And.HaveCount(2);

		actualResults.Value.Should().SatisfyRespectively(
			first => first.Should().BeOfType<CommandNotRegistered>().And.BeAssignableTo<IAsyncCommand>(),
			second => second.Should().BeOfType<CommandNotRegistered>().And.BeAssignableTo<IAsyncCommand>()
		);
	}
}
