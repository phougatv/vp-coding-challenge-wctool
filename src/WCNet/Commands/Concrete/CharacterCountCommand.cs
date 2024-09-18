namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("m")]
internal class CharacterCountCommand : ICommand
{
<<<<<<< HEAD
    private readonly Filepath _filepath;
    private readonly IOutput _output;

    public CharacterCountCommand(Filepath filepath, IOutput output)
    {
        _filepath = filepath;
        _output = output;
    }

    public void Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        var characterCount = 0L;
=======
    public Result<UInt64> Execute(String filepath)
    {
        var fileInfo = new FileInfo(filepath);
        var characterCount = 0UL;
>>>>>>> master
        using var streamReader = new StreamReader(fileInfo.FullName);
        var line = streamReader.ReadLine();
        while (line != null)
        {
<<<<<<< HEAD
            characterCount += line.Length;
            line = streamReader.ReadLine();
        }

        _output.Sink(characterCount, fileInfo.Name);
=======
            characterCount += (UInt64)line.Length;
            line = streamReader.ReadLine();
        }

        return Result<UInt64>.Ok(characterCount);
>>>>>>> master
    }
}
