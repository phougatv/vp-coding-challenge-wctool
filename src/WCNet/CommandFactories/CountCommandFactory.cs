[assembly: InternalsVisibleTo("WCNet.Tests")]
namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    public ICommand CreateCommand(CommandKey commandKey)
    {
        var command = serviceProvider.GetKeyedService<ICommand>(commandKey);
        if (command is null)
        {
            return new CommandNotFound(commandKey);
        }

        return command;
    }

    public ICollection<ICommand> CreateCommands(IReadOnlyList<CommandKey> commandKeys)
    {
        ICollection<ICommand> commands = commandKeys.Count < 1 ? Array.Empty<ICommand>() : new List<ICommand>(commandKeys.Count);
        foreach (var commandKey in commandKeys)
        {
            var command = serviceProvider.GetKeyedService<ICommand>(commandKey);
            if (command is null)
            {
                commands.Add(new CommandNotFound(commandKey));
                continue;
            }

            commands.Add(command);
        }

        return commands;
    }
}