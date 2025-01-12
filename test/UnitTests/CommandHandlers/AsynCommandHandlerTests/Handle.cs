namespace VP.CodingChallenge.WCNet.UnitTest.CommandHandlers.AsynCommandHandlerTests;

public class Handle
{
	[Fact]
	public async Task ReturnsError_WhenCommandRequestIsNull()
	{
		//Arrange
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var commandRequest = default(CommandRequest);
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);

		//Act
		var actualResult = await commandHandler.Handle(commandRequest!);

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<CommandRequestNullError>()
			.And.Subject.As<CommandRequestNullError>().Message.Should().Be("'CommandRequest' instance cannot be null.");
	}

	[Fact]
	public async Task ReturnsError_WhenCommandRequestCommandKeysIsNull()
	{
		//Arrange
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var commandRequest = CommandRequest.Create((IReadOnlyCollection<CommandKey>)null!, "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(null!)
			.Returns(Result<ICollection<IAsyncCommand>>.Fail(CommandKeysNullOrEmptyError.Create()));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<CommandKeysNullOrEmptyError>()
			.And.Subject.As<CommandKeysNullOrEmptyError>().Message.Should().Be("'CommandKeys' cannot be null or empty.");
	}

	[Fact]
	public async Task ReturnsError_WhenCommandRequestCommandKeysIsEmpty()
	{
		//Arrange
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var commandRequest = CommandRequest.Create([], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands([])
			.Returns(Result<ICollection<IAsyncCommand>>.Fail(CommandKeysNullOrEmptyError.Create()));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<CommandKeysNullOrEmptyError>()
			.And.Subject.As<CommandKeysNullOrEmptyError>().Message.Should().Be("'CommandKeys' cannot be null or empty.");
	}

	[Fact]
	public async Task ReturnsError_WhenInvokeCommandsAreNull()
	{
		//Arrange
		var key = "c";
		var commandKey = new CommandKey(key);
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var stubCommands = (ICollection<IAsyncCommand>)null!;
		var commandRequest = CommandRequest.Create([commandKey], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(commandRequest.CommandKeys)
			.Returns(Result<ICollection<IAsyncCommand>>.Ok(stubCommands));
		stubInvoker
			.InvokeCommandsAsync()
			.Returns(Result<ICollection<Result<Count>>>.Fail(InvokerCommandsNullOrEmptyError.Create()));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<InvokerCommandsNullOrEmptyError>()
			.And.Subject.As<InvokerCommandsNullOrEmptyError>().Message.Should().Be("Invoker commands is null or empty.");
	}

	[Fact]
	public async Task ReturnsError_WhenInvokeCommandsAreEmpty()
	{
		//Arrange
		var key = "c";
		var commandKey = new CommandKey(key);
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var stubCommands = Array.Empty<IAsyncCommand>();
		var commandRequest = CommandRequest.Create([commandKey], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(commandRequest.CommandKeys)
			.Returns(Result<ICollection<IAsyncCommand>>.Ok(stubCommands));
		stubInvoker
			.InvokeCommandsAsync()
			.Returns(Result<ICollection<Result<Count>>>.Fail(InvokerCommandsNullOrEmptyError.Create()));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<InvokerCommandsNullOrEmptyError>()
			.And.Subject.As<InvokerCommandsNullOrEmptyError>().Message.Should().Be("Invoker commands is null or empty.");
	}

	[Fact]
	public async Task ReturnsMessagesWithErrors_WhenAllCommandKeysAreNotRegistered()
	{
		//Arrange
		var key_a = "a";
		var key_b = "b";
		var commandKey_a = new CommandKey(key_a);
		var commandKey_b = new CommandKey(key_b);
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var command_a = (IAsyncCommand)new CommandNotRegistered(key_a);
		var command_b = (IAsyncCommand)new CommandNotRegistered(key_b);
		var commands = new List<IAsyncCommand> { command_a, command_b };
		var countResults = new List<Result<Count>>
		{
			Result<Count>.Fail(CommandNotRegisteredError.Create(commandKey_a.Key)),
			Result<Count>.Fail(CommandNotRegisteredError.Create(commandKey_b.Key))
		};
		var commandRequest = CommandRequest.Create([commandKey_a, commandKey_b], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(commandRequest.CommandKeys)
			.Returns(Result<ICollection<IAsyncCommand>>.Ok(commands));
		stubInvoker
			.InvokeCommandsAsync()
			.Returns(Result<ICollection<Result<Count>>>.Ok(countResults));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsSuccess.Should().BeTrue();
		actualResult.Value.Should()
			.HaveCount(2)
			.And.SatisfyRespectively(
				first => first.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be($"No corresponding command is registered for CommandKey: '{key_a}'."),
				second => second.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be($"No corresponding command is registered for CommandKey: '{key_b}'.")
			);
	}

	[Fact]
	public async Task ReturnsMessagesWithCountAndErrors_WhenSomeCommandKeysAreRegisteredWhileOthersAreNot()
	{
		//Arrange
		var key_c = "c";
		var key_m = "m";
		var key_a = "a";
		var key_b = "b";
		var commandKey_c = new CommandKey(key_c);
		var commandKey_m = new CommandKey(key_m);
		var commandKey_a = new CommandKey(key_a);
		var commandKey_b = new CommandKey(key_b);
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var stubByteCountable = Substitute.For<IByteCountable>();
		var stubCharacterCountable = Substitute.For<IAsyncCharacterCountable>();
		var byteCountCommand = (IAsyncCommand)new ByteCountCommand(stubByteCountable);
		var characterCountCommand = (IAsyncCommand)new CharacterCountCommand(stubCharacterCountable);
		var commands = new List<IAsyncCommand> { byteCountCommand, characterCountCommand };
		var countResults = new List<Result<Count>>
		{
			Result<Count>.Ok(new Count(100)),
			Result<Count>.Ok(new Count(10)),
			Result<Count>.Fail(CommandNotRegisteredError.Create(commandKey_a.Key)),
			Result<Count>.Fail(CommandNotRegisteredError.Create(commandKey_b.Key))
		};
		var commandRequest = CommandRequest.Create([commandKey_c, commandKey_m, commandKey_a, commandKey_b], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(commandRequest.CommandKeys)
			.Returns(Result<ICollection<IAsyncCommand>>.Ok(commands));
		stubInvoker
			.InvokeCommandsAsync()
			.Returns(Result<ICollection<Result<Count>>>.Ok(countResults));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsSuccess.Should().BeTrue();
		actualResult.Value.Should()
			.HaveCount(4)
			.And.SatisfyRespectively(
				first => first.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be("100 file.txt"),
				second => second.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be("10 file.txt"),
				third => third.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be($"No corresponding command is registered for CommandKey: '{key_a}'."),
				fourth => fourth.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be($"No corresponding command is registered for CommandKey: '{key_b}'.")
			);
	}

	[Fact]
	public async Task ReturnsMessagesWithCount_WhenAllCommandKeysAreRegistered()
	{
		//Arrange
		var key_c = "c";
		var key_m = "m";
		var commandKey_c = new CommandKey(key_c);
		var commandKey_m = new CommandKey(key_m);
		var stubFactory = Substitute.For<ICommandFactory>();
		var stubInvoker = Substitute.For<IAsyncCommandInvoker>();
		var stubOutput = Substitute.For<IOutput>();
		var stubByteCountable = Substitute.For<IByteCountable>();
		var stubCharacterCountable = Substitute.For<IAsyncCharacterCountable>();
		var byteCountCommand = (IAsyncCommand)new ByteCountCommand(stubByteCountable);
		var characterCountCommand = (IAsyncCommand)new CharacterCountCommand(stubCharacterCountable);
		var commands = new List<IAsyncCommand> { byteCountCommand, characterCountCommand };
		var countResults = new List<Result<Count>>
		{
			Result<Count>.Ok(new Count(100)),
			Result<Count>.Ok(new Count(10))
		};
		var commandRequest = CommandRequest.Create([commandKey_c, commandKey_m], "file.txt");
		var commandHandler = new TestAsyncCommandsHandler(stubFactory, stubInvoker, stubOutput);
		stubFactory
			.CreateCommands(commandRequest.CommandKeys)
			.Returns(Result<ICollection<IAsyncCommand>>.Ok(commands));
		stubInvoker
			.InvokeCommandsAsync()
			.Returns(Result<ICollection<Result<Count>>>.Ok(countResults));

		//Act
		var actualResult = await commandHandler.Handle(commandRequest);

		//Assert
		actualResult.IsSuccess.Should().BeTrue();
		actualResult.Value.Should()
			.HaveCount(2)
			.And.SatisfyRespectively(
				first => first.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be("100 file.txt"),
				second => second.Should().BeOfType<Message>().And.Subject.As<Message>().Text.Should().Be("10 file.txt")
			);
	}
}
