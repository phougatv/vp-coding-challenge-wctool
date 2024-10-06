namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
	public Result<Count> Execute() => Result<Count>.Fail(CommandNotFoundError.Create());
}
