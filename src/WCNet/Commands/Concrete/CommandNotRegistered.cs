namespace VP.CodingChallenge.WCNet.Commands.Concrete;

internal class CommandNotRegistered : IAsyncCommand
{
    private readonly CommandKey _key;

    internal CommandNotRegistered(CommandKey key)
    {
        _key = key;
    }

	public async Task<Result<Count>> ExecuteAsync() => await Task.Run(() => Result<Count>.Fail(CommandNotRegisteredError.Create(_key.Key)));
}
