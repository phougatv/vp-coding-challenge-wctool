namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal interface ICommandResolver
{
    ICommand ResolveCommand(CommandRequest request);
}
