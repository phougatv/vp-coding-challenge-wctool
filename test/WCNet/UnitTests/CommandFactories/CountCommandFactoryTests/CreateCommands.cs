namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandFactories.CountCommandFactoryTests;

public class CreateCommands
{
    [Fact]
    public void ReturnsEmptyCollectionOfCommand_WhenCommandKeyCollectionIsEmpty()
    {
        // Arrange
        var commandKeys = Array.Empty<CommandKey>();
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        // Act
        var actualCommands = factory.CreateCommands(commandKeys);

        // Assert
        actualCommands.Should()
            .NotBeNull().And
            .BeEmpty();
    }

    [Fact]
    public void ReturnsCollectionOfCommandNotFound_ForAllUnregisteredCommandKeys()
    {
        // Arrange
        ICommand? nullCommand = null;
        var x_commandKey = new CommandKey("x");
        var y_commandKey = new CommandKey("y");
        var z_commandKey = new CommandKey("z");
        var commandKeys = new[] { x_commandKey, y_commandKey, z_commandKey };
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(x_commandKey)
            .Returns(nullCommand);
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(y_commandKey)
            .Returns(nullCommand);
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(z_commandKey)
            .Returns(nullCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        // Act
        var actualCommands = factory.CreateCommands(commandKeys);

        // Assert
        actualCommands.Should()
            .NotBeNullOrEmpty().And
            .HaveCount(3).And
            .OnlyContain(c => c is CommandNotFound);
    }

    [Fact]
    public void ReturnsCollectionOfCommandsWhichAlsoContainsCommandNotFound_ForUnregisteredCommandKeys()
    {
        // Arrange
        ICommand? nullCommand = null;
        var x_commandKey = new CommandKey("x");
        var y_commandKey = new CommandKey("y");
        var c_commandKey = new CommandKey("c");
        var commandKeys = new[] { x_commandKey, y_commandKey, c_commandKey };
        var byteCountableStub = Substitute.For<IByteCountable>();
        var byteCountCommand = new ByteCountCommand(byteCountableStub);
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(x_commandKey)
            .Returns(nullCommand);
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(y_commandKey)
            .Returns(nullCommand);
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(c_commandKey)
            .Returns(byteCountCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        // Act
        var actualCommands = factory.CreateCommands(commandKeys);

        // Assert
        actualCommands.Should()
            .NotBeNullOrEmpty().And
            .HaveCount(3).And
            .SatisfyRespectively(
                c => c.Should().BeOfType<CommandNotFound>(),
                c => c.Should().BeOfType<CommandNotFound>(),
                c => c.Should().BeOfType<ByteCountCommand>());
    }

    [Fact]
    public void ReturnsCollectionOfCommands_ForAllRegisteredCommandsKeys()
    {
        //Arrange
        var c_commandKey = new CommandKey("c");
        var l_commandKey = new CommandKey("l");
        var commandKeys = new[] { c_commandKey, l_commandKey };
        var byteCountableStub = Substitute.For<IByteCountable>();
        var byteCountCommand = new ByteCountCommand(byteCountableStub);
        var lineCountableStub = Substitute.For<ILineCountable>();
        var lineCountCommand = new LineCountCommand(lineCountableStub);
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(c_commandKey)
            .Returns(byteCountCommand);
        keyedServiceProviderStub
            .GetKeyedService<ICommand>(l_commandKey)
            .Returns(lineCountCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        //Act
        var actualCommands = factory.CreateCommands(commandKeys);

        //Assert
        actualCommands.Should()
            .NotBeNullOrEmpty().And
            .HaveCount(2).And
            .SatisfyRespectively(
                c => c.Should().BeOfType<ByteCountCommand>(),
                c => c.Should().BeOfType<LineCountCommand>());
    }
}
