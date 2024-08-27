namespace VP.CodingChallenge.WCNet.CommandResolvers;

internal interface ICommandResolver
{
	ICommand Resolve(Command commandKey);
}
