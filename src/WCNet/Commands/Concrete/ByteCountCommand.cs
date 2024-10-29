namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand(IByteCountable byteCountable) : IAsyncCommand
{
    public async Task<Result<Count>> ExecuteAsync()
    {
        var count = await Task.Run(byteCountable.GetCount);

        return Result<Count>.Ok(count);
    }
}
