namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandResolver _commandResolver;
<<<<<<< HEAD
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
=======
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
>>>>>>> master
	}

    protected override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
<<<<<<< HEAD
=======

    protected override Result<CommandArgument> PreHandle(String[] args) => _commandParser.Parse(args);
>>>>>>> master
}
