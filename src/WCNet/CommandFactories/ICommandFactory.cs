namespace VP.CodingChallenge.WCNet.CommandFactories;

internal interface ICommandFactory
{
    ICommand CreateCommand(CommandArgument request);
}
