namespace VP.CodingChallenge.WCNet.CommandResolvers;

using VP.CodingChallenge.WCNet.Commands;

internal interface ICommandResolver
{
	ICommand Resolve(String commandKey);
}
