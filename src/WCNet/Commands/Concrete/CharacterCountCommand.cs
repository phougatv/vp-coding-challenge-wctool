namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
    private readonly Filepath _filepath;

    public CharacterCountCommand(Filepath filepath)
    {
        _filepath = filepath;
    }

    public Result<Count> Execute()
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

        return Result<Count>.Ok(characterCount);
    }
}
