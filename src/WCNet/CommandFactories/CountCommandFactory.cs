namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory : ICommandFactory
{
    private readonly IDictionary<Command, Type> _commandTypeMap;

    public CountCommandFactory(IDictionary<Command, Type> commandTypeMap)
    {
        _commandTypeMap = commandTypeMap;
    }

    public ICommand CreateCommand(CommandRequest request)
    {
        if (_commandTypeMap.TryGetValue(request.CommandKey, out var commandType))
        {
            var command = (ICommand?)Activator.CreateInstance(commandType, request.Filepath) ?? new CommandNotFound();
            return command;
        }

        return new CommandNotFound();
    }
}