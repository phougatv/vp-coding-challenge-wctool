namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
    private readonly Filepath _filepath;

    public WordCountCommand(Filepath filepath)
    {
        _filepath = filepath;
    }

    public Result<Count> Execute()
    {
        var content = File.ReadAllText(_filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return Result<Count>.Ok(matchCollection.Count);
    }
}
