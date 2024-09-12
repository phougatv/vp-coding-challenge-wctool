namespace VP.CodingChallenge.WCNet.CommandParsers;

internal interface ICommandParser
{
	Result<CommandArgument> Parse(String[] args);
}
