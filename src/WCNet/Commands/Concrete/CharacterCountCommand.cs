namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
    private readonly String _filepath;
    private readonly IOutput _output;

    public CharacterCountCommand(String filepath, IOutput output)
    {
        _filepath = filepath;
        _output = output;
    }

    public void Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        var characterCount = 0L;
        using var streamReader = new StreamReader(fileInfo.FullName);
        var line = streamReader.ReadLine();
        while (line != null)
        {
            characterCount += line.Length;
            line = streamReader.ReadLine();
        }

        _output.Sink(characterCount, fileInfo.Name);
    }
}
