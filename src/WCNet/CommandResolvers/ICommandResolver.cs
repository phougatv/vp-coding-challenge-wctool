namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal interface ICommandResolver
{
	ICommand Resolve(CommandKey commandKey);
}
