namespace VP.CodingChallenge.WCNet.CommandParsers;

internal interface ICommandParser
{
	Result<CommandRequest> Parse(String[] args);
}
