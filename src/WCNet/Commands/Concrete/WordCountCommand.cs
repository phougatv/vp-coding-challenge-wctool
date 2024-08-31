namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("w")]
internal class WordCountCommand : ICommand
{
    public String Execute(String filepath)
    {
        var content = File.ReadAllText(filepath);
        var pattern = @"\b\w+\b";
        var matchCollection = Regex.Matches(content, pattern);

        return $"{matchCollection.Count} {Path.GetFileName(filepath)}";
    }
}
