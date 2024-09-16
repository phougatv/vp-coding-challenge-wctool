namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
    private readonly String _filepath;

    public WordCountCommand(String filepath)
    {
        _filepath = filepath;
    }

    public Result<UInt64> Execute()
    {
        var content = File.ReadAllText(_filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return Result<UInt64>.Ok((UInt64)matchCollection.Count);
    }
}
