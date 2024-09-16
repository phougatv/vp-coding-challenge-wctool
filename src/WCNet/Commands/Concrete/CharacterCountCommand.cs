namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
    private readonly String _filepath;

    public CharacterCountCommand(String filepath)
    {
        _filepath = filepath;
    }

    public Result<UInt64> Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        var characterCount = 0UL;
        using var streamReader = new StreamReader(fileInfo.FullName);
        var line = streamReader.ReadLine();
        while (line != null)
        {
            characterCount += (UInt64)line.Length;
            line = streamReader.ReadLine();
        }

        return Result<UInt64>.Ok(characterCount);
    }
}
