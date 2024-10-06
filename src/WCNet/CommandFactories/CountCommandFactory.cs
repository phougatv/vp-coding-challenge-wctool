namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    public ICommand CreateCommand(CommandRequest request)
    {
        var commandKey = request.CommandKey;
        var command = serviceProvider.GetRequiredKeyedService<ICommand>(commandKey);
        if (command is null)
        {
            return new CommandNotFound();
        }

        return command;
    }

    public ICollection<ICommand> CreateCommands(CommandRequest request)
    {
        var defaultCommandKeys = request.DefaultCommandKeys;
        ICollection<ICommand> defaultCommands = defaultCommandKeys.Count < 1 ? Array.Empty<ICommand>() : new List<ICommand>(defaultCommandKeys.Count);
        foreach (var command in defaultCommandKeys)
        {
            var defaultCommand = serviceProvider.GetRequiredKeyedService<ICommand>(command);
            if (defaultCommand is null) continue;

            defaultCommands.Add(defaultCommand);
        }

        return defaultCommands;
    }
}