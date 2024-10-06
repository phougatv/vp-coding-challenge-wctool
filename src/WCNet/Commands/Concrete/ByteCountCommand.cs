namespace VP.CodingChallenge.WCNet.Commands.Concrete;

[CommandKey("c")]
internal class ByteCountCommand : ICommand
{
    private readonly Filepath _filepath;

    public ByteCountCommand(Filepath filepath)
    {
        _filepath = filepath;
    }

    public Result<Count> Execute()
    {
        var fileInfo = new FileInfo(_filepath);

        return Result<Count>.Ok(fileInfo.Length);
    }
}
