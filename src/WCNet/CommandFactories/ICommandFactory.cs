namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    ICommand CreateCommand(CommandRequest request);
}
