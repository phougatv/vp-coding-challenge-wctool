namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : ICommand
{
    private readonly CommandKey _key;

    internal CommandNotFound(CommandKey key)
    {
        _key = key;
    }

	public Result<Count> Execute() => Result<Count>.Fail(CommandNotFoundError.Create(_key));
}
