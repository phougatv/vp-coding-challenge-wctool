namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
    public Result<UInt64> Execute(String filepath)
    {
        var fileInfo = new FileInfo(filepath);
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
