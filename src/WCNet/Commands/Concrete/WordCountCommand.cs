namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand(IAsyncWordCountable wordCountable) : IAsyncCommand
{
    public async Task<Result<Count>> ExecuteAsync()
    {
        var wordCount = await wordCountable.GetCountAsync();

        return Result<Count>.Ok(wordCount);
    }
}
