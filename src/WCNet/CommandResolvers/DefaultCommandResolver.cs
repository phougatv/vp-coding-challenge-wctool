namespace VP.CodingChallenge.WCNet.CommandResolvers;

using VP.CodingChallenge.WCNet.Commands;
using VP.CodingChallenge.WCNet.Commands.Concrete;

internal class DefaultCommandResolver : ICommandResolver
{
	private readonly IDictionary<String, ICommand> _commandMap;

	public DefaultCommandResolver(IDictionary<String, ICommand> commandMap)
	{
		_commandMap = commandMap;
	}

	public ICommand Resolve(String commandKey)
	{
		if (_commandMap.TryGetValue(commandKey, out var command))
		{
			return command;
		}

		return new CommandNotFound();
	}
}
