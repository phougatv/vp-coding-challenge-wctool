namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand(IWordCountable wordCountable) : ICommand
{
    public Result<Count> Execute()
    {
        var wordCount = wordCountable.GetCount();

        return Result<Count>.Ok(wordCount);
    }
}
