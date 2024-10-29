namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("l")]
internal class LineCountCommand(IAsyncLineCountable lineCountable) : IAsyncCommand
{
    public async Task<Result<Count>> ExecuteAsync()
    {
        var lineCount = await lineCountable.GetCountAsync();

        return Result<Count>.Ok(lineCount);
    }
}
