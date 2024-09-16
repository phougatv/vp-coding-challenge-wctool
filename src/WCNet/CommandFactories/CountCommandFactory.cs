namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory : ICommandFactory
{
    private readonly IDictionary<CommandKey, Type> _commandTypeMap;

    public CountCommandFactory(IDictionary<CommandKey, Type> commandTypeMap)
    {
        _commandTypeMap = commandTypeMap;
    }

    public ICommand CreateCommand(CommandArgument request)
    {
        if (_commandTypeMap.TryGetValue(request.CommandKey, out var commandType))
        {
            return (ICommand?)Activator.CreateInstance(commandType, request.Filepath) ?? new CommandNotFound();
        }

        return new CommandNotFound();
    }
}
