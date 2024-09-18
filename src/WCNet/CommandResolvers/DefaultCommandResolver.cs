namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal class DefaultCommandResolver : ICommandResolver
{
<<<<<<< HEAD
	private readonly ICommandFactory _factory;

	public DefaultCommandResolver(ICommandFactory factory)
	{
		_factory = factory;
	}

    public ICommand ResolveCommand(CommandRequest request)
    {
        return _factory.CreateCommand(request);
    }
=======
	private readonly IDictionary<CommandKey, ICommand> _commandMap;

	public DefaultCommandResolver(IDictionary<CommandKey, ICommand> commandMap)
	{
		_commandMap = commandMap;
	}

	public ICommand Resolve(CommandKey commandKey)
	{
		if (_commandMap.TryGetValue(commandKey, out var command))
		{
			return command;
		}

		return new CommandNotFound();
	}
>>>>>>> master
}
