namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    ICommand CreateCommand(CommandKey commandKey);
    ICollection<ICommand> CreateCommands(IReadOnlyList<CommandKey> commandKeys);
}
