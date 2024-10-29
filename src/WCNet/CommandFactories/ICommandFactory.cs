namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    IAsyncCommand CreateCommand(CommandKey commandKey);
    ICollection<IAsyncCommand> CreateCommands(IReadOnlyCollection<CommandKey> commandKeys);
}
