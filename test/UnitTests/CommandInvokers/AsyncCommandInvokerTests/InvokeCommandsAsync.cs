namespace VP.CodingChallenge.WCNet.UnitTest.CommandInvokers.AsyncCommandInvokerTests;

public class InvokeCommandsAsync
{
	[Fact]
	public async Task ReturnsInvokerCommandsNullOrEmptyError_WhenCommandsIsNull()
	{
		//Arrange
		var invoker = new AsyncCommandInvoker();

		//Act
		var actualResult = await invoker.InvokeCommandsAsync();

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<InvokerCommandsNullOrEmptyError>()
			.And.Subject.As<InvokerCommandsNullOrEmptyError>().Message.Should().Be("Invoker commands is null or empty.");
	}

	[Fact]
	public async Task ReturnsInvokerCommandsNullOrEmptyError_WhenCommandsIsEmpty()
	{
		//Arrange
		var invoker = new AsyncCommandInvoker();
		invoker.SetCommands(Array.Empty<IAsyncCommand>());

		//Act
		var actualResult = await invoker.InvokeCommandsAsync();

		//Assert
		actualResult.IsFailed.Should().BeTrue();
		actualResult.Error.Should()
			.BeOfType<InvokerCommandsNullOrEmptyError>()
			.And.Subject.As<InvokerCommandsNullOrEmptyError>().Message.Should().Be("Invoker commands is null or empty.");
	}

	[Fact]
	public async Task ReturnsCollectionOfCountResultsWithOneItem_WhenCommandsHasOneCommand()
	{
		//Arrange
		var invoker = new AsyncCommandInvoker();
		var stubCommand = Substitute.For<IAsyncCommand>();
		var count = new Count(1);
		stubCommand.ExecuteAsync().Returns(Result<Count>.Ok(count));
		invoker.SetCommands([stubCommand]);

		//Act
		var actualResult = await invoker.InvokeCommandsAsync();

		//Assert
		actualResult.Value.Should().HaveCount(1);
	}

	[Fact]
	public async Task ReturnsCollectionOfCountResultsWithThreeItems_WhenCommandsHasThreeItems()
	{
		//Arrange
		var invoker = new AsyncCommandInvoker();
		var stubCommand1 = Substitute.For<IAsyncCommand>();
		var stubCommand2 = Substitute.For<IAsyncCommand>();
		var stubCommand3 = Substitute.For<IAsyncCommand>();
		var count1 = new Count(1);
		var count2 = new Count(2);
		var count3 = new Count(3);
		stubCommand1.ExecuteAsync().Returns(Result<Count>.Ok(count1));
		stubCommand2.ExecuteAsync().Returns(Result<Count>.Ok(count2));
		stubCommand3.ExecuteAsync().Returns(Result<Count>.Ok(count3));
		invoker.SetCommands([stubCommand1, stubCommand2, stubCommand3]);

		//Act
		var actualResult = await invoker.InvokeCommandsAsync();

		//Assert
		actualResult.Value.Should().HaveCount(3);
	}
}
