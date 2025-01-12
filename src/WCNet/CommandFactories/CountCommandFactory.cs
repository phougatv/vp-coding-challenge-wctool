[assembly: InternalsVisibleTo("WCNet.Tests")]
namespace VP.CodingChallenge.WCNet.CommandFactories;

internal class CountCommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    public IAsyncCommand CreateCommand(CommandKey commandKey)
    {
        var command = serviceProvider.GetKeyedService<IAsyncCommand>(commandKey);
        if (command is null)
        {
            return new CommandNotRegistered(commandKey);
        }

        return command;
    }

    public Result<ICollection<IAsyncCommand>> CreateCommands(IReadOnlyCollection<CommandKey> commandKeys)
    {
        if (commandKeys is null || commandKeys.Count < 1)
        {
            return Result<ICollection<IAsyncCommand>>.Fail(CommandKeysNullOrEmptyError.Create());
        }

        var commands = new List<IAsyncCommand>(commandKeys.Count);
        foreach (var commandKey in commandKeys)
        {
            var command = serviceProvider.GetKeyedService<IAsyncCommand>(commandKey);
            if (command is null)
            {
                commands.Add(new CommandNotRegistered(commandKey));
                continue;
            }

            commands.Add(command);
        }

        return Result<ICollection<IAsyncCommand>>.Ok(commands);
    }
}