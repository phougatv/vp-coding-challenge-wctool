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
        //var countResults = new List<Result<UInt64>>(commandArgument.CommandKey.Length);
        //foreach (var key in commandArgument.CommandKey)
        //{
        //    var command = _commandResolver.Resolve(key);
        //    var result = command.Execute(commandArgument.Filepath);
        //    countResults.Add(result);
        //}

        var command = _commandResolver.Resolve(commandArgument.CommandKey);
        var countResult = command.Execute(commandArgument.Filepath);
        var filename = Path.GetFileName(commandArgument.Filepath);

        return Result<Message>.Ok($"{countResult.Value} {filename}");
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }

    //protected override Result<CommandArgument> PreHandle(String[] args) => _commandParser.Parse(args);
}
