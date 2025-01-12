namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    IAsyncCommand CreateCommand(CommandKey commandKey);
    Result<ICollection<IAsyncCommand>> CreateCommands(IReadOnlyCollection<CommandKey> commandKeys);
}
