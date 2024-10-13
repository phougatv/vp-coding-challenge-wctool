namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandInvokers.CommandInvokerTests;

using VP.CodingChallenge.WCNet.CommandInvokers;

public class InvokeCommand
{
    [Fact]
    public void ReturnsCommandNotSetError_WhenCommandIsNotSet()
    {
        //Arrange
        var invoker = new CommandInvoker();

        //Act
        var result = invoker.InvokeCommand();

        //Assert
        result.Should()
            .NotBeNull().And
            .BeOfType<Result<Count>>();
        result.IsFailed.Should().BeTrue();
        result.Error.Should()
            .BeOfType<CommandNotSetError>();
    }

    [Fact]
    public void ReturnsResultCount_WhenCommandIsSet()
    {
        //Arrange
        var count = new Count(1);
        var resultCount = Result<Count>.Ok(count);
        var commandStub = Substitute.For<ICommand>();
        commandStub
            .Execute()
            .Returns(resultCount);

        var invoker = new CommandInvoker();
        invoker.SetCommand(commandStub);

        //Act
        var result = invoker.InvokeCommand();

        //Assert
        result.Should()
            .NotBeNull().And
            .BeOfType<Result<Count>>();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(count);
    }
}
