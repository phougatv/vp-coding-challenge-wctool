namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly ICommandParser _commandParser;

    public DefaultCommandHandler(ICommandResolver commandResolver, ICommandParser commandParser)
	{
		_commandResolver = commandResolver;
        _commandParser = commandParser;
	}

    protected override Result<Message> Handle(CommandArgument commandArgument)
	{
        var command = _commandResolver.Resolve(commandArgument.CommandKey);
        var text = command.Execute(commandArgument.Filepath);
        if (String.IsNullOrEmpty(text))
        {
            return Result<Message>.Fail(CommandExecutionError.Create(commandArgument.CommandKey));
        }

        return Result<Message>.Ok(text);
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
    protected override Result<CommandArgument> PreHandle(String[] args) => _commandParser.Parse(args);
}
