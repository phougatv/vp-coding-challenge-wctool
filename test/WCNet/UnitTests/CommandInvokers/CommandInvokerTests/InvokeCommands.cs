namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandInvokers.CommandInvokerTests;

using VP.CodingChallenge.WCNet.CommandInvokers;

public class InvokeCommands
{
    [Fact]
    public void ReturnsCommandNotSetError_WhenCommandsAreNotSet()
    {
        //Arrange
        var invoker = new CommandInvoker();

        //Act
        var result = invoker.InvokeCommands();

        //Assert
        result.Should()
            .NotBeNull().And
            .BeOfType<Result<ICollection<Count>>>();
        result.IsFailed.Should().BeTrue();
        result.Error.Should()
            .BeOfType<CommandNotSetError>();
    }

    [Fact]
    public void ReturnsResultOfCountCollection_WhenOneCommandIsSet()
    {
        //Arrange
        var count = new Count(1);
        var resultCount = Result<Count>.Ok(count);
        var commandStub = Substitute.For<ICommand>();
        commandStub
            .Execute()
            .Returns(resultCount);

        var invoker = new CommandInvoker();
        var commands = new List<ICommand> { commandStub };
        invoker.SetCommands(commands);

        //Act
        var result = invoker.InvokeCommands();

        //Assert
        result.Should()
            .NotBeNull().And
            .BeOfType<Result<ICollection<Count>>>();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should()
            .NotBeNullOrEmpty().And
            .HaveCount(1).And
            .Equal([count]);
    }

    [Fact]
    public void ReturnsResultOfCountCollection_WhenMultipleCommandsAreSet()
    {
        //Arrange
        var count1 = new Count(1);
        var resultCount1 = Result<Count>.Ok(count1);
        var commandStub1 = Substitute.For<ICommand>();
        commandStub1
            .Execute()
            .Returns(resultCount1);

        var count2 = new Count(2);
        var resultCount2 = Result<Count>.Ok(count2);
        var commandStub2 = Substitute.For<ICommand>();
        commandStub2
            .Execute()
            .Returns(resultCount2);

        var invoker = new CommandInvoker();
        var commands = new List<ICommand> { commandStub1, commandStub2 };
        invoker.SetCommands(commands);

        //Act
        var result = invoker.InvokeCommands();

        //Assert
        result.Should()
            .NotBeNull().And
            .BeOfType<Result<ICollection<Count>>>();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should()
            .NotBeNullOrEmpty().And
            .HaveCount(2).And
            .Equal([count1, count2]);
    }
}
