namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotFound : IAsyncCommand
{
    private readonly CommandKey _key;

    internal CommandNotFound(CommandKey key)
    {
        _key = key;
    }

	public async Task<Result<Count>> ExecuteAsync() => await Task.Run(() => Result<Count>.Fail(CommandNotFoundError.Create(_key)));
}
