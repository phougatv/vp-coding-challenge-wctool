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

    protected override Result<Message> Handle(CommandArgument commandArgument)
	{
        var command = _commandResolver.ResolveCommand(commandArgument);
        _invoker.SetCommand(command);

        var countResult = _invoker.InvokeCommand();
        var filename = Path.GetFileName(commandArgument.Filepath);

        return Result<Message>.Ok($"{countResult.Value} {filename}");
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
}
