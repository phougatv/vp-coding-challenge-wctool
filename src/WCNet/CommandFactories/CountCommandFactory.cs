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

    public ICollection<ICommand> CreateCommands(CommandRequest request)
    {
        var defaultCommandKeys = request.DefaultCommandKeys;
        ICollection<ICommand> defaultCommands = defaultCommandKeys.Count < 1 ? Array.Empty<ICommand>() : new List<ICommand>(defaultCommandKeys.Count);
        foreach (var command in defaultCommandKeys)
        {
            if (_commandTypeMap.TryGetValue(command, out var commandType))
            {
                var defaultCommand = (ICommand?)Activator.CreateInstance(commandType, request.Filepath) ?? new CommandNotFound();
                defaultCommands.Add(defaultCommand);
            }
        }

        return defaultCommands;
    }
}