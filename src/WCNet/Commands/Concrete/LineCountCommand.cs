namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("l")]
internal class LineCountCommand : ICommand
{
    private readonly Filepath _filepath;

    public LineCountCommand(Filepath filepath)
    {
        _filepath = filepath;
    }

    public Result<Count> Execute()
    {
        var fileInfo = new FileInfo(_filepath);
        var lineCount = 0L;
        using var streamReader = new StreamReader(fileInfo.FullName);
        while (streamReader.ReadLine() != null)
        {
            lineCount++;
        }

        return Result<Count>.Ok(lineCount);
    }
}
