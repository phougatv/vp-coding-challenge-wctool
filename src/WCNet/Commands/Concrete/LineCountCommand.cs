namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("l")]
internal class LineCountCommand(ILineCountable lineCountable) : ICommand
{
    public Result<Count> Execute()
    {
        var lineCount = lineCountable.GetCount();

        return Result<Count>.Ok(lineCount);
    }
}
