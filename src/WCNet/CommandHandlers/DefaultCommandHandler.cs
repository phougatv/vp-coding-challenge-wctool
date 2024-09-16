namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandResolver _commandResolver;

    public DefaultCommandHandler(ICommandResolver commandResolver)
	{
		_commandResolver = commandResolver;
	}

    protected override Result<Message> Handle(CommandArgument commandArgument)
	{
        var command = _commandResolver.ResolveCommand(commandArgument);
        var countResult = command.Execute();
        var filename = Path.GetFileName(commandArgument.Filepath);

        return Result<Message>.Ok($"{countResult.Value} {filename}");
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
}
