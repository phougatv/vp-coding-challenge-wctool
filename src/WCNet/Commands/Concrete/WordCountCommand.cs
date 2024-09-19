namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
    private readonly Filepath _filepath;
    private readonly IOutput _output;

    public WordCountCommand(Filepath filepath, IOutput output)
    {
        _filepath = filepath;
        _output = output;
    }

    public void Execute()
    {
        var content = File.ReadAllText(_filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);
        _output.Sink(matchCollection.Count, Path.GetFileName(_filepath));
    }
}
