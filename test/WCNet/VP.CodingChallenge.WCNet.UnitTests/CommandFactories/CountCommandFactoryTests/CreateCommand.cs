namespace VP.CodingChallenge.WCNet.UnitTests.CommandFactories.CountCommandFactoryTests;

public class CreateCommand
{
    [Fact]
    public void ReturnsCommandNotFound_WhenCommandKeyIsNone()
    {
        // Arrange
        IAsyncCommand? nullCommand = null;
        var commandKeyNone = CommandKey.None;
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<IAsyncCommand>(commandKeyNone)
            .Returns(nullCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);
        

        // Act
        var actualCommand = factory.CreateCommand(commandKeyNone);

        // Assert
        actualCommand.Should()
            .NotBeNull().And
            .BeOfType<CommandNotFound>();
    }

    [Fact]
    public void ReturnsCommandNotFound_WhenCommandKeyIsNotRegisteredInServiceProvider()
    {
        //Arrange
        IAsyncCommand? nullCommand = null;
        var commandKey = new CommandKey("x");
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<IAsyncCommand>(commandKey)
            .Returns(nullCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        //Act
        var actualCommand = factory.CreateCommand(commandKey);

        //Assert
        actualCommand.Should()
            .NotBeNull().And
            .BeOfType<CommandNotFound>();
    }

    [Fact]
    public void ReturnsSpecificCommand_WhenCommandKeyIsRegisteredInServiceProvider()
    {
        //Arrange
        var commandKey = new CommandKey("c");
        var byteCountableStub = Substitute.For<IByteCountable>();
        var byteCountCommand = new ByteCountCommand(byteCountableStub);
        var keyedServiceProviderStub = Substitute.For<IKeyedServiceProvider>();
        keyedServiceProviderStub
            .GetKeyedService<IAsyncCommand>(commandKey)
            .Returns(byteCountCommand);

        var serviceProviderStub = (IServiceProvider)keyedServiceProviderStub;
        var factory = new CountCommandFactory(serviceProviderStub);

        //Act
        var actualCommand = factory.CreateCommand(commandKey);

        //Assert
        actualCommand.Should()
            .NotBeNull().And
            .BeOfType<ByteCountCommand>();
    }
}
