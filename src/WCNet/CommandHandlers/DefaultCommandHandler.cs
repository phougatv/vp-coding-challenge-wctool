namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly ICommandInvoker _invoker;

    public DefaultCommandHandler(ICommandResolver commandResolver, ICommandInvoker invoker)
	{
		_commandResolver = commandResolver;
        _invoker = invoker;
	}

    protected override Result<Message> Handle(CommandRequest request)
	{
        var command = _commandResolver.ResolveCommand(request);
        _invoker.SetCommand(command);
        _invoker.InvokeCommand();

        return Result<Message>.Ok($"Command executed successfully.");
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
}
