namespace VP.CodingChallenge.WCNet.UnitTest.CommandHandlers.TestDoubles;

/// <summary>
/// A test-specific subclass of <see cref="AsyncCommandsHandler"/> that exposes the protected Handle method 
/// for direct testing purposes.
/// </summary>
/// <param name="factory">The <see cref="ICommandFactory"/> used to create command instances.</param>
/// <param name="invoker">The <see cref="IAsyncCommandInvoker"/> used to execute asynchronous commands.</param>
/// <param name="output">The <see cref="IOutput"/> used to handle output messages.</param>
internal class TestAsyncCommandsHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
	: AsyncCommandsHandler(factory, invoker, output)
{
	/// <summary>
	/// Exposes the protected Handle method from <see cref="AsyncCommandsHandler"/> for unit testing.
	/// </summary>
	/// <param name="commandRequest">The command request to handle.</param>
	/// <returns>A <see cref="Result{T}"/> containing a collection of messages resulting from the command execution.</returns>
	internal new async Task<Result<ICollection<Message>>> Handle(CommandRequest commandRequest)
		=> await base.Handle(commandRequest);
}
