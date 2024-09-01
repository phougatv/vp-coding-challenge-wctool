namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
    public String Execute(String filepath)
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

        return $"{characterCount} {Path.GetFileName(filepath)}";
    }
}
