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
        var countResults = new List<Result<UInt64>>(commandArgument.CommandKeys.Length);
        foreach (var key in commandArgument.CommandKeys)
        {
            var command = _commandResolver.Resolve(key);
            var result = command.Execute(commandArgument.Filepath);
            countResults.Add(result);
        }

        var filename = Path.GetFileName(commandArgument.Filepath);
        var countText = String.Join(' ', countResults.Select(r => r.Value));

        return Result<Message>.Ok($"{countText} {filename}");
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }

    protected override Result<CommandArgument> PreHandle(String[] args) => _commandParser.Parse(args);
}
