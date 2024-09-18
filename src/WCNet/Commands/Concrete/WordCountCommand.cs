namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
<<<<<<< HEAD
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
=======
    public Result<UInt64> Execute(String filepath)
    {
        var content = File.ReadAllText(filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return Result<UInt64>.Ok((UInt64)matchCollection.Count);
>>>>>>> master
    }
}
