namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    ICommand CreateCommand(CommandRequest request);
    ICollection<ICommand> CreateCommands(CommandRequest request);
}
