namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal class DefaultCommandResolver : ICommandResolver
{
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
}
