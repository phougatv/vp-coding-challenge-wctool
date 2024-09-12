namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
    public Result<UInt64> Execute(String filepath)
    {
        var content = File.ReadAllText(filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return Result<UInt64>.Ok((UInt64)matchCollection.Count);
    }
}
