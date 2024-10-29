[assembly: InternalsVisibleTo("WCNet.Tests")]
namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    public IAsyncCommand CreateCommand(CommandKey commandKey)
    {
        var command = serviceProvider.GetKeyedService<IAsyncCommand>(commandKey);
        if (command is null)
        {
            return new CommandNotFound(commandKey);
        }

        return command;
    }

    public ICollection<IAsyncCommand> CreateCommands(IReadOnlyCollection<CommandKey> commandKeys)
    {
        ICollection<IAsyncCommand> commands = commandKeys.Count < 1 ? Array.Empty<IAsyncCommand>() : new List<IAsyncCommand>(commandKeys.Count);
        foreach (var commandKey in commandKeys)
        {
            var command = serviceProvider.GetKeyedService<IAsyncCommand>(commandKey);
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