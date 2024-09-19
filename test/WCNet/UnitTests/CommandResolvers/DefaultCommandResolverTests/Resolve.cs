//namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandResolvers.DefaultCommandResolverTests;

//public class Resolve
//{
//    [Fact]
//    public void ReturnsCommandNotFoundInstance_WhenKeyDoesNotExists()
//    {
//        //Arrange
//        var commandMap = new Dictionary<CommandKey, ICommand>
//        {
//            { new CommandKey("-c"), new ByteCountCommand() }
//        };
//        var key = new CommandKey("-w");
//        var defaultResolver = new DefaultCommandResolver(commandMap);

//        //Act
//        var actualCommand = defaultResolver.Resolve(key);

//        //Assert
//        actualCommand.Should().BeOfType<CommandNotFound>();
//    }

//    [Fact]
//    public void ReturnsCommandFromTheDictionary_WhenKeyExists()
//    {
//        //Arrange
//        var key = new CommandKey("-c");
//        var commandMap = new Dictionary<CommandKey, ICommand>
//        {
//            { key, new ByteCountCommand() }
//        };
//        var defaultResolver = new DefaultCommandResolver(commandMap);

//        //Act
//        var actualCommand = defaultResolver.Resolve(key);

//        //Assert
//        actualCommand.Should().BeOfType<ByteCountCommand>();
//    }
//}
