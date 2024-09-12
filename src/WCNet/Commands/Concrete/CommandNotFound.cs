namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
	public Result<UInt64> Execute(String filepath)
        => Result<UInt64>.Fail(CommandNotFoundError.Create());
}
