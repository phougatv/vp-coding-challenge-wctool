namespace VP.CodingChallenge.WCNet.CommandHandlers;

using LightResults;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly ICommandParser _commandParser;

	public DefaultCommandHandler(ICommandResolver commandResolver, ICommandParser commandParser)
	{
		_commandResolver = commandResolver;
        _commandParser = commandParser;
	}

	internal override Result<Message> Handle(CommandArgument commandArgument)
	{
        var command = _commandResolver.Resolve(commandArgument.CommandKey);
        var text = command.Execute(commandArgument.Filepath);
        return Result<Message>.Ok(text);
	}

    internal override Result PostHandle(Message message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
    internal override Result<CommandArgument> PreHandle(String[] args) => _commandParser.Parse(args);
}
